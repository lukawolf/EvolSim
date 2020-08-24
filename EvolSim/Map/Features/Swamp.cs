using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Map.Features
{
    class Swamp : Feature
    {
        public Swamp()
        {
        }

        protected Swamp(World world) : base(world)
        {
            canMoveMinusX = true;
            canMoveMinusY = true;
            canMovePlusX = true;
            canMovePlusY = true;
        }

        protected Swamp(World world, int x, int y, int intensity, int distance, bool canMovePlusX, bool canMoveMinusX, bool canMovePlusY, bool canMoveMinusY) : base(world, x, y, intensity, distance, canMovePlusX, canMoveMinusX, canMovePlusY, canMoveMinusY)
        {

        }

        public override IMapFeature CreateSelf(World world)
        {
            return new Swamp(world);
        }

        public override IMapFeature CreateSelf(World world, int x, int y, int intensity, int distance, bool canMovePlusX, bool canMoveMinusX, bool canMovePlusY, bool canMoveMinusY)
        {
            return new Swamp(world, x, y, intensity, distance, canMovePlusX, canMoveMinusX, canMovePlusY, canMoveMinusY);
        }

        protected override void EffectInternal()
        {
            world.Fields[x][y].Drop(-intensity, intensity);
        }
    }
}
