using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Map
{
    /// <summary>
    /// The MapFeature interface
    /// </summary>
    public interface IMapFeature
    {
        /// <summary>
        /// Creates an instance of self in a given world
        /// </summary>
        /// <param name="world">The world</param>
        /// <returns>New instance of self</returns>
        IMapFeature CreateSelf(World world);
        /// <summary>
        /// Changes the world with its effect
        /// </summary>
        void Effect();
    }
}
