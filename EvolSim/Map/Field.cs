using System;

namespace EvolSim.Map
{
    /// <summary>
    /// The world field representation
    /// </summary>
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
        private double _calories;
        public double Calories {
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
        /// <summary>
        /// Constructs the field using specified height and temperature, then computes a calorie baseline
        /// </summary>
        /// <param name="height">The height of the field</param>
        /// <param name="temperature">The temperature of the field</param>
        public Field(int height, int temperature)
        {
            Height = height;
            InitialTemperature = temperature;
            Calories = MaxCalories / 2;
        }

        /// <summary>
        /// Drops a bunch of height and temperature at the field, causing changes of said values. They are still bound to be between 0 and 255
        /// </summary>
        /// <param name="height">The height to be dropped upon the field</param>
        /// <param name="temperature">The temperature to be dropped upon the field</param>
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

        /// <summary>
        /// Converts the field to string giving its basic info
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            return "Field: \n Temperature: " + Temperature + "\n Height" + Height + "\n Calories:" + Calories;
        }

        /// <summary>
        /// Grows calories based on the simulation timestep fraction
        /// </summary>
        /// <param name="fractionElapsed">Fraction of simulation time elapsed</param>
        public void GrowCalories(double fractionElapsed)
        {
            var calories = Calories;
            //Allow for some divergence from the limits to limit flickering
            var allowedDivergence = MaxCalories / 10;
            //If we have too much calories, decay half of the difference plus one
            if (calories > MaxCalories + allowedDivergence)
            {
                calories -= ((calories - MaxCalories) / 2) * fractionElapsed;
            }
            //If we have too little calories, spread exponentially at first and linearly later
            else if (calories * 2 <= MaxCalories / 2)
            {
                calories += (calories + 1) * fractionElapsed;                
            }
            else if (calories < MaxCalories - allowedDivergence)
            {
                calories += (MaxCalories / 10 + 1) * fractionElapsed;
            }
            //Stick within value limits
            if (calories < 0) calories = 0;
            if (calories > 255) calories = 255;
            Calories = calories;
        }
    }
}
