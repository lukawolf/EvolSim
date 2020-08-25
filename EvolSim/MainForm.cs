using System;
using System.Drawing;
using System.Windows.Forms;
using EvolSim.Map;
//TODO: Move magic constants
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
            world.SelectCreature(worldX, worldY);
            GraphicTimer_Tick(sender, e);           
        }

        //World generation starter buttons
        private void NewWorld(IMapGenerator generator, object sender, EventArgs e)
        {
            if (simulationLoop != null && simulationLoop.Running)
            {
                simulationLoop.Pause();
                StatusIndicator.Text = "Not started";
            }
            world = new World((int)WorldWidth.Value, (int)WorldHeight.Value, (int)MinimalCreatureAmount.Value);
            world.Generate(generator, MapGenProgress);
            weather = new Weather(world, (int)WeatherAmplitude.Value, (int)WeatherChangePeriod.Value, GetSelectedWeather());
            simulationLoop = new SimulationLoop((int)CycleSleep.Value, weather);
            simulationLoop.LoadWorld(world);
            GraphicTimer_Tick(sender, e);
        }
        private void BtnWorldGenCA_Click(object sender, EventArgs e)
        {
            NewWorld(new CellularAutomataGenerator(), sender, e);
        }

        private void BtnWorldGenHM_Click(object sender, EventArgs e)
        {
            NewWorld(new HeightMapGenerator(), sender, e);
        }

        private void BtnWorldGenGaia_Click(object sender, EventArgs e)
        {
            NewWorld(new GaiaGenerator(), sender, e);
        }

        //Handler for weather type being changed
        private void WeatherChanged(object sender, EventArgs e)
        {
            if (weather == null) return;
            weather.CurrentWeather = GetSelectedWeather();
        }

        //Gets the selected weather as WeatherType enum
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
            //Otherwise clipping could stop drawing in certain areas or cause shrinking
            e = new PaintEventArgs(e.Graphics, new Rectangle(0, 0, SimulationPanel.Width, SimulationPanel.Height));
            Renderer.RenderBuffered(world, e, false, false);
        }

        //TODO: Think about moving rendering from graphic timer to game loop and render each n-th simulation step in the buffer, using graphic timer to only render that
        /// <summary>
        /// Handler for graphic timer ticks, starts drawing of our map (via triggering the map paint method)
        /// and also sets unfocused inputs to current values
        /// </summary>
        private void GraphicTimer_Tick(object sender, EventArgs e)
        {
            //Render the world
            var graphics = SimulationPanel.CreateGraphics();
            Rectangle rectangle = new Rectangle(0, 0, SimulationPanel.Width, SimulationPanel.Height);
            SimulationPanel_Paint(sender, new PaintEventArgs(graphics, rectangle));

            //If field is selected, we allow its editing, otherwise we lock the controls
            if (world.SelectedField != null)
            {
                TileInitialTemperature.Enabled = true;
                TileTemperatureOffset.Enabled = true;
                TileHeight.Enabled = true;
                TileCalories.Enabled = true;
                TileCoordinates.Text = world.SelectedFieldX.ToString() + "X, " + world.SelectedFieldY.ToString() + "Y";
                TileTemperature.Text = world.SelectedField.Temperature.ToString() + "/" + Field.MaxValue.ToString();
                TileMaxCalories.Text = world.SelectedField.MaxCalories.ToString() + "/" + Field.MaxValue.ToString();
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
                    TileCalories.Value = (int)world.SelectedField.Calories;
                }
            }
            else
            {
                TileInitialTemperature.Enabled = false;
                TileTemperatureOffset.Enabled = false;
                TileHeight.Enabled = false;
                TileCalories.Enabled = false;
            }

            //If a creature is selected, we allow its editing, otherwise we lock the controls
            if (world.SelectedCreature != null)
            {
                CreatureX.Enabled = true;
                CreatureY.Enabled = true;
                CreatureRotation.Enabled = true;
                CreatureSize.Enabled = true;
                CreatureVisionAngle.Enabled = true;
                CreatureVisionDistance.Enabled = true;
                CreatureMutability.Enabled = true;
                CreatureExcitability.Enabled = true;
                CreatureHeightAffinity.Enabled = true;
                CreatureTemperatureAffinity.Enabled = true;
                CreatureAge.Enabled = true;
                if (!CreatureX.Focused)
                {
                    CreatureX.Value = (decimal)world.SelectedCreature.X;
                }
                if (!CreatureY.Focused)
                {
                    CreatureY.Value = (decimal)world.SelectedCreature.Y;
                }               
                if(!CreatureRotation.Focused){
                    CreatureRotation.Value = (decimal)world.SelectedCreature.Rotation;
                }
                if(!CreatureSize.Focused){
                    CreatureSize.Value = (decimal)world.SelectedCreature.Size;
                }
                if(!CreatureVisionAngle.Focused){
                    CreatureVisionAngle.Value = (decimal)world.SelectedCreature.VisionAngle;
                }
                if(!CreatureVisionDistance.Focused){
                    CreatureVisionDistance.Value = (decimal)world.SelectedCreature.VisionDistance;
                }
                if(!CreatureMutability.Focused){
                    CreatureMutability.Value = (decimal)world.SelectedCreature.Mutability;
                }
                if(!CreatureExcitability.Focused){
                    CreatureExcitability.Value = (decimal)world.SelectedCreature.Excitability;
                }
                if(!CreatureHeightAffinity.Focused){
                    CreatureHeightAffinity.Value = (decimal)world.SelectedCreature.HeightAffinity;
                }
                if(!CreatureTemperatureAffinity.Focused){
                    CreatureTemperatureAffinity.Value = (decimal)world.SelectedCreature.TemperatureAffinity;
                }
                if (!CreatureAge.Focused)
                {
                    CreatureAge.Value = (decimal)world.SelectedCreature.LifeLength;
                }
                //Draw creature brains if it is selected
                var brainGraphics = CreatureBrainCanvas.CreateGraphics();
                Rectangle brainRectangle = new Rectangle(0, 0, CreatureBrainCanvas.Width, CreatureBrainCanvas.Height);
                CreatureBrainCanvas_Paint(sender, new PaintEventArgs(brainGraphics, brainRectangle));
            }
            else
            {
                CreatureX.Enabled = false;
                CreatureY.Enabled = false;
                CreatureRotation.Enabled = false;
                CreatureSize.Enabled = false;
                CreatureVisionAngle.Enabled = false;
                CreatureVisionDistance.Enabled = false;
                CreatureMutability.Enabled = false;
                CreatureExcitability.Enabled = false;
                CreatureHeightAffinity.Enabled = false;
                CreatureTemperatureAffinity.Enabled = false;
                CreatureAge.Enabled = false;
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

        private void MinimalCreatureAmount_ValueChanged(object sender, EventArgs e)
        {
            if (world == null) return;
            world.MinCreatures = (int)MinimalCreatureAmount.Value;
        }

        //Handlers for creature value changes
        private void CreatureX_ValueChanged(object sender, EventArgs e)
        {
            if (world == null || world.SelectedCreature == null) return;
            world.SelectedCreature.X = (double)CreatureX.Value;
        }

        private void CreatureY_ValueChanged(object sender, EventArgs e)
        {
            if (world == null || world.SelectedCreature == null) return;
            world.SelectedCreature.Y = (double)CreatureY.Value;
        }

        private void CreatureRotation_ValueChanged(object sender, EventArgs e)
        {
            if (world == null || world.SelectedCreature == null) return;
            world.SelectedCreature.Rotation = (double)CreatureRotation.Value;
        }

        private void CreatureSize_ValueChanged(object sender, EventArgs e)
        {
            if (world == null || world.SelectedCreature == null) return;
            world.SelectedCreature.Size = (double)CreatureSize.Value;
        }

        private void CreatureVisionDistance_ValueChanged(object sender, EventArgs e)
        {
            if (world == null || world.SelectedCreature == null) return;
            world.SelectedCreature.VisionDistance = (double)CreatureVisionDistance.Value;
        }

        private void CreatureVisionAngle_ValueChanged(object sender, EventArgs e)
        {
            if (world == null || world.SelectedCreature == null) return;
            world.SelectedCreature.VisionAngle = (double)CreatureVisionAngle.Value;
        }

        private void CreatureMutability_ValueChanged(object sender, EventArgs e)
        {
            if (world == null || world.SelectedCreature == null) return;
            world.SelectedCreature.Mutability = (double)CreatureMutability.Value;
        }

        private void CreatureExcitability_ValueChanged(object sender, EventArgs e)
        {
            if (world == null || world.SelectedCreature == null) return;
            world.SelectedCreature.Excitability = (double)CreatureExcitability.Value;
        }

        private void CreatureHeightAffinity_ValueChanged(object sender, EventArgs e)
        {
            if (world == null || world.SelectedCreature == null) return;
            world.SelectedCreature.HeightAffinity = (double)CreatureHeightAffinity.Value;
        }

        private void CreatureTemperatureAffinity_ValueChanged(object sender, EventArgs e)
        {
            if (world == null || world.SelectedCreature == null) return;
            world.SelectedCreature.TemperatureAffinity = (double)CreatureTemperatureAffinity.Value;
        }

        private void CreatureAge_ValueChanged(object sender, EventArgs e)
        {
            if (world == null || world.SelectedCreature == null) return;
            world.SelectedCreature.LifeLength = (double)CreatureAge.Value;
        }

        /// <summary>
        /// Draws the creature brain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreatureBrainCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (world == null || world.SelectedCreature == null) return;
            //Otherwise clipping could stop drawing in certain areas or cause shrinking
            e = new PaintEventArgs(e.Graphics, new Rectangle(0, 0, CreatureBrainCanvas.Width, CreatureBrainCanvas.Height));
            Creature.BrainRenderer.RenderBuffered(world.SelectedCreature.brain, e);
        }
    }
}
