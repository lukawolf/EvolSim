using System;
using System.Collections.Generic;

namespace EvolSim.Map.Features
{
    /// <summary>
    /// An abstract parent of all map features handling common functionality
    /// </summary>
    abstract class Feature: IMapFeature
    {
        //Whether the feature spreads in a given direction
        protected bool canMovePlusX;
        protected bool canMoveMinusX;
        protected bool canMovePlusY;
        protected bool canMoveMinusY;
        //The affected world
        protected World world;
        //Intensity serves to make larger changes, distance only limits spread
        protected int intensity;
        protected int distance;
        //The coordinates of the world field being affected
        protected int x;
        protected int y;
        //Whether the feature is a child
        protected bool isChild = false;
        /// <summary>
        /// Allows for construction of the feature to be used for its CreateSelf functionality
        /// </summary>
        public Feature()
        {

        }

        /// <summary>
        /// Allows for construction of the feature actually affecting the world. The constructed feature is fully randomised 
        /// </summary>
        /// <param name="world">The world to be affected</param>
        protected Feature(World world)
        {
            this.world = world;
            this.x = RandomThreadSafe.Next(0, world.Width);
            this.y = RandomThreadSafe.Next(0, world.Height);
            this.intensity = RandomThreadSafe.Next(1, 126);
            this.distance = RandomThreadSafe.Next(1, (this.world.Height + this.world.Width) / 4);
        }

        /// <summary>
        /// Constructs a feature based on the instructions from a parent
        /// </summary>
        /// <param name="world">The world to be affected</param>
        /// <param name="x">The affected tile X coordinate</param>
        /// <param name="y">The affected tile Y coordinate</param>
        /// <param name="intensity">The effect intensity</param>
        /// <param name="distance">The leftover distance to spread</param>
        /// <param name="canMovePlusX">Whether the effect can spread +x</param>
        /// <param name="canMoveMinusX">Whether the effect can spread -x</param>
        /// <param name="canMovePlusY">Whether the effect can spread +y</param>
        /// <param name="canMoveMinusY">Whether the effect can spread -y</param>
        protected Feature(World world, int x, int y, int intensity, int distance, bool canMovePlusX, bool canMoveMinusX, bool canMovePlusY, bool canMoveMinusY)
        {
            this.isChild = true;
            this.world = world;         
            this.x = x;
            this.y = y;
            this.intensity = intensity;
            this.distance = distance;
            this.canMovePlusX = canMovePlusX;
            this.canMoveMinusX = canMoveMinusX;
            this.canMovePlusY = canMovePlusY;
            this.canMoveMinusY = canMoveMinusY;
        }

        /// <summary>
        /// Creates a new instance of the feature's own type. Generates random starting position, intensity and distance
        /// </summary>
        /// <param name="world">The world to be affected by this feature</param>
        /// <returns></returns>
        public abstract IMapFeature CreateSelf(World world);

        /// <summary>
        /// Creates a new instance of the feature's own type using given starting parameters.
        /// </summary>
        /// <param name="world">The world to be affected by this feature</param>
        /// <param name="x">The X coordinate within the world</param>
        /// <param name="y">The Y coordinate within the world</param>
        /// <param name="intensity">The feature effect's intensity</param>
        /// <param name="distance">The remaining spread distance</param>
        /// <param name="canMovePlusX">Whether the effect can spread +x</param>
        /// <param name="canMoveMinusX">Whether the effect can spread -x</param>
        /// <param name="canMovePlusY">Whether the effect can spread +y</param>
        /// <param name="canMoveMinusY">Whether the effect can spread -y</param>
        /// <returns></returns>
        public abstract IMapFeature CreateSelf(World world, int x, int y, int intensity, int distance, bool canMovePlusX, bool canMoveMinusX, bool canMovePlusY, bool canMoveMinusY);

        /// <summary>
        /// Effects the instance's tile.
        /// </summary>
        public void Effect()
        {
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

        /// <summary>
        /// Handles the spread of the Feature instance's effect based on the allowed directions it can take
        /// </summary>
        protected virtual void EffectSpread()
        {
            //List of 8 possible ways is prepared, but filled only as needed
            var children = new List<IMapFeature>(8);
            if (canMoveMinusX)
            {
                children.Add(CreateSelf(world, x - 1, y, intensity - RandomThreadSafe.Next(1, intensity / 2 + 1), distance - RandomThreadSafe.Next(0, distance / 2 + 1), false, true, false, false));
                if (canMoveMinusY)
                {
                    children.Add(CreateSelf(world, x - 1, y - 1, intensity - RandomThreadSafe.Next(1, intensity / 2 + 1), distance - RandomThreadSafe.Next(0, distance / 2 + 1), false, true, false, true));
                }
                if (canMovePlusY)
                {
                    children.Add(CreateSelf(world, x - 1, y + 1, intensity - RandomThreadSafe.Next(1, intensity / 2 + 1), distance - RandomThreadSafe.Next(0, distance / 2 + 1), false, true, false, true));
                }
            }
            if (canMovePlusX)
            {
                children.Add(CreateSelf(world, x + 1, y, intensity - RandomThreadSafe.Next(1, intensity / 2 + 1), distance - RandomThreadSafe.Next(0, distance / 2 + 1), true, false, false, false));
                if (canMoveMinusY)
                {
                    children.Add(CreateSelf(world, x + 1, y - 1, intensity - RandomThreadSafe.Next(1, intensity / 2 + 1), distance - RandomThreadSafe.Next(0, distance / 2 + 1), true, false, false, true));
                }
                if (canMovePlusY)
                {
                    children.Add(CreateSelf(world, x + 1, y + 1, intensity - RandomThreadSafe.Next(1, intensity / 2 + 1), distance - RandomThreadSafe.Next(0, distance / 2 + 1), true, false, true, false));
                }
            }
            if (canMoveMinusY)
            {
                children.Add(CreateSelf(world, x, y - 1, intensity - RandomThreadSafe.Next(1, intensity / 2 + 1), distance - RandomThreadSafe.Next(0, distance / 2 + 1), false, false, false, true));
            }
            if (canMovePlusY)
            {
                children.Add(CreateSelf(world, x, y + 1, intensity - RandomThreadSafe.Next(1, intensity / 2 + 1), distance - RandomThreadSafe.Next(0, distance / 2 + 1), false, false, true, false));
            }

            foreach (var child in children)
            {
                child.Effect();
            }
        }
        /// <summary>
        /// Internal effect on the tile, each feature needs to decide this on its own
        /// </summary>
        protected abstract void EffectInternal();
    }
}
