using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvolSim.Map;

namespace EvolSim
{
    public partial class MainForm : Form
    {
        private World world;
        private Graphics graphics = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void SimulationField_Click(object sender, EventArgs e)
        {            
            var mouseEvent = e as MouseEventArgs;
            //SimulationPanel.Invalidate();
            if (graphics == null)
            {
                graphics = SimulationPanel.CreateGraphics();
            }
            Renderer.Render(world, graphics, false, false);
            //Click visualisation       
            var color = Color.Black;
            var brush = new SolidBrush(color);
            var pen = new Pen(color, 1);
            graphics.DrawEllipse(pen, mouseEvent.X - 3, mouseEvent.Y - 3, 6, 6);
            //End click visualisation
            if (world != null)
            {
                var worldX = mouseEvent.X / (SimulationPanel.Width / world.Width);
                var worldY = mouseEvent.Y / (SimulationPanel.Height / world.Height);              
                world.SelectField(worldX, worldY);
            }           
        }

        private void BtnWorldGenCA_Click(object sender, EventArgs e)
        {
            world = new World((int)WorldWidth.Value, (int)WorldHeight.Value);
            world.Generate(World.GenerationType.CellularAutomata, MapGenProgress);
        }

        private void BtnWorldGenHM_Click(object sender, EventArgs e)
        {
            world = new World((int)WorldWidth.Value, (int)WorldHeight.Value);
            world.Generate(World.GenerationType.HeightMap, MapGenProgress);
        }

        private void BtnWorldGenGaia_Click(object sender, EventArgs e)
        {
            world = new World((int)WorldWidth.Value, (int)WorldHeight.Value);
            world.Generate(World.GenerationType.Gaia, MapGenProgress);
        }
    }
}
