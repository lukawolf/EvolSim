using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolSim.Extensions;

namespace EvolSim.Creature
{
    public class Creature
    {
        public double X { get; protected set; }
        public double Y { get; protected set; }
        public double CenterX { get => (X + SizeInTiles).Modulo(World.Width - 1); }
        public double CenterY { get => (Y + SizeInTiles).Modulo(World.Height - 1); }
        public double Rotation { get; protected set; }
        public double VisionDistance { get; protected set; }
        public double VisionAngle { get; protected set; }
        public double Mutability { get; protected set; }
        public double Excitability { get; protected set; }
        public double HeightAffinity { get; protected set; } //The ideal height
        public double TemperatureAffinity { get; protected set; } //The ideal temperature
        // Size < 1 means death, Size 0 ~ 1/4 tile diameter; Size 255 is maximum (~2 tiles diameter)  
        public double Size { get; protected set; }
        protected double TargetSize { get; set; }
        public double SizeInTiles { get => 1 / 4 + Size / 255 * 1.75; }
        public Map.World World { get; private set; }
        protected Brain brain;
        //Constant senses to save memory
        protected double[] senses = new double[13];
        public bool ShouldDie()
        {
            return Size <= 1;
        }
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
            HeightAffinity = RandomThreadSafe.Next(0, 255);
            TemperatureAffinity = RandomThreadSafe.Next(0, 255);
            VisionDistance = RandomThreadSafe.NextDouble(0, Math.Min(World.Width, World.Height));
            VisionAngle = RandomThreadSafe.NextDouble(0, 2 * Math.PI);
        }
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
            HeightAffinity = (parent.HeightAffinity + RandomThreadSafe.NextDouble(-126 * parent.Mutability, 126 * parent.Mutability)).Modulo(255);
            TemperatureAffinity = (parent.TemperatureAffinity + RandomThreadSafe.NextDouble(-126 * parent.Mutability, 126 * parent.Mutability)).Modulo(255);
            VisionDistance = (parent.VisionDistance + RandomThreadSafe.NextDouble(-parent.Mutability * Math.Min(World.Width, World.Height) / 2, parent.Mutability * Math.Min(World.Width, World.Height) / 2)).Modulo(Math.Min(World.Width, World.Height));
            VisionAngle = parent.VisionAngle + RandomThreadSafe.NextDouble(-Math.PI * parent.Mutability, Math.PI * parent.Mutability);

            brain.GenerateFromBrain(parent.brain, Mutability);
        }

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
                senses[0] = currentField.Height;
                senses[1] = currentField.Temperature;
                senses[2] = currentField.Calories;
            }
            lock (World.Fields[visionX][visionY])
            {
                senses[3] = World.Fields[visionX][visionY].Height;
                senses[4] = World.Fields[visionX][visionY].Temperature;
                senses[5] = World.Fields[visionX][visionY].Calories;
            }
            senses[6] = Mutability;
            senses[7] = HeightAffinity;
            senses[8] = TemperatureAffinity;
            senses[9] = Size;
            senses[10] = X;
            senses[11] = Y;
            senses[12] = Rotation;
        }

        public Creature Update(double fractionElapsed)
        {
            TargetSize = Size;
            CalculateSenses();
            var thoughts = brain.Think(senses);
            var toReturn = Split(thoughts[3], fractionElapsed);
            Rotate(thoughts[0], fractionElapsed);
            Move(thoughts[1], fractionElapsed);            
            Eat(thoughts[2], fractionElapsed);            
            CostOfLiving(fractionElapsed);
            Size = TargetSize;
            return toReturn;
        }

        private void Move(double weight, double fractionElapsed)
        {
            //Movement loops around world edges and costs more with more movement
            TargetSize -= Math.Pow(0.1 + 2 * weight, 2) * fractionElapsed;
            X += SizeInTiles * weight * Math.Sin(Rotation) * fractionElapsed;
            X = X.Modulo(World.Width - 1);
            Y += SizeInTiles * weight * Math.Cos(Rotation) * fractionElapsed;
            Y = Y.Modulo(World.Height - 1);
        }
        private void Rotate(double weight, double fractionElapsed)
        {
            TargetSize -= Math.Abs(weight - 0.5) * fractionElapsed;
            Rotation += (weight - 0.5) * Math.PI * fractionElapsed;
        }
        private Map.Field CurrentField()
        {
            return World.Fields[(int)Math.Round(CenterX)][(int)Math.Round(CenterY)];
        }
        private void Eat(double weight, double fractionElapsed)
        {
            if (weight > Excitability)
            {
                var toEat = SizeInTiles * 10 * fractionElapsed;
                TargetSize -= SizeInTiles * fractionElapsed;
                var eatenField = CurrentField();                
                lock (eatenField)
                {
                    if (eatenField.Calories > toEat)
                    {
                        eatenField.Calories -= toEat;
                        TargetSize += toEat;
                        if (TargetSize > 255)
                        {
                            TargetSize = 255;
                        }
                    }
                    else
                    {
                        TargetSize += eatenField.Calories;
                        eatenField.Calories = 0;
                    }
                }
            }
        }
        private Creature Split(double weight, double fractionElapsed)
        {
            Creature toReturn = null;
            if (weight > Excitability)
            {
                toReturn = new Creature(this);
                Size /= 2;
            }
            return toReturn;
        }
        private void CostOfLiving(double fractionElapsed)
        {
            var currentField = CurrentField();
            var heightCost = Math.Pow(Math.Abs(HeightAffinity - currentField.Height) / 255, 2);
            var temperatureCost = Math.Pow(Math.Abs(TemperatureAffinity - currentField.Temperature) / 255, 2);
            TargetSize -= (1 + heightCost + temperatureCost) * fractionElapsed;
        }
    }
}
