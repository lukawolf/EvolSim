using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Creature
{
    class Neuron
    {
        //Linked lists because we delete elements often and do not want to restack a standard list
        protected LinkedList<Synapse> inputs = new LinkedList<Synapse>();
        protected LinkedList<Synapse> outputs = new LinkedList<Synapse>();
        public double Output { get; protected set; }
        protected double coeficient;
        public Neuron()
        {
            coeficient = RandomThreadSafe.NextDouble();
        }
        public Neuron(Neuron parent)
        {
            coeficient = parent.coeficient;
            Output = parent.Output;
        }
        public virtual void AddInput(Synapse synapse)
        {
            inputs.AddFirst(synapse);
        }
        public void AddOutput(Synapse synapse)
        {
            outputs.AddFirst(synapse);
        }
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
                AddOutput(newSynapse);
                possibleTarget.AddInput(newSynapse);
            }
        }
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
        public virtual void CalculateOutput()
        {
            Output = 0;
            foreach (var input in inputs)
            {
                Output += input.From.Output * input.Weight;
            }
            OutputTransform();
        }

        protected virtual void OutputTransform()
        {
            //Here we use sigmoid function
            Output = (1 / (1 + Math.Exp(-Output * coeficient)));
        }
    }
}
