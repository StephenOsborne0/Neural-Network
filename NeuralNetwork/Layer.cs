using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace NeuralNetwork
{
    public class Layer
    {
        public List<Neuron> Neurons { get; set; } = new List<Neuron> ();
    }

    public class InputLayer : Layer
    {

    }

    public class OutputLayer : Layer
    {

    }

    public class HiddenLayer : Layer
    {

    }

    public class ConvolutionalLayer : Layer
    {
        public List<PixelInfo> InputPixels { get; set; }
        public int[] OutputPixels { get; set; }
        public List<int[]> CachedValues { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public ConvolutionalFilter Filter = new ConvolutionalFilter ();

        public void ApplyFilter()
        {
            for (var i = 0; i < InputPixels.Count; i++)
            {
                //Get X/Y coordinate of pixel
                var x = i % ImageWidth;
                var y = i / ImageWidth;

                //If grid fits on image
                if (x + Filter.Width > ImageWidth ||
                    y + Filter.Height > ImageHeight)
                    continue;

                //For the entire filter, cache weight and color of pixel as int
                for (var j = 0; j < Filter.Weights[0].Length; j += Filter.Width)
                    for (var k = 0; k < Filter.Width; k++)
                        CachedValues.Add (new int[]
                        {
                            Filter.Weights[0][j + k],
                            Filter.Weights[1][j + k],
                            Filter.Weights[2][j + k],
                            InputPixels[i + k + ((j / Filter.Width) * ImageWidth)].Color.R,
                            InputPixels[i + k + ((j / Filter.Width) * ImageWidth)].Color.G,
                            InputPixels[i + k + ((j / Filter.Width) * ImageWidth)].Color.B
                        });

                //ReLU
                var output = new List<double>();
                foreach (var cachedValue in CachedValues)
                    output.Add(Activation.ReLU(cachedValue[0] * cachedValue[1]));

                //Pooling
                for (var j = 0; j < Filter.Weights.Length; j += Filter.Width)
                for (var k = 0; k < Filter.Width; k++)
                    Console.WriteLine();
            }
        }

        public class PixelInfo
        {
            public Point Coordinates;
            public Color Color;
        }
    }



    public class ConvolutionalFilter
    {
        //The size of the filter
        public int Width = 3;
        public int Height = 3;

        //How far the filter shifts per iteration
        public int Stride = 1;

        public int[][] Weights;
    }
}

