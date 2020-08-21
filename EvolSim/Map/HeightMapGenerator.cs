using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvolSim.Extensions;

namespace EvolSim.Map
{
    public class HeightMapGenerator: IMapGenerator
    {
        public const int AgitationRadius = 1;
        public const int AgitationDelta = 10;
        private Random random = new Random();
        public void Generate(World world, ProgressBar progressBar, int? seed)
        {
            world.BlankMap(0, 0);
            if (seed != null) random = new Random((int)seed);
            var passes = random.Next((world.Width + world.Height) / 2, (world.Width + world.Height));
            var toAgitate = new List<Coordinate>();
            //For a random ammount of passes
            for (int i = 0; i < passes; i++)
            {
                var drops = random.Next(1, (world.Width + world.Height));
                toAgitate.Clear();
                //Do a random ammount of drops based on the field size
                for (int j = 0; j < drops; j++)
                {
                    var x = random.Next(0, world.Width);
                    var y = random.Next(0, world.Height);
                    //Drop a random ammount of height and / or temperature particles on a given field
                    var doHeight = random.Next(0, 2);
                    var doTemp = random.Next(0, 2);
                    world.Fields[x][y].Drop(random.Next(64, 255) * doHeight, random.Next(64, 255) * doTemp);
                    toAgitate.Add(new Coordinate(x, y));
                }
                foreach (var item in toAgitate)
                {
                    AgitateDrop(world, item.x, item.y, random);
                }
                progressBar.Value = (i + 1) * 100 / passes;
            }
            progressBar.Value = 100;
        }

        private static void AgitateDrop(World world, int x, int y, Random random)
        {
            //We calculate the bounds around the agitated cell and trim them to fit the map
            var leftBound = x - AgitationRadius;
            if (leftBound < 0) leftBound = 0;
            var rightBound = x + AgitationRadius;
            if (rightBound >= world.Width) rightBound = world.Width - 1;
            var topBound = y - AgitationRadius;
            if (topBound < 0) topBound = 0;
            var bottomBound = y + AgitationRadius;
            if (bottomBound >= world.Height) bottomBound = world.Height - 1;

            //Then we construct a list of all the possible agitation targets
            var agitationTargets = new List<Coordinate>();
            for (int agitationX = leftBound; agitationX <= rightBound; agitationX++)
            {
                for (int agitationY = topBound; agitationY <= bottomBound; agitationY++)
                {
                    if (world.Fields[agitationX][agitationY].Height + AgitationDelta < world.Fields[x][y].Height
                        || world.Fields[agitationX][agitationY].InitialTemperature + AgitationDelta < world.Fields[x][y].InitialTemperature)
                    {
                        agitationTargets.Add(new Coordinate(agitationX, agitationY));
                    }
                }
            }

            //We repeat agitations while they make sense
            var didAgitate = false;
            do
            {
                didAgitate = false;
                foreach (var agitationTarget in agitationTargets)
                {
                    var dropHeight = 0;
                    if (world.Fields[x][y].Height - AgitationDelta > world.Fields[agitationTarget.x][agitationTarget.y].Height) dropHeight = 1;
                    var dropTemp = 0;
                    if (world.Fields[x][y].Temperature - AgitationDelta > world.Fields[agitationTarget.x][agitationTarget.y].Temperature) dropTemp = 1;

                    if (dropHeight > 0 || dropTemp > 0)
                    {
                        world.Fields[x][y].Drop(-dropHeight, -dropTemp);
                        world.Fields[agitationTarget.x][agitationTarget.y].Drop(dropHeight, dropTemp);
                        didAgitate = true;
                    }
                }
            } while (didAgitate);

            //In the end we agitate the targets, as their heights and temperatures have changed
            foreach (var agitationTarget in agitationTargets)
            {
                AgitateDrop(world, agitationTarget.x, agitationTarget.y, random);
            }
        }
    }
}
