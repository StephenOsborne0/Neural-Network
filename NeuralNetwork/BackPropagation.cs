using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace NeuralNetwork
{
    public class BackPropagation
    {
        public static void BackPropagate(NeuralNetwork neuralNetwork, double expectedValue)
        {
            var layers = neuralNetwork.Layers;

            double globalErrorValue = 0;
            double outputDerivative = 0;

            for (var i = neuralNetwork.Layers.Count; i > 0; i--)
                foreach (var currentNeuron in neuralNetwork.Layers[i].Neurons)
                {
                    if (i == neuralNetwork.Layers.Count)
                    {
                        globalErrorValue = (expectedValue - currentNeuron.Output) * currentNeuron.OutputDerivative();
                        outputDerivative = currentNeuron.OutputDerivative();
                    }

                    foreach (var previousNeuron in neuralNetwork.Layers[i - 1].Neurons)
                    {
                        previousNeuron.Weight +=
                            currentNeuron.ErrorValue * previousNeuron.Output *
                            neuralNetwork.LearningRate;
                        previousNeuron.Bias = currentNeuron.ErrorValue;
                        previousNeuron.ErrorValue =
                            outputDerivative * globalErrorValue *
                            currentNeuron.Weight;
                    }
                }
        }
    }
}
