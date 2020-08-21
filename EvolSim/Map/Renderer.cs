using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace EvolSim.Map
{
    public static class Renderer
    {
        public static void RenderBuffered(World world, PaintEventArgs paintEventArgs, bool fill = false, bool bordered = false)
        {
            Image buffer = new Bitmap(paintEventArgs.ClipRectangle.Width, paintEventArgs.ClipRectangle.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(buffer);
            var newArgs = new PaintEventArgs(graphics, paintEventArgs.ClipRectangle);
            Render(world, newArgs, fill, bordered);
            graphics.Dispose();
            paintEventArgs.Graphics.DrawImage(buffer, 0, 0);
            buffer.Dispose();
        }
        public static void Render(World world, PaintEventArgs paintEventArgs, bool fill = false, bool bordered = false)
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
                    brush.Color = Color.FromArgb(world.Fields[x][y].Temperature, world.Fields[x][y].Calories, 255 - world.Fields[x][y].Height);
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
        }
    }
}
