using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Map.Features
{
    abstract class Feature: IMapFeature
    {
        protected bool canMovePlusX;
        protected bool canMoveMinusX;
        protected bool canMovePlusY;
        protected bool canMoveMinusY;
        protected Random random;
        protected World world;
        protected int intensity;
        protected int distance;
        protected int x;
        protected int y;
        protected bool isChild = false;
        public Feature()
        {

        }

        public Feature(Random random, World world)
        {
            this.random = random;
            this.world = world;
            this.x = this.random.Next(0, world.Width);
            this.y = this.random.Next(0, world.Height);
            this.intensity = this.random.Next(0, 126);
            this.distance = this.random.Next(0, (this.world.Height + this.world.Width) / 4);
        }

        protected Feature(World world, Random random, int x, int y, int intensity, int distance, bool canMovePlusX, bool canMoveMinusX, bool canMovePlusY, bool canMoveMinusY)
        {
            this.isChild = true;
            this.world = world;
            this.random = random;            
            this.x = x;
            this.y = y;
            this.intensity = intensity;
            this.distance = distance;
            this.canMovePlusX = canMovePlusX;
            this.canMoveMinusX = canMoveMinusX;
            this.canMovePlusY = canMovePlusY;
            this.canMoveMinusY = canMoveMinusY;
        }

        public abstract IMapFeature CreateSelf(Random random, World world);

        public abstract IMapFeature CreateSelf(World world, Random random, int x, int y, int intensity, int distance, bool canMovePlusX, bool canMoveMinusX, bool canMovePlusY, bool canMoveMinusY);

        public void Effect()
        {
            if (random == null)
            {
                throw new MethodAccessException("Can not run Effect method on a feature construted without random");
            }
            if (world == null)
            {
                throw new ArgumentNullException("world can not be null");
            }
            if (intensity < 1 || distance < 1)
            {
                return;
            }
            if (x < 0 || y < 0 || x >= world.Width || y >= world.Height)
            {
                return;
            }
            EffectInternal();
            EffectSpread();            
        }

        protected void EffectSpread()
        {
            var children = new List<IMapFeature>();
            if (canMoveMinusX)
            {
                children.Add(CreateSelf(world, random, x - 1, y, intensity - random.Next(0, intensity), distance - random.Next(0, distance), false, true, false, false));
                if (canMoveMinusY)
                {
                    children.Add(CreateSelf(world, random, x - 1, y - 1, intensity - random.Next(0, intensity), distance - random.Next(0, distance), false, true, false, true));
                }
                if (canMovePlusY)
                {
                    children.Add(CreateSelf(world, random, x - 1, y + 1, intensity - random.Next(0, intensity), distance - random.Next(0, distance), false, true, false, true));
                }
            }
            if (canMovePlusX)
            {
                children.Add(CreateSelf(world, random, x + 1, y, intensity - random.Next(0, intensity), distance - random.Next(0, distance), true, false, false, false));
                if (canMoveMinusY)
                {
                    children.Add(CreateSelf(world, random, x + 1, y - 1, intensity - random.Next(0, intensity), distance - random.Next(0, distance), true, false, false, true));
                }
                if (canMovePlusY)
                {
                    children.Add(CreateSelf(world, random, x + 1, y + 1, intensity - random.Next(0, intensity), distance - random.Next(0, distance), true, false, true, false));
                }
            }
            if (canMoveMinusY)
            {
                children.Add(CreateSelf(world, random, x, y - 1, intensity - random.Next(0, intensity), distance - random.Next(0, distance), false, false, false, true));
            }
            if (canMovePlusY)
            {
                children.Add(CreateSelf(world, random, x, y + 1, intensity - random.Next(0, intensity), distance - random.Next(0, distance), false, false, true, false));
            }

            foreach (var child in children)
            {
                child.Effect();
            }
        }

        protected abstract void EffectInternal();
    }
}
