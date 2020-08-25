using System;
using System.Collections.Generic;

namespace EvolSim.Creature
{
    /// <summary>
    /// The neuron representation for our Brain
    /// </summary>
    class Neuron
    {
        //Linked lists because we delete elements often and do not want to restack a standard list
        protected LinkedList<Synapse> inputs = new LinkedList<Synapse>();
        protected LinkedList<Synapse> outputs = new LinkedList<Synapse>();
        public double Output { get; protected set; }
        protected double coeficient;
        /// <summary>
        /// Constructs a random neuron
        /// </summary>
        public Neuron()
        {
            coeficient = RandomThreadSafe.NextDouble();
        }
        /// <summary>
        /// Constructs a neuron from parent, still has no synapses through!
        /// </summary>
        /// <param name="parent">The parent</param>
        public Neuron(Neuron parent)
        {
            coeficient = parent.coeficient;
            Output = parent.Output;
        }
        /// <summary>
        /// Registers a synapse as input
        /// </summary>
        /// <param name="synapse">The input synapse</param>
        public virtual void AddInput(Synapse synapse)
        {
            inputs.AddFirst(synapse);
        }
        /// <summary>
        /// Registers a synapse as output
        /// </summary>
        /// <param name="synapse">The output synapse</param>
        public void AddOutput(Synapse synapse)
        {
            outputs.AddFirst(synapse);
        }
        /// <summary>
        /// Mutates the neuron's values
        /// </summary>
        /// <param name="mutability">The mutation rate</param>
        public void Mutate(double mutability)
        {            
            coeficient += RandomThreadSafe.NextDouble(-mutability, mutability);
            coeficient = Math.Max(1, coeficient);
            coeficient = Math.Min(0, coeficient);
            mutability += RandomThreadSafe.NextDouble(-mutability, mutability);
            mutability = Math.Max(1, mutability);
            mutability = Math.Min(0, mutability);
            foreach (var output in outputs)
            {
                output.Mutate(mutability);
            }
        }
        /// <summary>
        /// Mutates the neuron's synapses
        /// </summary>
        /// <param name="mutability">Mutation rate</param>
        /// <param name="targetNeurons">Possible neurons to connect new synapses to</param>
        public void MutateSynapses(double mutability, Neuron[] targetNeurons)
        {
            var synapsesToDie = new List<Synapse>();
            foreach (var synapse in outputs)
            {
                synapse.Mutate(mutability);
                if (RandomThreadSafe.NextDouble() < mutability)
                {
                    synapsesToDie.Add(synapse);
                }
            }
            foreach (var synapseToDie in synapsesToDie)
            {
                outputs.Remove(synapseToDie);
                synapseToDie.To.inputs.Remove(synapseToDie);
            }

            if (RandomThreadSafe.NextDouble() < mutability)
            {
                var possibleTarget = targetNeurons[RandomThreadSafe.Next(0, targetNeurons.Length)];
                var newSynapse = new Synapse(this, possibleTarget, RandomThreadSafe.NextDouble());
            }
        }

        /// <summary>
        /// Returns the output synapse parameters for the purpose of drawing or cloning them
        /// </summary>
        /// <param name="possibleTargets">Next neural layer to compare synapse targets against</param>
        /// <returns>Tuples of the target's index and the synapse's weight in this order</returns>
        public Tuple<int, double>[] OutputParameters(Neuron[] possibleTargets)
        {
            var toReturn = new List<Tuple<int, double>>();
            foreach (var outputSynapse in outputs)
            {
                for (int i = 0; i < possibleTargets.Length; i++)
                {
                    if (possibleTargets[i] == outputSynapse.To)
                    {
                        toReturn.Add(new Tuple<int, double>(i, outputSynapse.Weight));
                    }
                }
            }
            return toReturn.ToArray();
        }
        /// <summary>
        /// Calculates the neuron's output from its inputs
        /// </summary>
        public virtual void CalculateOutput()
        {
            Output = 0;
            foreach (var input in inputs)
            {
                Output += input.From.Output * input.Weight;
            }
            OutputTransform();
        }

        /// <summary>
        /// Transforms the neuron's output to be within 0 and 1 using a sigmoid function
        /// </summary>
        protected virtual void OutputTransform()
        {
            //Here we use sigmoid function
            Output = (1 / (1 + Math.Exp(-Output * coeficient)));
        }
    }
}
