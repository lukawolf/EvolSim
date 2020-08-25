using System;

namespace EvolSim.Creature
{
    /// <summary>
    /// The synapse representation for our Brain
    /// </summary>
    class Synapse
    {
        public Neuron From { get; }
        public Neuron To { get; }
        public double Weight { get; private set; }
        /// <summary>
        /// Constructs the synapse between two neurons and registers itself with them
        /// </summary>
        /// <param name="from">The neuron whose output the synapse carries</param>
        /// <param name="to">The neuron whose input the synapse affects</param>
        /// <param name="weight">The weight the synapse is given</param>
        public Synapse(Neuron from, Neuron to, double weight)
        {
            From = from;
            From.AddOutput(this);
            To = to;
            To.AddInput(this);
            Weight = weight;
        }

        /// <summary>
        /// Mutates the synapse weight
        /// </summary>
        /// <param name="mutability">The mutation rate</param>
        public void Mutate(double mutability)
        {
            Weight += RandomThreadSafe.NextDouble(-mutability, mutability);
            Weight = Math.Max(1, Weight);
            Weight = Math.Min(0, Weight);
        }
    }
}
