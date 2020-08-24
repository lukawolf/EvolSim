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
        //LinkedList because we kill creatures often and also add new ones often. Also we do not seek creatures unless all need to be checked anyway
        public LinkedList<Creature.Creature> Creatures { get; private set; } = new LinkedList<Creature.Creature>();
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Field SelectedField { get; private set; }
        public int SelectedFieldX { get; private set; }
        public int SelectedFieldY { get; private set; }
        public int MinCreatures { get; set; }
        public Creature.Creature SelectedCreature { get; private set; }
        protected List<Creature.Creature> creaturesToDie = new List<Creature.Creature>();
        protected List<Creature.Creature> creaturesToBirth = new List<Creature.Creature>();

        public World(int width, int height, int minCreatures)
        {
            if (width < 0) throw new ArgumentException("Width must be greater than 0");
            if (height < 0) throw new ArgumentException("Height must be greater than 0");
            Width = width;
            Height = height;
            MinCreatures = minCreatures;
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

        public void Generate(GenerationType generationType, ProgressBar progressBar)
        {
            IMapGenerator generator = null;
            switch (generationType)
            {
                case GenerationType.CellularAutomata:
                    generator = new CellularAutomataGenerator();
                    generator.Generate(this, progressBar);
                    break;
                case GenerationType.HeightMap:
                    generator = new HeightMapGenerator();
                    generator.Generate(this, progressBar);
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

        public void Update(double fractionElapsed)
        {
            //All the fields grow
            Parallel.ForEach<Field[]>(Fields, column => {
                foreach (var field in column)
                {
                    field.GrowCalories(fractionElapsed);
                }
            });
            //Creatures update, if they split newborns are added and if they die, they are removed
            creaturesToDie.Clear();
            creaturesToBirth.Clear();
            Parallel.ForEach<Creature.Creature>(Creatures, creature =>
            {
                var newBorn = creature.Update(fractionElapsed);
                if (creature.ShouldDie())
                {
                    lock (creaturesToDie)
                    {
                        creaturesToDie.Add(creature);
                    }                    
                }
                else if (newBorn != null)
                {
                    lock (creaturesToBirth)
                    {
                        creaturesToBirth.Add(newBorn);
                    }
                }
            });
            foreach (var deadCreature in creaturesToDie)
            {
                Creatures.Remove(deadCreature);
            }
            foreach (var newBorn in creaturesToBirth)
            {
                Creatures.AddFirst(newBorn);
            }
            //New creatures replace the dead ones
            if (Creatures.Count < MinCreatures)
            {
                for (int i = 0; i < MinCreatures - Creatures.Count; i++)
                {
                    AddCreature(new Creature.Creature(this));
                }
            }
        }

        public void AddCreature(Creature.Creature creature)
        {
            Creatures.AddFirst(creature);
        }

        public void SelectCreature(int x, int y)
        {
            foreach(var creature in Creatures)
            {
                if (Math.Ceiling(creature.X) >= x && Math.Floor(creature.X) <= x)
                {
                    if (Math.Ceiling(creature.Y) >= y && Math.Floor(creature.Y) <= y)
                    {
                        SelectedCreature = creature;
                        return;
                    }
                }
            }
            SelectedCreature = null;
        }
    }
}
