using System;
using EvolSim.Extensions;

namespace EvolSim.Creature
{
    /// <summary>
    /// The simulated lifeform
    /// </summary>
    public class Creature
    {
        //Size 0 ~ 1/4 tile diameter; Size 255 is maximum (~7/4 tiles diameter)  
        public const double MinimalTileSize = 0.25;
        public const double MaximalTileSize = 1.75;
        public const double MaximalLifeSpan = 1000 * 3;
        public const int MaxSize = 255;
        protected const double EatingEfficiency = 10;
        protected const double BaseMovementCost = 0.1;
        public double LifeLength { get; set; } = 0;
        //We modulo the coordinates to simulate continuous world (e.q. a round planet)
        private double _x;
        public double X { get => _x; set => _x = value.Modulo(World.Width - 1); }
        private double _y;
        public double Y { get => _y; set => _y = value.Modulo(World.Height - 1); }
        //The center of our creature moduloed onto the world
        public double CenterX { get => (X + SizeInTiles / 2).Modulo(World.Width - 1); }
        public double CenterY { get => (Y + SizeInTiles / 2).Modulo(World.Height - 1); }
        private double _rotation;
        //We modulo the rotation due to the period of cos and sin, the same with vision angle
        public double Rotation { get => _rotation; set => _rotation = value.Modulo(Math.PI * 2); }
        public double VisionDistance { get; set; }
        private double _visionAngle;
        public double VisionAngle { get => _visionAngle; set => _visionAngle = value.Modulo(Math.PI * 2); }
        public double Mutability { get; set; }
        public double Excitability { get; set; }
        public double HeightAffinity { get; set; } //The ideal height
        public double TemperatureAffinity { get; set; } //The ideal temperature
        // Size < 1 means death
        public double Size { get; set; }
        //Target size is used so that our later behavior is not impacted by the previous, especially when sending the size into negatives
        protected double TargetSize { get; set; }
        public double SizeInTiles { get => MinimalTileSize + Size / MaxSize * MaximalTileSize; }
        public Map.World World { get; private set; }
        internal Brain brain;
        //Constant senses to save memory
        protected double[] senses = new double[13];
        /// <summary>
        /// Computes whether the creature should die
        /// </summary>
        /// <returns>True when the creature should die</returns>
        public bool ShouldDie()
        {
            return (Size <= 1) || (LifeLength >= MaximalLifeSpan);
        }
        /// <summary>
        /// Constructs a random creature into the world
        /// </summary>
        /// <param name="world">The world</param>
        public Creature(Map.World world)
        {
            World = world;
            X = RandomThreadSafe.Next(0, World.Width);
            Y = RandomThreadSafe.Next(0, World.Height);
            Rotation = RandomThreadSafe.NextDouble(0, 2 * Math.PI);
            Size = RandomThreadSafe.Next(32, 64);
            brain = new Brain(13, 17, 4, 4);
            Mutability = RandomThreadSafe.NextDouble();
            Excitability = RandomThreadSafe.NextDouble();
            HeightAffinity = RandomThreadSafe.Next(0, Map.Field.MaxValue);
            TemperatureAffinity = RandomThreadSafe.Next(0, Map.Field.MaxValue);
            VisionDistance = RandomThreadSafe.NextDouble(0, Math.Min(World.Width, World.Height));
            VisionAngle = RandomThreadSafe.NextDouble(0, 2 * Math.PI);
        }
        /// <summary>
        /// Constructs a child creature from a parent
        /// </summary>
        /// <param name="parent">The parent</param>
        private Creature(Creature parent)
        {
            World = parent.World;
            X = parent.X;
            Y = parent.Y;
            Rotation = RandomThreadSafe.NextDouble(0, 2 * Math.PI);
            Size = parent.Size / 2;
            brain = new Brain(13, 17, 4, 4);
            Mutability = parent.Mutability + RandomThreadSafe.NextDouble(-parent.Mutability, parent.Mutability);
            Mutability = Math.Max(0, Math.Min(1, Mutability));
            Excitability = parent.Excitability + RandomThreadSafe.NextDouble(-parent.Mutability, parent.Mutability);
            Excitability = Math.Max(0, Math.Min(1, Excitability));
            HeightAffinity = (parent.HeightAffinity + RandomThreadSafe.NextDouble(-126 * parent.Mutability, 126 * parent.Mutability)).Modulo(Map.Field.MaxValue);
            TemperatureAffinity = (parent.TemperatureAffinity + RandomThreadSafe.NextDouble(-126 * parent.Mutability, 126 * parent.Mutability)).Modulo(Map.Field.MaxValue);
            VisionDistance = (parent.VisionDistance + RandomThreadSafe.NextDouble(-parent.Mutability * Math.Min(World.Width, World.Height) / 2, parent.Mutability * Math.Min(World.Width, World.Height) / 2)).Modulo(Math.Min(World.Width, World.Height));
            VisionAngle = parent.VisionAngle + RandomThreadSafe.NextDouble(-Math.PI * parent.Mutability, Math.PI * parent.Mutability);

            brain.GenerateFromBrain(parent.brain, Mutability);
        }

