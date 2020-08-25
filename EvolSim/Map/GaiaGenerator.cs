using System.Windows.Forms;

namespace EvolSim.Map
{
    /// <summary>
    /// The ideal world generator
    /// </summary>
    class GaiaGenerator : IMapGenerator
    {
        /// <summary>
        /// Generates a gaia in the world
        /// </summary>
        /// <param name="world"></param>
        /// <param name="progressBar"></param>
        public void Generate(World world, ProgressBar progressBar = null)
        {
            world.BlankMap(Field.IdealHeight, Field.IdealTemperature);
            if (progressBar != null) progressBar.Value = 100;
        }
    }
}
