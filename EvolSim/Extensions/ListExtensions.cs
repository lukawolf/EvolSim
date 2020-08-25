using System.Collections.Generic;

namespace EvolSim.Extensions
{
    /// <summary>
    /// Extensions for List
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// An in-place shuffling method for any list
        /// </summary>
        /// <typeparam name="T">The type contained within our list</typeparam>
        /// <param name="list">The list to be shuffled</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = RandomThreadSafe.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
