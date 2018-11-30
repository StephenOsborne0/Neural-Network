using System.Collections.Generic;

namespace NeuralNetwork
{
    public class NN_MultiLayerPerceptron : NeuralNetwork
    {
        public List<HiddenLayer> HiddenLayers { get; set; } = new List<HiddenLayer> ();

        public NN_MultiLayerPerceptron()
        {

        }

        public NN_MultiLayerPerceptron(int inputCount, int hiddenLayerCount, int hiddenNeuronCount, int outputCount)
        {
            NetworkType = NetworkTypes.MultiLayerPerceptron;
            for (var i = 0; i < inputCount; i++)
                InputLayer.Neurons.Add (new Neuron ());
            for (var i = 0; i < hiddenLayerCount; i++)
            {
                var hiddenLayer = new HiddenLayer ();
                for (var j = 0; j < hiddenNeuronCount; j++)
                    hiddenLayer.Neurons.Add (new Neuron ());
                HiddenLayers.Add (new HiddenLayer ());
            }
            for (var i = 0; i < outputCount; i++)
                OutputLayer.Neurons.Add (new Neuron ());
            Layers.Add (InputLayer);
            Layers.AddRange (HiddenLayers);
            Layers.Add (OutputLayer);
        }

        public void CalculateOutput()
        {
            foreach (var inputNeuron in InputLayer.Neurons)
            {
                inputNeuron.Input = Activation.Sigmoid (inputNeuron.Input);
                inputNeuron.Activate ();
            }

            for (var i = 0; i < HiddenLayers.Count; i++)
            {
                foreach (var currentLayerNeuron in HiddenLayers[i].Neurons)
                {
                    if (i == 0)
                        //Cross point between first hidden layer and input layer
                        foreach (var inputNeuron in InputLayer.Neurons)
                            currentLayerNeuron.Input += inputNeuron.Output;
                    else
                        foreach (var hiddenLayerNeuron in HiddenLayers[i - 1].Neurons)
                            currentLayerNeuron.Input += hiddenLayerNeuron.Output;
                    currentLayerNeuron.Activate ();
                }
            }

            foreach (var outputNeuron in OutputLayer.Neurons)
            {
                foreach (var hiddenLayerNeuron in HiddenLayers[HiddenLayers.Count - 1].Neurons)
                    outputNeuron.Input += hiddenLayerNeuron.Output;
                outputNeuron.Activate ();
            }
        }

        public void Save(string filePath)
        {
            Serialization.Serialize<NN_MultiLayerPerceptron> (filePath, this);
        }

        public static NeuralNetwork Load(string filePath)
        {
            return Serialization.Deserialize<NN_MultiLayerPerceptron> (filePath);
        }
    }
}
