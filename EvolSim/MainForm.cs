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
        private Weather weather;
        private SimulationLoop simulationLoop;
        public MainForm()
        {
            InitializeComponent();
            //DoubleBuffered = true; //Buffering reduces render flickers, but it is not neccessary when our render method implements its own image buffer
        }

        //When we click on the simulation field, we select the relevant tile
        private void SimulationField_Click(object sender, EventArgs e)
        {
            if (world == null) return; //If the world is not yet generated, we do nothing

            var mouseEvent = e as MouseEventArgs; //We need to interpret the event as its correct class

            var worldX = mouseEvent.X / (SimulationPanel.Width / world.Width);
            var worldY = mouseEvent.Y / (SimulationPanel.Height / world.Height);
            world.SelectField(worldX, worldY);
            GraphicTimer_Tick(sender, e);
            TileInitialTemperature.Enabled = true;
            TileTemperatureOffset.Enabled = true;
            TileHeight.Enabled = true;
            TileCalories.Enabled = true;
        }

        //World generation starter buttons
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

        private void WeatherChanged(object sender, EventArgs e)
        {
            if (weather == null) return;
            weather.CurrentWeather = GetSelectedWeather();
        }

        private WeatherType GetSelectedWeather()
        {
            if (WeatherStatic.Checked) return WeatherType.Static;
            if (WeatherSin.Checked) return WeatherType.Sinusoidal;
            if (WeatherRandom.Checked) return WeatherType.Random;

            throw new ArgumentException("No weather selected");
        }

        /// <summary>
        /// Switches simulation loop status between running and paused. On first run creates the loop and loads our world
        /// </summary>
        private void StatusSwitchButton_Click(object sender, EventArgs e)
        {
            if (world == null)
            {
                MessageBox.Show("To start the simulation, generate the world first!", "Simulation can not start");
                return;
            }
            if (simulationLoop == null)
            {
                weather = new Weather(world, (int)WeatherAmplitude.Value, GetSelectedWeather());
                simulationLoop = new SimulationLoop((int)CycleSleep.Value, weather);
                simulationLoop.LoadWorld(world);
            }
            if (simulationLoop.Running)
            {
                simulationLoop.Pause();
                StatusIndicator.Text = "Stopped";
                GraphicTimer.Stop();
                return;
            }
            simulationLoop.Start();
            GraphicTimer.Start();
            StatusIndicator.Text = "Playing";           
        }

        /// <summary>
        /// When the simulation panel is painted, we draw our world if available
        /// </summary>
        private void SimulationPanel_Paint(object sender, PaintEventArgs e)
        {
            if (world == null)
            {
                return;
            }
            Renderer.RenderBuffered(world, e, false, false);
        }

        //TODO: Think about moving rendering from graphic timer to game loop and render each n-th simulation step
        /// <summary>
        /// Handler for graphic timer ticks, starts drawing of our map (via triggering the map paint method)
        /// and also sets unfocused inputs to current values
        /// </summary>
        private void GraphicTimer_Tick(object sender, EventArgs e)
        {
            var graphics = SimulationPanel.CreateGraphics();
            Rectangle rectangle = new Rectangle(0, 0, SimulationPanel.Width, SimulationPanel.Height);
            SimulationPanel_Paint(sender, new PaintEventArgs(graphics, rectangle));

            if (world.SelectedField != null)
            {
                TileCoordinates.Text = world.SelectedFieldX.ToString() + "X, " + world.SelectedFieldY.ToString() + "Y";
                TileTemperature.Text = world.SelectedField.Temperature.ToString() + "/255";
                TileMaxCalories.Text = world.SelectedField.MaxCalories.ToString() + "/255";
                if (!TileInitialTemperature.Focused)
                {
                    TileInitialTemperature.Value = world.SelectedField.InitialTemperature;
                }
                if (!TileTemperatureOffset.Focused)
                {
                    TileTemperatureOffset.Value = world.SelectedField.TemperatureOffset;
                }
                if (!TileHeight.Focused)
                {
                    TileHeight.Value = world.SelectedField.Height;
                }
                if (!TileCalories.Focused)
                {
                    TileCalories.Value = world.SelectedField.Calories;
                }
            }
        }

        //Handlers for manual map field value changes
        private void TileInitialTemperature_ValueChanged(object sender, EventArgs e)
        {
            world.SelectedField.InitialTemperature = (int)TileInitialTemperature.Value;
        }

        private void TileTemperatureOffset_ValueChanged(object sender, EventArgs e)
        {
            world.SelectedField.TemperatureOffset = (int)TileTemperatureOffset.Value;
        }

        private void TileHeight_ValueChanged(object sender, EventArgs e)
        {
            world.SelectedField.Height = (int)TileHeight.Value;
        }

        private void TileCalories_ValueChanged(object sender, EventArgs e)
        {
            world.SelectedField.Calories = (int)TileCalories.Value;
        }

        private void CycleSleep_ValueChanged(object sender, EventArgs e)
        {
            if (simulationLoop == null) return;
            simulationLoop.Delay = (int)CycleSleep.Value;
            GraphicTimer.Interval = simulationLoop.Delay;
        }

        private void WeatherAmplitude_ValueChanged(object sender, EventArgs e)
        {
            if (weather == null) return;
            weather.Amplitude = (int)WeatherAmplitude.Value;
        }

        private void WeatherChangePeriod_ValueChanged(object sender, EventArgs e)
        {
            if (weather == null) return;
            weather.ChangeInterval = (int)WeatherChangePeriod.Value;
        }
    }
}
