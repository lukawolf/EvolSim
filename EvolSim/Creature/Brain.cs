﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Creature
{
    public class Brain
    {
        private double[] memory;
        public int InputWidth { get; }
        public int ThinkingWidth { get; }
        public int OutputWidth { get; }
        public int MemoryWidth { get; }
        private SensoryNeuron[] inputNeurons;
        private Neuron[] thinkingNeurons;
        private Neuron[] outputNeurons;
        private bool generated;
        public Brain(int inputWidth, int thinkingWidth, int outputWidth, int memoryWidth)
        {
            InputWidth = inputWidth;
            ThinkingWidth = thinkingWidth;
            OutputWidth = outputWidth;
            MemoryWidth = memoryWidth;

            inputNeurons = new SensoryNeuron[InputWidth + MemoryWidth];
            thinkingNeurons = new Neuron[ThinkingWidth];
            outputNeurons = new Neuron[InputWidth + MemoryWidth];
            memory = new double[MemoryWidth];
        }

        /// <summary>
        /// Thinks on the given inputs and returns outputs
        /// </summary>
        /// <param name="inputs">Thought input array</param>
        /// <returns>Thought output array</returns>
        public double[] Think(double[] inputs)
        {
            if (inputs.Length != InputWidth)
            {
                throw new ArgumentException("The input needs to be as wide as declared during construction!");
            }
            if (!generated)
            {
                GenerateRandom();
            }

            //Load inputs and memories
            for (int i = 0; i < inputNeurons.Length; i++)
            {
                if (i < InputWidth)
                {
                    inputNeurons[i].SetOutput(inputs[i]);
                }
                else
                {
                    inputNeurons[i].SetOutput(outputNeurons[OutputWidth + i - InputWidth].Output);
                }
            }
            //Calculate outputs of other neurons
            foreach (var neuron in thinkingNeurons)
            {
                neuron.CalculateOutput();
            }
            foreach (var neuron in outputNeurons)
            {
                neuron.CalculateOutput();
            }

            //Return the outputs of output neurons (sans memory neurons)
            var toReturn = new double[OutputWidth];
            for (int i = 0; i < OutputWidth; i++)
            {
                toReturn[i] = outputNeurons[i].Output;
            }
            return toReturn;
        }

        /// <summary>
        /// Generates a random brain
        /// </summary>
        public void GenerateRandom()
        {
            if (generated)
            {
                throw new InvalidOperationException("Brain already generated!");
            }
            for (int i = 0; i < inputNeurons.Length; i++)
            {
                inputNeurons[i] = new SensoryNeuron();
            }
            for (int i = 0; i < thinkingNeurons.Length; i++)
            {
                thinkingNeurons[i] = new Neuron();
            }
            for (int i = 0; i < outputNeurons.Length; i++)
            {
                outputNeurons[i] = new Neuron();
            }
            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = RandomThreadSafe.Next(-255, 255);
            }
            //Not the true max, as we do not limit multiple synapses between the same neurons, but it is the count of possible unique ones
            var MaxSynapsesBetweenLayers = inputNeurons.Length * thinkingNeurons.Length;
            for (int i = 0; i < RandomThreadSafe.Next(MaxSynapsesBetweenLayers); i++)
            {
                var fromIndex = RandomThreadSafe.Next(inputNeurons.Length);
                var toIndex = RandomThreadSafe.Next(thinkingNeurons.Length);
                var synapse = new Synapse(inputNeurons[fromIndex], thinkingNeurons[toIndex], RandomThreadSafe.NextDouble());
            }
            MaxSynapsesBetweenLayers = thinkingNeurons.Length * outputNeurons.Length;
            for (int i = 0; i < RandomThreadSafe.Next(MaxSynapsesBetweenLayers); i++)
            {
                var fromIndex = RandomThreadSafe.Next(thinkingNeurons.Length);
                var toIndex = RandomThreadSafe.Next(outputNeurons.Length);
                var synapse = new Synapse(thinkingNeurons[fromIndex], outputNeurons[toIndex], RandomThreadSafe.NextDouble());
            }
            generated = true;
        }

        /// <summary>
        /// Generates a brain from a parent brain using mutability for random changes
        /// </summary>
        /// <param name="parent">Parent brain</param>
        /// <param name="mutability">Mutability</param>
        public void GenerateFromBrain(Brain parent, double mutability)
        {
            if (generated)
            {
                throw new InvalidOperationException("Brain already generated!");
            }
            //Copy and mutate neurons while remembering target synapse neurons and synapse weight
            var inputNeuronTargetParameters = new Tuple<int, double>[InputWidth + MemoryWidth][];
            for (int i = 0; i < inputNeurons.Length; i++)
            {
                inputNeurons[i] = new SensoryNeuron(parent.inputNeurons[i]);
                inputNeuronTargetParameters[i] = parent.inputNeurons[i].OutputParameters(parent.thinkingNeurons);
                inputNeurons[i].Mutate(mutability);
            }
            var thinkingNeuronTargetParameters = new Tuple<int, double>[ThinkingWidth][];
            for (int i = 0; i < thinkingNeurons.Length; i++)
            {
                thinkingNeurons[i] = new Neuron(parent.thinkingNeurons[i]);
                thinkingNeuronTargetParameters[i] = parent.thinkingNeurons[i].OutputParameters(parent.outputNeurons);
                thinkingNeurons[i].Mutate(mutability);
            }
            for (int i = 0; i < outputNeurons.Length; i++)
            {
                outputNeurons[i] = new Neuron(parent.outputNeurons[i]);
                outputNeurons[i].Mutate(mutability);
            }
            //Copy and mutate synapses
            for (int i = 0; i < inputNeurons.Length; i++)
            {
                var x = 0;
                foreach (var targetParameters in inputNeuronTargetParameters[i])
                {
                    var copiedSynapse = new Synapse(inputNeurons[i], thinkingNeurons[targetParameters.Item1], targetParameters.Item2);
                    inputNeurons[i].AddOutput(copiedSynapse);
                    thinkingNeurons[targetParameters.Item1].AddInput(copiedSynapse);
                    x++;
                }
                inputNeurons[i].MutateSynapses(mutability, thinkingNeurons);
            }
            for (int i = 0; i < thinkingNeurons.Length; i++)
            {
                var x = 0;
                foreach (var targetParameters in thinkingNeuronTargetParameters[i])
                {
                    var copiedSynapse = new Synapse(inputNeurons[i], thinkingNeurons[targetParameters.Item1], targetParameters.Item2);
                    thinkingNeurons[i].AddOutput(copiedSynapse);
                    outputNeurons[targetParameters.Item1].AddInput(copiedSynapse);
                    x++;
                }
                thinkingNeurons[i].MutateSynapses(mutability, outputNeurons);
            }            
            generated = true;
        }
    }
}