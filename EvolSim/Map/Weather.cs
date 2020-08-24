using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Map
{
    /// <summary>
    /// Suported weather generation types for the Weather class
    /// </summary>
    enum WeatherType
    {
        Static,
        Sinusoidal,
        Random
    }
    /// <summary>
    /// A class to provide weather for a World instance
    /// </summary>
    class Weather
    {
        private WeatherType _currentWeather;
        protected int weatherIterator = 0;
        protected int sinusoidalShift = 0;
        public World World { get; private set; }
        public WeatherType CurrentWeather
        {
            get
            {
                return _currentWeather;
            }
            set
            {
                switch (value)
                {
                    case WeatherType.Static:
                        SetStaticWeather();
                        break;
                    case WeatherType.Sinusoidal:
                    case WeatherType.Random:
                        //Will be generated upon next step
                        break;
                    default:
                        throw new ArgumentException("Not a supported WeatherType");
                }
                _currentWeather = value;
            }
        }
        private int _amplitude;
        public int Amplitude{
            get => _amplitude;
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentException("Amplitude can be only between 0 and 255");
                }
                _amplitude = value;
                //Static weather needs setting
                if (CurrentWeather == WeatherType.Static)
                {
                    SetStaticWeather();
                }
            }
        }
        private int _changeInterval;
        public int ChangeInterval
        {
            get => _changeInterval;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Change interval can not be negative");
                }
                _changeInterval = value;
            }
        }

        /// <summary>
        /// Weather constructor
        /// </summary>
        /// <param name="world">The World instance to be affected by this weather instance</param>
        /// <param name="amplitude">The amplitude of the weather (if static, this is the temperature increase)</param>
        /// <param name="interval">The cycles upon which to change the weather </param>
        /// <param name="weatherType">The WeatherType to be calculated</param>
        public Weather(World world, int amplitude, int interval, WeatherType weatherType)
        {
            World = world;
            Amplitude = amplitude;
            ChangeInterval = interval;
            CurrentWeather = weatherType;            
        }

        /// <summary>
        /// Sets weather as static, which essentialy means nullifying weather offsets
        /// </summary>
        private void SetStaticWeather()
        {
            //There is no computation done here, therefore I do not see the need to parallelise
            foreach (var fields in World.Fields)
            {
                foreach (var field in fields)
                {
                    field.TemperatureOffset = Amplitude;
                }
            }
        }

        /// <summary>
        /// Sets weather as sinusoidal, iterating its lateral movement through the world
        /// </summary>
        private void SetSinusoidalWeather()
        {
            //We can safely parallelise the weather change as our columns do not affect each other
            Parallel.For(0, World.Width, i => {
                var fields = World.Fields[i];
                //We use the world coordinate shifted by the weather constant and then moduloed back into range, double for later operations
                double shift = (sinusoidalShift + i) % World.Width;
                //The shift needs to be fitted between 0 and 2 * pi to fit in the sin period
                shift = (Math.PI * 2) * (shift / World.Width);
                var sin = Math.Sin(shift);
                var weather = (int)(Math.Sin(shift) * Amplitude); //We convert to int only once, it saves time
                foreach (var field in fields)
                {
                    field.TemperatureOffset = weather;
                }
            });
            sinusoidalShift++;
        }

        /// <summary>
        /// Sets random weather for each tile
        /// </summary>
        private void SetRandomWeather()
        {
            //We can safely parallelise the weather change as our columns do not affect each other
            Parallel.ForEach<Field[]>(World.Fields, fields => {
                foreach (var field in fields)
                {
                    field.TemperatureOffset = RandomThreadSafe.Next(-Amplitude, Amplitude);
                }
            });
        }

        /// <summary>
        /// Increases the inner cycle iterator. When it reaches its interval, calls for a weather change.
        /// </summary>
        public void DoWeatherStep()
        {
            weatherIterator++;
            if (weatherIterator < ChangeInterval) return;
            switch (CurrentWeather)
            {
                case WeatherType.Static:
                    //No need for changes;
                    break;
                case WeatherType.Sinusoidal:
                    SetSinusoidalWeather();
                    break;
                case WeatherType.Random:
                    SetRandomWeather();
                    break;
            }
            weatherIterator = 0;
        }
    }
}
