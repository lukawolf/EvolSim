using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Map
{
    enum WeatherType
    {
        Static,
        Sinusoidal,
        Random
    }
    class Weather
    {
        private Random random;
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
                        break;
                    case WeatherType.Random:
                        SetRandomWeather();
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

        public Weather(World world, int amplitude, WeatherType weatherType)
        {
            World = world;
            Amplitude = amplitude;
            random = new Random();
            CurrentWeather = weatherType;            
        }

        /// <summary>
        /// Sets weather as static, which essentialy means nullifying weather offsets
        /// </summary>
        private void SetStaticWeather()
        {
            foreach (var fields in World.Fields)
            {
                foreach (var field in fields)
                {
                    field.TemperatureOffset = Amplitude;
                }
            }
        }

        private void SetSinusoidalWeather()
        {
            for (int i = 0; i < World.Width; i++)
            {
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
            }
            sinusoidalShift++;
        }

        private void SetRandomWeather()
        {
            foreach (var fields in World.Fields)
            {
                foreach (var field in fields)
                {
                    field.TemperatureOffset = random.Next(-Amplitude, Amplitude);
                }
            }
        }

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
