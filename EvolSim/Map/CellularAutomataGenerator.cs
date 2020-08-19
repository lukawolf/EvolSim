using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvolSim.Map.Features;

namespace EvolSim.Map
{
    class CellularAutomataGenerator: IMapGenerator
    {
        private Random random = new Random();
        private List<IMapFeature> availableFeatures = new List<IMapFeature>();

        public CellularAutomataGenerator()
        {
            availableFeatures.Add(new Desert());
            availableFeatures.Add(new Glacier());
            availableFeatures.Add(new Lake());
            availableFeatures.Add(new Mountain());
            //availableFeatures.Add(new River());
            availableFeatures.Add(new Swamp());
            availableFeatures.Add(new Tundra());
            availableFeatures.Add(new Volcano());
        }

        public void Generate(World world, ProgressBar progressBar, int? seed)
        {
            progressBar.Value = 0;
            if (seed != null) random = new Random((int)seed);
            world.BlankMap(126, 126);
            var featureCount = random.Next((world.Width + world.Height) / 4, (world.Width + world.Height) * 2);
            var features = new List<IMapFeature>();
            for (int i = 0; i < featureCount; i++)
            {
                features.Add(availableFeatures[random.Next(0, availableFeatures.Count)].CreateSelf(random, world));
            }

            for (int i = 0; i < featureCount; i++)
            {
                features[i].Effect();
                progressBar.Value = 100 * i / featureCount;
            }
            progressBar.Value = 100;
        }
    }
}
