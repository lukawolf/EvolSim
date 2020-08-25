using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EvolSim
{
    /// <summary>
    /// The simulation loop object
    /// </summary>
    class SimulationLoop
    {
        /// <summary>
        /// Whether the simulation is running
        /// </summary>
        public bool Running { get; private set; }
        public Map.World World { get; private set; }
        public Map.Weather Weather { get; private set; }
        private int _delay;
        public int Delay {
            get
            {
                return _delay;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Delay can not be negative");
                }
                _delay = value;
            }
        }
        protected Stopwatch simulationStopwatch;

        /// <summary>
        /// Constructs the loop for a given weather and delay
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="weather"></param>
        public SimulationLoop(int delay, Map.Weather weather)
        {
            Delay = delay;
            Weather = weather;
        }

        /// <summary>
        /// Loads the world into the simulation loop
        /// </summary>
        /// <param name="world"></param>
        public void LoadWorld(Map.World world)
        {
            World = world;
        }

        /// <summary>
        /// Starts the simulation
        /// </summary>
        public async void Start()
        {
            //Check world
            if (World == null)
                throw new ArgumentException("World is not loaded!");

            if (World.Fields == null)
                throw new ArgumentException("World is not generated!");

            //If everything is ok, we enter the loop
            Running = true;
            simulationStopwatch = Stopwatch.StartNew();
            while (Running)
            {
                var timeElapsed = simulationStopwatch.ElapsedMilliseconds;
                simulationStopwatch.Restart();
                lock (World)
                {
                    Weather.DoWeatherStep();
                    World.Update((double)timeElapsed / Delay);
                }                
                await Task.Delay((int)Math.Max(Delay - timeElapsed, 0)); //The delay is lowered if the simulation rate lags behind
            }
        }

        /// <summary>
        /// Pauses the simulation
        /// </summary>
        public void Pause()
        {
            Running = false;
        }
    }
}
