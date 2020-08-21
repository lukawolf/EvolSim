using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Map
{
    public class Field
    {
        public const int IdealTemperature = 126;
        public const int IdealHeight = 126;

        // Height under 0 means water
        public int Height { get; set; }

        // Final temperature is computed from initial and offset and limited within 0 and 255 as are the other values
        public int Temperature { get {
                var toReturn = InitialTemperature + TemperatureOffset;
                if (toReturn > 255)
                    return 255;
                if (toReturn < 0)
                    return 0;
                return toReturn;
            } }
        private int _temperatureOffset;
        public int TemperatureOffset {
            get => _temperatureOffset;
            set
            {
                if (value < -255 || value > 255)
                {
                    throw new ArgumentException("Temperature offset can be only between -255 and 255");
                }
                _temperatureOffset = value;
            }
        }
        private int _initialTemperature;
        public int InitialTemperature {
            get => _initialTemperature;
            set {
                if (value < -255 || value > 255)
                {
                    throw new ArgumentException("Initial temperature can be only between -255 and 255");
                }
                _initialTemperature = value;
            }
        }
        private int _calories;
        public int Calories {
            get => _calories;
            set {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentException("Calories can be only between 0 and 255");
                }
                _calories = value;
            }
        }
        public int MaxCalories {
            get
            {
                var toReturn = 255 - Math.Abs(IdealHeight - Height) - Math.Abs(IdealTemperature - Temperature);
                if (toReturn > 255)
                    return 255;
                if (toReturn < 0)
                    return 0;
                return toReturn;
            } }
        public Field(int height, int temperature)
        {
            Height = height;
            InitialTemperature = temperature;
            Calories = MaxCalories / 2;
        }

        public void Drop(int height, int temperature)
        {
            if (Height + height > 255) Height = 255;
            else if (Height + height < 0) Height = 0;
            else Height += height;

            if (InitialTemperature + temperature > 255) InitialTemperature = 255;
            else if (InitialTemperature + temperature < 0) InitialTemperature = 0;
            else InitialTemperature += temperature;
            Calories = MaxCalories / 2;
        }

        public override string ToString()
        {
            return "Field: \n Temperature: " + Temperature + "\n Height" + Height + "\n Calories:" + Calories;
        }
    }
}
