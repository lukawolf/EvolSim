using System.Windows.Forms;

namespace EvolSim.Map
{
    /// <summary>
    /// The map generator interface
    /// </summary>
    public interface IMapGenerator
    {
        /// <summary>
        /// Generates the world displaying the progress on the progress bar
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="progressBar">The progress bar (defaults to null)</param>
        void Generate(World world, ProgressBar progressBar = null);
    }
}
