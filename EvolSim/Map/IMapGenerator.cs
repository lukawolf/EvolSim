using System.Windows.Forms;

namespace EvolSim.Map
{
    public interface IMapGenerator
    {
        void Generate(World world, ProgressBar progressBar = null);
    }
}
