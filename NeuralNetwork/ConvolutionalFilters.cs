namespace NeuralNetwork
{
    public class ConvolutionalFilters
    {
        internal static int[] LeftEdgeDetection { get; } = new int[9]
        {
            1, 0, -1,
            1, 0, -1,
            1, 0, -1
        };

        internal static int[] RightEdgeDetection { get; } = new int[9]
        {
            -1, 0, 1,
            -1, 0, 1,
            -1, 0, 1
        };

        internal static int[] TopEdgeDetection { get; } = new int[9]
        {
            1, 1, 1,
            0, 0, 0,
            -1, -1, -1
        };

        internal static int[] BottomEdgeDetection { get; } = new int[9]
        {
            -1, -1, -1,
            0, 0, 0,
            1, 1, 1
        };
    }
}
