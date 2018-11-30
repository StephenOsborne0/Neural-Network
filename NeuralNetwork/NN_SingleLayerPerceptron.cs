namespace NeuralNetwork
{
    public class NN_SingleLayerPerceptron : NeuralNetwork
    {
        public NN_SingleLayerPerceptron()
        {

        }

        public NN_SingleLayerPerceptron(int inputCount, int outputCount)
        {
            NetworkType = NetworkTypes.SingleLayerPerceptron;

            for (var i = 0; i < inputCount; i++)
                InputLayer.Neurons.Add (new Neuron ());
            for (var i = 0; i < outputCount; i++)
                OutputLayer.Neurons.Add (new Neuron ());
            Layers.Add (InputLayer);
            Layers.Add (OutputLayer);
        }

        public void CalculateOutput()
        {
            foreach (var inputNeuron in InputLayer.Neurons)
            {
                inputNeuron.Input = Activation.Sigmoid (inputNeuron.Input);
                inputNeuron.Activate ();
            }

            foreach (var outputNeuron in OutputLayer.Neurons)
            {
                foreach (var inputNeuron in InputLayer.Neurons)
                    outputNeuron.Input += inputNeuron.Output;
                outputNeuron.Activate ();
            }
        }

        public void Save(string filePath)
        {
            Serialization.Serialize<NN_SingleLayerPerceptron> (filePath, this);
        }

        public static NeuralNetwork Load(string filePath)
        {
            return Serialization.Deserialize<NN_SingleLayerPerceptron> (filePath);
        }
    }
}
