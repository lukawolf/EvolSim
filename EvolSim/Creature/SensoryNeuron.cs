using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Creature
{
    class SensoryNeuron : Neuron
    {
        public SensoryNeuron() : base() { }
        public SensoryNeuron(Neuron neuron) : base(neuron) { }
        public override void AddInput(Synapse synapse)
        {
            throw new InvalidOperationException("Sensory neurons do not get neural inputs, use the SetOutput method");
        }

        public override void CalculateOutput()
        {
            throw new InvalidOperationException("Sensory neurons do not calculate outputs, use the SetOutput method");
        }

        public void SetOutput(double output)
        {
            Output = output;
        }
    }
}
