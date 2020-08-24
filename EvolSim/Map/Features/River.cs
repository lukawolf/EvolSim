using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Map.Features
{
    class River : Feature
    {
        public River()
        {
        }

        protected River(World world) : base(world)
        {
            var direction = RandomThreadSafe.Next(8);
            canMoveMinusX = false;
            canMoveMinusY = false;
            canMovePlusX = false;
            canMovePlusY = false;
            switch (direction)
            {
                case 0:
                    canMoveMinusX = true;
                    break;
                case 1:
                    canMoveMinusY = true;
                    break;
                case 2:
                    canMovePlusX = true;                    
                    break;
                case 3:
                    canMovePlusY = true;
                    break;
                case 4:
                    canMoveMinusX = true;
                    canMoveMinusY = true;
                    break;
                case 5:
                    canMoveMinusX = true;
                    canMovePlusY = true;
                    break;
                case 6:
                    canMovePlusX = true;
                    canMovePlusY = true;
                    break;
                case 7:
                    canMoveMinusY = true;
                    canMovePlusX = true;                    
                    break;
                default:
                    throw new IndexOutOfRangeException("Direction out of bounds");
            }
        }

        protected River(World world, int x, int y, int intensity, int distance, bool canMovePlusX, bool canMoveMinusX, bool canMovePlusY, bool canMoveMinusY) : base(world, x, y, intensity, distance, canMovePlusX, canMoveMinusX, canMovePlusY, canMoveMinusY)
        {

        }

        public override IMapFeature CreateSelf(World world)
        {
            return new River(world);
        }

        public override IMapFeature CreateSelf(World world, int x, int y, int intensity, int distance, bool canMovePlusX, bool canMoveMinusX, bool canMovePlusY, bool canMoveMinusY)
        {
            return new River(world, x, y, intensity, distance, canMovePlusX, canMoveMinusX, canMovePlusY, canMoveMinusY);
        }

        protected override void EffectInternal()
        {
            world.Fields[x][y].Drop(-intensity, 0);
        }

        protected override void EffectSpread()
        {
            var children = new List<IMapFeature>();
            if (canMoveMinusX)
            {
                if (!canMoveMinusY && !canMovePlusY)
                {
                    children.Add(CreateSelf(world, x - 1, y, intensity, distance - 1, false, true, false, false));
                }                
                if (canMoveMinusY)
                {
                    children.Add(CreateSelf(world, x - 1, y, intensity, 1, false, true, false, false));
                    children.Add(CreateSelf(world, x - 1, y - 1, intensity, distance - 1, false, true, false, true));
                }
                if (canMovePlusY)
                {
                    children.Add(CreateSelf(world, x - 1, y, intensity, 1, false, true, false, false));
                    children.Add(CreateSelf(world, x - 1, y + 1, intensity, distance - 1, false, true, false, true));
                }
            }
            if (canMovePlusX)
            {
                if (!canMoveMinusY && !canMovePlusY)
                {
                    children.Add(CreateSelf(world, x + 1, y, intensity, distance - 1, true, false, false, false));
                }                
                if (canMoveMinusY)
                {
                    children.Add(CreateSelf(world, x + 1, y, intensity, 1, true, false, false, false));
                    children.Add(CreateSelf(world, x + 1, y - 1, intensity, distance - 1, true, false, false, true));
                }
                if (canMovePlusY)
                {
                    children.Add(CreateSelf(world, x + 1, y, intensity, 1, true, false, false, false));
                    children.Add(CreateSelf(world, x + 1, y + 1, intensity, distance - 1, true, false, true, false));
                }
            }
            if (canMoveMinusY)
            {
                if (!canMovePlusX && !canMoveMinusX)
                {
                    children.Add(CreateSelf(world, x, y - 1, intensity, distance - 1, false, false, false, true));
                }
                else
                {
                    children.Add(CreateSelf(world, x, y - 1, intensity, 1, false, false, false, true));
                }
            }
            if (canMovePlusY)
            {
                if (!canMovePlusX && !canMoveMinusX)
                {
                    children.Add(CreateSelf(world, x, y + 1, intensity, distance - 1, false, false, true, false));
                }
                else
                {
                    children.Add(CreateSelf(world, x, y + 1, intensity, 1, false, false, true, false));
                }                
            }

            foreach (var child in children)
            {
                child.Effect();
            }
        }
    }
}
