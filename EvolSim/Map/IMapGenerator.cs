using System.Windows.Forms;

namespace EvolSim.Map
{
    interface IMapGenerator
    {
        void Generate(World world, ProgressBar progressBar, int? seed);
    }
}
