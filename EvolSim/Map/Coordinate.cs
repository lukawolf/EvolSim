using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Map
{
    public struct Coordinate
    {
        public readonly int x;
        public readonly int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coordinate Rotate(double direction)
        {
            return new Coordinate((int)Math.Floor(x * Math.Cos(direction) - y * Math.Sin(direction)), (int)Math.Floor(x * Math.Sin(direction) + y * Math.Cos(direction)));
        }
    }
}
