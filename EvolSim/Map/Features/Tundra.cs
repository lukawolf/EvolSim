using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Map.Features
{
    class Tundra : Feature
    {
        public Tundra()
        {
        }

        public Tundra(Random random, World world) : base(random, world)
        {
            canMoveMinusX = true;
            canMoveMinusY = true;
            canMovePlusX = true;
            canMovePlusY = true;
        }

        protected Tundra(World world, Random random, int x, int y, int intensity, int distance, bool canMovePlusX, bool canMoveMinusX, bool canMovePlusY, bool canMoveMinusY) : base(world, random, x, y, intensity, distance, canMovePlusX, canMoveMinusX, canMovePlusY, canMoveMinusY)
        {

        }

        public override IMapFeature CreateSelf(Random random, World world)
        {
            return new Tundra(random, world);
        }

        public override IMapFeature CreateSelf(World world, Random random, int x, int y, int intensity, int distance, bool canMovePlusX, bool canMoveMinusX, bool canMovePlusY, bool canMoveMinusY)
        {
            return new Tundra(world, random, x, y, intensity, distance, canMovePlusX, canMoveMinusX, canMovePlusY, canMoveMinusY);
        }

        protected override void EffectInternal()
        {
            world.Fields[x][y].Drop(0, -intensity);
        }
    }
}
