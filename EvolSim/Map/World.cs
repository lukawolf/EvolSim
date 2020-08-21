using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvolSim.Map
{
    public class World
    {        
        public enum GenerationType
        {
            CellularAutomata, 
            HeightMap,
            Gaia,
        }
        public Field[][] Fields { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Field SelectedField { get; private set; }
        public int SelectedFieldX { get; private set; }
        public int SelectedFieldY { get; private set; }

        public World(int width, int height)
        {
            if (width < 0) throw new ArgumentException("Width must be greater than 0");
            if (height < 0) throw new ArgumentException("Height must be greater than 0");
            Width = width;
            Height = height;
        }

        public void BlankMap(int height = 0, int temperature = 0)
        {
            Fields = new Field[Width][];
            for (int x = 0; x < Width; x++)
            {
                Fields[x] = new Field[Height];
                for (int y = 0; y < Height; y++)
                {
                    Fields[x][y] = new Field(height, temperature);
                }
            }
        }

        public void Generate(GenerationType generationType, ProgressBar progressBar, int? seed = null)
        {
            IMapGenerator generator = null;
            switch (generationType)
            {
                case GenerationType.CellularAutomata:
                    generator = new CellularAutomataGenerator();
                    generator.Generate(this, progressBar, seed);
                    break;
                case GenerationType.HeightMap:
                    generator = new HeightMapGenerator();
                    generator.Generate(this, progressBar, seed);
                    break;
                case GenerationType.Gaia:
                    BlankMap(126, 126);
                    progressBar.Value = 100;
                    break;
                default:
                    throw new ArgumentException("World generate generationType argument invalid");
            }
        }

        public void SelectField(int x, int y)
        {
            if (x < 0 || x >= this.Width)
            {
                throw new ArgumentOutOfRangeException("x is out of range");
            }
            if (y < 0 || y >= this.Width)
            {
                throw new ArgumentOutOfRangeException("y is out of range");
            }
            SelectedField = Fields[x][y];
            SelectedFieldX = x;
            SelectedFieldY = y;
        }

        public void Update(long timeElapsed)
        {            

        }
    }
}
