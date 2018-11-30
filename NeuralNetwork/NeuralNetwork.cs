using System.Collections.Generic;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {
        public List<Layer> Layers { get; set; } = new List<Layer> ();
        public InputLayer InputLayer { get; set; } = new InputLayer ();
        public OutputLayer OutputLayer { get; set; } = new OutputLayer ();
        public bool BackPropagationEnabled { get; set; } = false;
        public double LearningRate { get; set; } = 1;
        public NetworkTypes NetworkType { get; set; }

        public NeuralNetwork()
        {

        }

        public enum NetworkTypes
        {
            SingleLayerPerceptron,
            MultiLayerPerceptron,
            RadialBasisFunction,
            KohonenSelfOrganizing,
            LongShortTermMemory,
            Recursive,
            Recurrent,
            Convolutional,
            Modular,
            Evolutionary,
        }

        public void Save(string filePath)
        {
            Serialization.Serialize<NeuralNetwork> (filePath, this);
        }

        public static NeuralNetwork Load(string filePath)
        {
            return Serialization.Deserialize<NeuralNetwork> (filePath);
        }
    }
}
