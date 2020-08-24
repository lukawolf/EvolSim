using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Creature
{
    class Synapse
    {
        public Neuron From { get; }
        public Neuron To { get; }
        public double Weight { get; private set; }
        public Synapse(Neuron from, Neuron to, double weight)
        {
            From = from;
            From.AddOutput(this);
            To = to;
            To.AddInput(this);
            Weight = weight;
        }

        public void Mutate(double mutability)
        {
            Weight += RandomThreadSafe.NextDouble(-mutability, mutability);
            Weight = Math.Max(1, Weight);
            Weight = Math.Min(0, Weight);
        }
    }
}
