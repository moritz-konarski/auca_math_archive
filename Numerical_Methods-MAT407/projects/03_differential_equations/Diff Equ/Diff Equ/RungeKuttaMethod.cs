using System;
using ZedGraph;

namespace Diff_Equ
{
    class RungeKuttaMethod
    {
        #region Data
        private static PointPairList function = new PointPairList();
        private static double[] tValues;
        private static double tau, t_k, t_k1, u_k;
        private static double phi, epsilon, lambda;
        private static int problemNumber, numberOfSteps;
        #endregion

        //Private Constructor
        private RungeKuttaMethod() { }

        //Compute the first method
        protected internal static void ComputeFirstMethod()
        {
            function.Clear();
            SetInitialValue(problemNumber);
            Func<double, double, double, double, double> currFunc = Functions.GetProblemFunction(problemNumber);
            
            for (int k = 0; k < numberOfSteps; k++)
            {
                u_k = function[k].Y;
                
                t_k = tValues[k];

                t_k1 = tValues[k + 1];

                function.Add(t_k1, u_k + tau * currFunc(t_k, phi, epsilon, u_k));
            }
        }

        //Compute the second method
        protected internal static void ComputeSecondMethod()
        {
            function.Clear();
            SetInitialValue(problemNumber);
            Func<double, double, double, double, double> currFunc = Functions.GetProblemFunction(problemNumber);
            double y;

            for (int k = 0; k < numberOfSteps; k++)
            {
                u_k = function[k].Y;

                t_k = tValues[k];

                t_k1 = tValues[k + 1];

                y = u_k + tau * lambda * currFunc(t_k, phi, epsilon, u_k);

                function.Add(t_k1, u_k + tau * 
                    ((1.0 - 1.0 / (2.0 * lambda)) * currFunc(t_k, phi, epsilon, u_k) + 
                    1.0 / (2.0 * lambda) * currFunc(t_k + tau * lambda, phi, epsilon, y)));
            }
        }

        //Compute the third method
        protected internal static void ComputeThirdMethod()
        {
            double sigma = lambda;
            function.Clear();
            SetInitialValue(problemNumber);
            Func<double, double, double, double, double> currFunc = Functions.GetProblemFunction(problemNumber);
            double y_1, y_2;
            double tauFraction = 2.0 * tau / 3.0;
            double sigmaFrac = 1.0 / (8.0 * sigma);

            for (int k = 0; k < numberOfSteps; k++)
            {
                u_k = function[k].Y;

                t_k = tValues[k];

                t_k1 = tValues[k + 1];

                y_1 = u_k + tauFraction * currFunc(t_k, phi, epsilon, u_k);

                y_2 = u_k + tauFraction * 
                    ((1 - 3 * sigmaFrac) * currFunc(t_k, phi, epsilon, u_k) 
                    + (3 * sigmaFrac) * currFunc(t_k + tauFraction, phi, epsilon, y_1));

                function.Add(t_k1, u_k + tau * (
                    currFunc(t_k, phi, epsilon, u_k) / 4.0
                    + (3.0 / 4.0 - sigma) * currFunc(t_k + tauFraction, phi, epsilon, y_1)
                    + sigma * currFunc(t_k + tauFraction, phi, epsilon, y_2)));
            }
        }

        //set the initial value of the problem
        private static void SetInitialValue(int problemNumber)
        {
            switch(Functions.GetInitialValue(problemNumber))
            {
                case -1:
                    function.Add(0, phi);
                    break;
                default:
                    function.Add(0, Functions.GetInitialValue(problemNumber));
                    break;
            }
        }

        //get the resulting points
        protected internal static PointPairList GetResult()
        {
            return new PointPairList(function);
        }

        //set the parameters for the function
        protected internal static void SetParameters(int newProblemNumber, double newPhi, double newEpsilon, double newLambda)
        {
            problemNumber = newProblemNumber;
            epsilon = newEpsilon;
            lambda = newLambda;
            phi = newPhi;
        }

        //compute the intervals of t
        protected internal static void ComputeIntervals(double start, double end, int newNumberOfSteps)
        {
            numberOfSteps = newNumberOfSteps;
            tau = (end - start) / numberOfSteps;
            tValues = new double[numberOfSteps + 1];
            for (int k = 0; k <= numberOfSteps; k++)
            {
                tValues[k] = k * tau;
            }
        }

        //get a list of interval values for t
        protected internal static double[] GetTValues()
        {
            return tValues;
        }
    }
}
