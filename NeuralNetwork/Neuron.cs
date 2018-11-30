namespace NeuralNetwork
{
    public class Neuron
    {
        public double Input { get; set; }
        public double Weight { get; set; }
        public double Bias { get; set; } = 0;
        public double Output { get; set; }
        public double ErrorValue { get; set; }
        public static Activation.ActivationFunctions ActivationFunction { get; set; }

        public void Activate()
        {
            switch (ActivationFunction)
            {
                case Activation.ActivationFunctions.Linear:
                {
                    Output = Activation.Linear ((Input * Weight) + Bias);
                    break;
                }
                case Activation.ActivationFunctions.Step:
                {
                    Output = Activation.Step ((Input * Weight) + Bias);
                    break;
                }
                case Activation.ActivationFunctions.Sigmoid:
                {
                    Output = Activation.Sigmoid ((Input * Weight) + Bias);
                    break;
                }
                case Activation.ActivationFunctions.Tanh:
                {
                    Output = Activation.Tanh ((Input * Weight) + Bias);
                    break;
                }
                case Activation.ActivationFunctions.ArcTan:
                {
                    Output = Activation.ArcTan ((Input * Weight) + Bias);
                    break;
                }
                case Activation.ActivationFunctions.ReLU:
                {
                    Output = Activation.ReLU ((Input * Weight) + Bias);
                    break;
                }
                case Activation.ActivationFunctions.PReLU:
                {
                    Output = Activation.PReLU ((Input * Weight) + Bias);
                    break;
                }
                case Activation.ActivationFunctions.ELU:
                {
                    Output = Activation.ELU ((Input * Weight) + Bias);
                    break;
                }
                case Activation.ActivationFunctions.SoftPlus:
                {
                    Output = Activation.SoftPlus ((Input * Weight) + Bias);
                    break;
                }
            }
        }

        public double OutputDerivative()
        {
            switch (ActivationFunction)
            {
                case Activation.ActivationFunctions.Linear:
                {
                    return Activation.LinearDerivative (Output);
                }
                case Activation.ActivationFunctions.Step:
                {
                    return Activation.StepDerivative (Output);
                }
                case Activation.ActivationFunctions.Sigmoid:
                {
                    return Activation.SigmoidDerivative (Output);
                }
                case Activation.ActivationFunctions.Tanh:
                {
                    return Activation.TanhDerivative (Output);
                }
                case Activation.ActivationFunctions.ArcTan:
                {
                    return Activation.ArcTanDerivative (Output);
                }
                case Activation.ActivationFunctions.ReLU:
                {
                    return Activation.ReLUDerivative (Output);
                }
                case Activation.ActivationFunctions.PReLU:
                {
                    return Activation.PReLUDerivative (Output);
                }
                case Activation.ActivationFunctions.ELU:
                {
                    return Activation.ELUDerivative (Output);
                }
                case Activation.ActivationFunctions.SoftPlus:
                {
                    return Activation.SoftPlusDerivative (Output);
                }
                default:
                return 0;
            }
        }
    }
}
