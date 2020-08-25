using System.Collections.Generic;
using System.Windows.Forms;
using EvolSim.Map.Features;

namespace EvolSim.Map
{
    /// <summary>
    /// A map generator that uses cellular automata to engrave a gaia world
    /// </summary>
    class CellularAutomataGenerator: IMapGenerator
    {
        private List<IMapFeature> availableFeatures = new List<IMapFeature>();

        /// <summary>
        /// Constructs the generator and registers the base features if not specified otherwise.
        /// </summary>
        /// <param name="registerBaseFeatures">Whether to register base features, defaults to true</param>
        public CellularAutomataGenerator(bool registerBaseFeatures = true)
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

        /// <summary>
        /// Used to register new external features
        /// </summary>
        /// <param name="feature">The feature to register for subsequent use</param>
        public void RegisterNewFeature(IMapFeature feature)
        {
            availableFeatures.Add(feature);
        }

        /// <summary>
        /// The world generation procedure
        /// </summary>
        /// <param name="world">The target world</param>
        /// <param name="progressBar">A progressBar instance to render progress upon</param>
        public void Generate(World world, ProgressBar progressBar = null)
        {
            progressBar.Value = 0;
            world.BlankMap(Field.IdealHeight, Field.IdealTemperature);
            var featureCount = RandomThreadSafe.Next((world.Width + world.Height) / 4, (world.Width + world.Height) * 2);
            var features = new List<IMapFeature>();
            for (int i = 0; i < featureCount; i++)
            {
                features.Add(availableFeatures[RandomThreadSafe.Next(0, availableFeatures.Count)].CreateSelf(world));
            }

            for (int i = 0; i < featureCount; i++)
            {
                features[i].Effect();
                if (progressBar != null) progressBar.Value = 100 * i / featureCount;
            }
            if(progressBar != null) progressBar.Value = 100;
        }
    }
}
