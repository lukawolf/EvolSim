using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvolSim.Map
{
    /// <summary>
    /// The simulation world representation
    /// </summary>
    public class World
    {
        protected const int maxCreatures = 1000;
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

        /// <summary>
        /// Constructs, but does not generate a world
        /// </summary>
        /// <param name="width">The wanted width</param>
        /// <param name="height">The wanted height</param>
        /// <param name="minCreatures">The minimal creatures that should inhabit this world. If there are less, random ones are added</param>
        public World(int width, int height, int minCreatures)
        {
            if (width < 0) throw new ArgumentException("Width must be greater than 0");
            if (height < 0) throw new ArgumentException("Height must be greater than 0");
            Width = width;
            Height = height;
            MinCreatures = minCreatures;
        }

        /// <summary>
        /// Blanks out the map and sets all tiles to the given height and temperature
        /// </summary>
        /// <param name="height">The height</param>
        /// <param name="temperature">The temperature</param>
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


        /// <summary>
        /// Generates the world using provided generator
        /// </summary>
        /// <param name="generator">The provided generator</param>
        /// <param name="progressBar">The progressbar to mark progress on</param>
        public void Generate(IMapGenerator generator, ProgressBar progressBar = null)
        {
            if (generator == null)
            {
                throw new ArgumentNullException("The generator can not be null!");
            }
            generator.Generate(this, progressBar);
        }

        /// <summary>
        /// Selects a field at the given coordinates
        /// </summary>
        /// <param name="x">Field X coordinate</param>
        /// <param name="y">Field Y coordinate</param>
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

        /// <summary>
        /// Updates the world
        /// </summary>
        /// <param name="fractionElapsed">A fraction of the simulation time</param>
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
                if (deadCreature == SelectedCreature)
                {
                    SelectedCreature = null;
                }
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
            //Old creatures over the max die
            for (int i = 0; i < Creatures.Count - maxCreatures; i++)
            {
                if (Creatures.Last.Value == SelectedCreature)
                {
                    SelectedCreature = null;
                }
                Creatures.RemoveLast();
            }
        }

        /// <summary>
        /// Registers a creature into the world
        /// </summary>
        /// <param name="creature">The creature</param>
        public void AddCreature(Creature.Creature creature)
        {
            Creatures.AddFirst(creature);
        }

        /// <summary>
        /// Selects a creature centered at a given set of coordinates
        /// </summary>
        /// <param name="x">The creature X</param>
        /// <param name="y">The creature Y</param>
        public void SelectCreature(int x, int y)
        {
            foreach(var creature in Creatures)
            {
                //We use hyper "extreme rounding" to catch the creature
                if ((creature.CenterX >= x - 1) && (creature.CenterX <= x + 1))
                {
                    if ((creature.CenterY >= y - 1) && (creature.CenterY <= y + 1))
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
