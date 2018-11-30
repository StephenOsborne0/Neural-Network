using System.Collections.Generic;
using System.Drawing;

namespace NeuralNetwork
{
    public class NN_Convolutional : NeuralNetwork
    {
        public Bitmap InputImage { get; set; }
        public List<ConvolutionalLayer> ConvolutionalLayers { get; set; } = new List<ConvolutionalLayer> ();
        public bool ApplyEdgeDetection { get; set; }

        public NN_Convolutional()
        {

        }

        public NN_Convolutional(Bitmap image, int convolutionalLayerCount, int convolutionalNeuronCount, int outputCount,
            bool applyEdgeDetection)
        {
            NetworkType = NetworkTypes.Convolutional;

            InputImage = image;
            ApplyEdgeDetection = applyEdgeDetection;

            //Input
            var inputLayer = new ConvolutionalLayer ();

            for (var i = 0; i < image.Width; i++)
                for (var j = 0; j < image.Height; j++)
                {
                    inputLayer.InputPixels.Add (new ConvolutionalLayer.PixelInfo
                    {
                        Coordinates = new Point (i, j),
                        Color = image.GetPixel (i, j)
                    });
                }
            ConvolutionalLayers.Add(inputLayer);

            //Filters
            if (applyEdgeDetection)
                AddEdgeDetectionLayers ();

            //Output layers
            for (var i = 0; i < outputCount; i++)
                OutputLayer.Neurons.Add (new Neuron ());
        }

        public void AddEdgeDetectionLayers()
        {
            ConvolutionalLayers.Add (new ConvolutionalLayer
            {
                Filter = new ConvolutionalFilter
                {
                    Weights = ConvolutionalFilters.TopEdgeDetection
                }
            });
            ConvolutionalLayers.Add (new ConvolutionalLayer
            {
                Filter = new ConvolutionalFilter
                {
                    Weights = ConvolutionalFilters.BottomEdgeDetection
                }
            });
            ConvolutionalLayers.Add (new ConvolutionalLayer
            {
                Filter = new ConvolutionalFilter
                {
                    Weights = ConvolutionalFilters.LeftEdgeDetection
                }
            });
            ConvolutionalLayers.Add (new ConvolutionalLayer
            {
                Filter = new ConvolutionalFilter
                {
                    Weights = ConvolutionalFilters.RightEdgeDetection
                }
            });
        }

        public void FilterLayer()
        {
            foreach (var convolutionalLayer in ConvolutionalLayers)
                convolutionalLayer.ApplyFilter ();
        }

        public void Save(string filePath)
        {
            Serialization.Serialize<NN_Convolutional> (filePath, this);
        }

        public static NeuralNetwork Load(string filePath)
        {
            return Serialization.Deserialize<NN_Convolutional> (filePath);
        }
    }
}
