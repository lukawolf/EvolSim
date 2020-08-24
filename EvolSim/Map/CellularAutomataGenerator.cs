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
        private List<IMapFeature> availableFeatures = new List<IMapFeature>();

        public CellularAutomataGenerator()
        {
            availableFeatures.Add(new Desert());
            availableFeatures.Add(new Glacier());
            availableFeatures.Add(new Lake());
            availableFeatures.Add(new Mountain());
            availableFeatures.Add(new River());
            availableFeatures.Add(new Swamp());
            availableFeatures.Add(new Tundra());
            availableFeatures.Add(new Volcano());
        }

        public void RegisterNewFeature(IMapFeature feature)
        {
            availableFeatures.Add(feature);
        }

        public void Generate(World world, ProgressBar progressBar)
        {
            progressBar.Value = 0;
            world.BlankMap(126, 126);
            var featureCount = RandomThreadSafe.Next((world.Width + world.Height) / 4, (world.Width + world.Height) * 2);
            var features = new List<IMapFeature>();
            for (int i = 0; i < featureCount; i++)
            {
                features.Add(availableFeatures[RandomThreadSafe.Next(0, availableFeatures.Count)].CreateSelf(world));
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
