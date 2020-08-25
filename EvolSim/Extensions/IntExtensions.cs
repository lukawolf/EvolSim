namespace EvolSim.Extensions
{
    /// <summary>
    /// Extensions for int
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Calculates the modulo of int a % m
        /// </summary>
        /// <param name="a"></param>
        /// <param name="m"></param>
        /// <returns>The modulo</returns>
        public static int Modulo(this int a, int m)
        {
            return (a % m + m) % m;
        }
    }
}
