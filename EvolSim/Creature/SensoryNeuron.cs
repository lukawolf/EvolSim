using System;

namespace EvolSim.Creature
{
    /// <summary>
    /// A special neuron, which does not calculate its output and has no inputs. Its output is given from the senses (the brain thinking input)
    /// </summary>
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

        /// <summary>
        /// Sets the desired output value
        /// </summary>
        /// <param name="output">The desired value</param>
        public void SetOutput(double output)
        {
            if (output < 0 || output > 1)
            {
                throw new ArgumentException("Neural output is between 0 and 1");
            }
            Output = output;
        }
    }
}
