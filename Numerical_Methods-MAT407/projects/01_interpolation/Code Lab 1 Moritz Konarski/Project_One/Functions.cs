using System;

namespace Project_One
{
    // This class coomputes the test functions and the y values of the node points
    class Functions : Data
    {
        // Constructor.
        private Functions()
        {

        }

        #region ComputeFunctions
        // Method to compute the function points.
        protected internal static void ComputeFunction()
        {
            ClearTestPoints();

            Func<double, double, double> currentFunction = GetTestFunction(GetProblemNumber());
            double epsilon = GetEpsilon();

            foreach (double x in GetXValues())
            {
                AddTestPoint(x, currentFunction(x, epsilon));
            }
        }

        // Method to compute the interpolation points or nodes.
        protected internal static void ComputeNodes()
        {
            ClearNodePoints();
            
            Func<double, double, double> currentFunction = GetTestFunction(GetProblemNumber());
            double epsilon = GetEpsilon();

            foreach (double x in GetXOfNodes())
            {
                AddNodePoint(x, currentFunction(x, epsilon));
            }
        }
        #endregion
    }
}
