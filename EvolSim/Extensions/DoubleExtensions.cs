namespace EvolSim.Extensions
{
    /// <summary>
    /// Extensions for double
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Calculates the modulo of double a % m
        /// </summary>
        /// <param name="a"></param>
        /// <param name="m"></param>
        /// <returns>The modulo</returns>
        public static double Modulo(this double a, double m)
        {
            return (a % m + m) % m;
        }
    }
}
