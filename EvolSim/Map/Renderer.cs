using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EvolSim.Map
{
    public static class Renderer
    {
        public static void Render(World world, Graphics graphics, bool fill = false, bool bordered = false)
        {
            if (world == null)
            {
                return;
            }
            //Prepare the control's graphics
            //graphics.Clear(Color.Black);
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

            for (int x = 0; x < world.Fields.Length; x++)
            {
                for (int y = 0; y < world.Fields[x].Length; y++)
                {
                    brush.Color = Color.FromArgb(world.Fields[x][y].Temperature, world.Fields[x][y].Calories, 255 - world.Fields[x][y].Height);
                    graphics.FillRectangle(brush, tileWidth * x, tileHeight * y, tileWidth, tileHeight);
                    if(bordered) graphics.DrawRectangle(pen, tileWidth * x, tileHeight * y, tileWidth, tileHeight);
                }
            }
        }
    }
}
