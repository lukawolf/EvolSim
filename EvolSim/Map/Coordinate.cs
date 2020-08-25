using System;

namespace EvolSim.Map
{
    /// <summary>
    /// A coordinate struct for usage in height map generator
    /// </summary>
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
