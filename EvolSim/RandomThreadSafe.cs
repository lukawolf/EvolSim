using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim
{
    /// <summary>
    /// ThreadSafe Random wrapper
    /// </summary>
    public class RandomThreadSafe
    {
        //The global random used to generate the ThreadStatic locals
        private static Random global = new Random();
        [ThreadStatic]
        private static Random local;

        /// <summary>
        /// Replaces the global random used for generating local seeds with one made based on the given seed.
        /// </summary>
        /// <param name="seed">The given global random seed</param>
        public static void SetSeed(int seed)
        {
            global = new Random(seed);
        }

        /// <summary>
        /// Ensures that our ThreadStatic RNG exists by checking it and generating a new one from the global Random if needed
        /// </summary>
        protected static void EnsureLocalExists()
        {
            if (local == null)
            {
                int seed;
                lock (global) seed = global.Next();
                local = new Random(seed);
            }
        }

        /// <summary>
        /// Gets the next random number for the current thread generating a thread-specific Random instance if neccessary.
        /// </summary>
        /// <returns>A cryptographically unsafe random integer</returns>
        public static int Next()
        {
            EnsureLocalExists();
            return local.Next();
        }

        /// <summary>
        /// Gets the next random number for the current thread generating a thread-specific Random instance if neccessary.
        /// </summary>
        /// <param name="max">The non-inclusive max return value</param>
        /// <returns>A cryptographically unsafe random non-negative integer below max</returns>
        public static int Next(int max)
        {
            EnsureLocalExists();
            return local.Next(max);
        }

        /// <summary>
        /// Gets the next random number for the current thread generating a thread-specific Random instance if neccessary.
        /// </summary>
        /// <param name="min">The inclusive lower bound</param>
        /// <param name="max">The exclusive upper bound</param>
        /// <returns>A cryptographically unsafe random non-negative integer within bounds</returns>
        public static int Next(int min, int max)
        {
            EnsureLocalExists();
            return local.Next(min, max);
        }

        /// <summary>
        /// Gets the next double between 0.0 and 1.0
        /// </summary>
        /// <returns></returns>
        public static double NextDouble()
        {
            EnsureLocalExists();
            return local.NextDouble();
        }

        /// <summary>
        /// Gets the next double between min and max
        /// </summary>
        /// <returns></returns>
        public static double NextDouble(double min, double max)
        {
            if (min > max)
            {
                throw new ArgumentException("Min can not be greater than max!");
            }
            return NextDouble() * (max - min) + min;
        }
    }
}