        /// <summary>
        /// Calculates the senses, normalising their values for the Brain
        /// </summary>
        private void CalculateSenses()
        {
            var currentField = CurrentField();   
            //Vision loops around world edges
            var visionX = (int)Math.Round(X + SizeInTiles + Math.Sin(Rotation + VisionAngle) * VisionDistance);
            visionX = visionX.Modulo(World.Width);
            var visionY = (int)Math.Round(Y + SizeInTiles + Math.Cos(Rotation + VisionAngle) * VisionDistance);
            visionY = visionY.Modulo(World.Height);
            lock (currentField)
            {
                senses[0] = currentField.Height / Map.Field.MaxValue;
                senses[1] = currentField.Temperature / Map.Field.MaxValue;
                senses[2] = currentField.Calories / Map.Field.MaxValue;
            }
            lock (World.Fields[visionX][visionY])
            {
                senses[3] = World.Fields[visionX][visionY].Height / Map.Field.MaxValue;
                senses[4] = World.Fields[visionX][visionY].Temperature / Map.Field.MaxValue;
                senses[5] = World.Fields[visionX][visionY].Calories / Map.Field.MaxValue;
            }
            senses[6] = Mutability;
            senses[7] = HeightAffinity / Map.Field.MaxValue;
            senses[8] = TemperatureAffinity / Map.Field.MaxValue;
            senses[9] = Size / MaxSize;
            senses[10] = X / World.Width;
            senses[11] = Y / World.Height;
            senses[12] = Rotation / (Math.PI * 2);
        }

        /// <summary>
        /// An update tick handler
        /// </summary>
        /// <param name="fractionElapsed">The fraction of the simulation time that has just passed</param>
        /// <returns>A child Creature, if one was made</returns>
        public Creature Update(double fractionElapsed)
        {
            TargetSize = Size;
            CalculateSenses();
            var thoughts = brain.Think(senses);
            var toReturn = Split(thoughts[3]);
            Rotate(thoughts[0], fractionElapsed);
            Move(thoughts[1], fractionElapsed);            
            Eat(thoughts[2], fractionElapsed);            
            CostOfLiving(fractionElapsed);
            Size = TargetSize;
            LifeLength += fractionElapsed;
            return toReturn;
        }

        /// <summary>
        /// Handles the creature movement
        /// </summary>
        /// <param name="weight">Movement decision weight / intensity</param>
        /// <param name="fractionElapsed">The fraction of the simulation time that has just passed</param>
        private void Move(double weight, double fractionElapsed)
        {
            //Movement loops around world edges and costs more with more movement
            TargetSize -= Math.Pow(BaseMovementCost + 2 * weight, 2) * fractionElapsed;
            X += SizeInTiles * weight * Math.Sin(Rotation) * fractionElapsed;
            Y += SizeInTiles * weight * Math.Cos(Rotation) * fractionElapsed;
        }
        /// <summary>
        /// Handles the creature rotation
        /// </summary>
        /// <param name="weight">Rotation decision weight / intensity</param>
        /// <param name="fractionElapsed">The fraction of the simulation time that has just passed</param>
        private void Rotate(double weight, double fractionElapsed)
        {
            //Here 0.5 is considered idle, while all others cause rotation in either way
            TargetSize -= Math.Abs(weight - 0.5) * fractionElapsed;
            Rotation += (weight - 0.5) * Math.PI * fractionElapsed;
        }
        /// <summary>
        /// Computes the current field the creature is standing at
        /// </summary>
        /// <returns>The current field</returns>
        private Map.Field CurrentField()
        {
            return World.Fields[(int)Math.Round(CenterX)][(int)Math.Round(CenterY)];
        }
        /// <summary>
        /// Handles eating food from the field
        /// </summary>
        /// <param name="weight">Eating decision weight</param>
        /// <param name="fractionElapsed">The fraction of the simulation time that has just passed</param>
        private void Eat(double weight, double fractionElapsed)
        {
            //In this case we either eat or we don't
            if (weight > Excitability)
            {
                var toEat = SizeInTiles * EatingEfficiency * fractionElapsed;
                TargetSize -= SizeInTiles * fractionElapsed;
                var eatenField = CurrentField();                
                lock (eatenField)
                {
                    if (eatenField.Calories > toEat)
                    {
                        eatenField.Calories -= toEat;
                        TargetSize += toEat;
                    }
                    else
                    {
                        TargetSize += eatenField.Calories;
                        eatenField.Calories = 0;
                    }
                }
                if (TargetSize > MaxSize)
                {
                    TargetSize = MaxSize;
                }
            }
        }
        /// <summary>
        /// Handles the creature creating offspring
        /// </summary>
        /// <param name="weight">Splitting decision weight</param>
        /// <returns>The child creature</returns>
        private Creature Split(double weight)
        {
            Creature toReturn = null;
            if (weight > Excitability)
            {
                toReturn = new Creature(this);
                TargetSize /= 2;
            }
            return toReturn;
        }
        /// <summary>
        /// Subtracts the cost of living from the creature's calory reserves (its size)
        /// </summary>
        /// <param name="fractionElapsed">The fraction of the simulation time that has just passed</param>
        private void CostOfLiving(double fractionElapsed)
        {
            var currentField = CurrentField();
            var heightCost = Math.Pow((HeightAffinity - currentField.Height) / 64.0, 2);
            var temperatureCost = Math.Pow((TemperatureAffinity - currentField.Temperature) / 64.0, 2);
            TargetSize -= (1 + heightCost + temperatureCost) * fractionElapsed;
        }
    }
}
