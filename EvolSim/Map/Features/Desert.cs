using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Map.Features
{
    class Desert : Feature
    {
        public Desert()
        {
        }

        protected Desert(World world) : base(world)
        {
            canMoveMinusX = true;
            canMoveMinusY = true;
            canMovePlusX = true;
            canMovePlusY = true;
        }

        protected Desert(World world, int x, int y, int intensity, int distance, bool canMovePlusX, bool canMoveMinusX, bool canMovePlusY, bool canMoveMinusY) : base(world, x, y, intensity, distance, canMovePlusX, canMoveMinusX, canMovePlusY, canMoveMinusY)
        {

        }

        public override IMapFeature CreateSelf(World world)
        {
            return new Desert(world);
        }

        public override IMapFeature CreateSelf(World world, int x, int y, int intensity, int distance, bool canMovePlusX, bool canMoveMinusX, bool canMovePlusY, bool canMoveMinusY)
        {
            return new Desert(world, x, y, intensity, distance, canMovePlusX, canMoveMinusX, canMovePlusY, canMoveMinusY);
        }

        protected override void EffectInternal()
        {
            world.Fields[x][y].Drop(0, intensity);           
        }
    }
}
