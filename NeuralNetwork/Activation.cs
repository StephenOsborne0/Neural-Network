using System;

namespace NeuralNetwork
{
    public class Activation
    {
        public enum ActivationFunctions
        {
            Linear,
            Step,
            Sigmoid,
            Tanh,
            ArcTan,
            ReLU,
            PReLU,
            ELU,
            SoftPlus
        }

        public static double Linear(double x)
        {
            return x;
        }

        public static double LinearDerivative(double x)
        {
            return 1;
        }

        public static double Step(double x)
        {
            return x >= 0 ? 1 : -1;
        }

        public static double StepDerivative(double x)
        {
            //If true, should return something - either a 1 or 0
            return x == 0 ? x : 0;
        }

        public static double Tanh(double x)
        {
            return 2 / (1 + Math.Exp (-2 * x)) - 1;
        }

        public static double TanhDerivative(double x)
        {
            var s = Sigmoid (x);
            return 1 - Math.Pow (s, 2);
        }

        public static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp (-x));
        }

        public static double SigmoidDerivative(double x)
        {
            var s = Sigmoid (x);
            return s * (1 - s);
        }

        public static double ArcTan(double x)
        {
            return Math.Atan (x);
        }

        public static double ArcTanDerivative(double x)
        {
            return 1 / (Math.Pow (x, 2) + 1);
        }


        public static double ReLU(double x)
        {
            return x < 0 ? 0 : x;
        }

        public static double ReLUDerivative(double x)
        {
            return x < 0 ? 0 : 1;
        }

        public static double PReLU(double x)
        {
            const double a = 0.01;
            return x < 0 ? a * x : x;
        }

        public static double PReLUDerivative(double x)
        {
            const double a = 0.01;
            return x < 0 ? a : 1;
        }

        public static double ELU(double x)
        {
            const double a = 0.01;
            return x < 0 ? a * (Math.Exp (x) - 1) : x;
        }

        public static double ELUDerivative(double x)
        {
            const double a = 0.01;
            return x < 0 ? ELU (x) + a : 1;
        }

        public static double SoftPlus(double x)
        {
            return Math.Log (1 + Math.Exp (x));
        }

        public static double SoftPlusDerivative(double x)
        {
            return 1 / (1 + Math.Exp (-x));
        }

        public static double Normalise(double x, double minimum, double maximum)
        {
            return (x - minimum) / (maximum - minimum);
        }

        public static double Normalise(double x)
        {
            return Normalise (x, 0, 1);
        }
    }
}
