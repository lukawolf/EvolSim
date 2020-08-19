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
        public int Height { get; private set; }
        public int Temperature { get {
                var toReturn = InitialTemperature + TemperatureOffset;
                if (toReturn > 255)
                    return 255;
                if (toReturn < 0)
                    return 0;
                return toReturn;
            } }
        public int TemperatureOffset { get; set; }
        public int InitialTemperature { get; private set; }
        public int Calories { get; private set; }
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
            Height += height;
            if (Height > 255) Height = 255;
            if (Height < 0) Height = 0;
            InitialTemperature += temperature;
            if (InitialTemperature > 255) InitialTemperature = 255;
            if (InitialTemperature < 0) InitialTemperature = 0;
            Calories = MaxCalories / 2;
        }

        public override string ToString()
        {
            return "Field: \n Temperature: " + this.Temperature + "\n Height" + this.Height + "\n Calories:" + this.Calories;
        }
    }
}
