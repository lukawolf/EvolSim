using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace EvolSim.Map
{
    /// <summary>
    /// The world renderer
    /// </summary>
    public static class Renderer
    {
        /// <summary>
        /// Prepares a buffer to render the world instance, renders into said buffer and then renders the buffer onto the event graphics.
        /// </summary>
        /// <param name="world">The world to be rendered</param>
        /// <param name="paintEventArgs">Paint event arguments of the painting target</param>
        /// <param name="fill">Whether to fill out the container, thus stretching fields</param>
        /// <param name="bordered">Whether to paint borders at every world field</param>
        public static void RenderBuffered(World world, PaintEventArgs paintEventArgs, bool fill = false, bool bordered = false)
        {
            Image buffer = new Bitmap(paintEventArgs.ClipRectangle.Width, paintEventArgs.ClipRectangle.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(buffer);
            var newArgs = new PaintEventArgs(graphics, paintEventArgs.ClipRectangle);
            lock (world)
            {
                Render(world, newArgs, fill, bordered);
            }                  
            graphics.Dispose();
            paintEventArgs.Graphics.DrawImage(buffer, 0, 0);
            buffer.Dispose();
        }
        /// <summary>
        /// Renders the world instance
        /// </summary>
        /// <param name="world">The world to be rendered</param>
        /// <param name="paintEventArgs">Paint event arguments of the painting target</param>
        /// <param name="fill">Whether to fill out the container, thus stretching fields</param>
        /// <param name="bordered">Whether to paint borders at every world field</param>
        private static void Render(World world, PaintEventArgs paintEventArgs, bool fill = false, bool bordered = false)
        {
            if (world == null)
            {
                throw new ArgumentNullException("World can not be null");
            }
            if (paintEventArgs == null)
            {
                throw new ArgumentNullException("PaintEventArgs can not be null");
            }

            var brush = new SolidBrush(Color.Black);
            var pen = new Pen(Color.Black, 1);

            //Precompute tile widths and heights
            var tileWidth = 500 / world.Width;
            var tileHeight = 500 / world.Height;

            //If we want to fill out the field use the precomputed values, else we leave a part of the field empty and use the smaller dimension
            if (!fill)
            {
                if (tileWidth > tileHeight) tileWidth = tileHeight;
                else tileHeight = tileWidth;
            }

            Rectangle? finalRectangle = null;
            for (int x = 0; x < world.Fields.Length; x++)
            {
                for (int y = 0; y < world.Fields[x].Length; y++)
                {
                    brush.Color = Color.FromArgb(world.Fields[x][y].Temperature, (int)world.Fields[x][y].Calories, 255 - world.Fields[x][y].Height);
                    paintEventArgs.Graphics.FillRectangle(brush, tileWidth * x, tileHeight * y, tileWidth, tileHeight);
                    if(bordered) paintEventArgs.Graphics.DrawRectangle(pen, tileWidth * x, tileHeight * y, tileWidth, tileHeight);
                    if(world.Fields[x][y] == world.SelectedField)
                    {
                        finalRectangle = new Rectangle(tileWidth * x, tileHeight * y, tileWidth, tileHeight);
                    }
                }
            }
            if (finalRectangle != null)
            {
                paintEventArgs.Graphics.DrawRectangle(pen, (Rectangle)finalRectangle);
            }
            brush.Color = Color.FromArgb(126, 255, 255, 255);
            var selectedBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
            foreach (var creature in world.Creatures)
            {
                //Creature size makes sense between half tile and whole tile size
                var convertedWidth = (float)creature.SizeInTiles * tileWidth;
                var convertedHeight = (float)creature.SizeInTiles * tileHeight;
                //We can accept the double to float truncate here, we still operate in pixels after all and are confined to 0-500, which both cover easily
                if (creature == world.SelectedCreature)
                {
                    paintEventArgs.Graphics.FillEllipse(selectedBrush, (float)creature.CenterX * tileWidth, (float)creature.CenterY * tileHeight, convertedWidth, convertedHeight);
                }
                else
                {
                    paintEventArgs.Graphics.FillEllipse(brush, (float)creature.CenterX * tileWidth, (float)creature.CenterY * tileHeight, convertedWidth, convertedHeight);
                }                
                paintEventArgs.Graphics.DrawEllipse(pen, (float)creature.CenterX * tileWidth, (float)creature.CenterY * tileHeight, convertedWidth, convertedHeight);
            }
        }
    }
}
