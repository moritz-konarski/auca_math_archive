using ZedGraph;

/*This class computes the definite integrals based on the nodes given as input.*/

namespace Project2
{
    class Integration
    {
        #region Data
        private static double h;
        #endregion

        // Constructor.
        private Integration()
        {

        }

        #region Integration Functions
        // Compute integral according to variation 1.
        protected internal static void ComputeV1(int problemNumber, int numberOfNodes)
        {
            UpdateH(problemNumber, numberOfNodes);
            ComputeValueRectanglesV1(Functions.GetNodesV1());
        }

        // Compute integral according to variation 2.
        protected internal static void ComputeV2(int problemNumber, int numberOfNodes)
        {
            UpdateH(problemNumber, numberOfNodes);
            ComputeValue(Functions.GetNodesV2());
        }

        // Compute integral according to trapezoid method.
        protected internal static void ComputeTrapezoids(int problemNumber, int numberOfNodes)
        {
            UpdateH(problemNumber, numberOfNodes);
            ComputeValue(Functions.GetNodesTrapezoid());
        }

        // Compute integral according to simpson's rule.
        protected internal static void ComputeSimpson(int problemNumber, int numberOfNodes)
        {
            UpdateH(problemNumber, numberOfNodes);
            ComputeValue(Functions.GetNodesSimpson());
        }
        #endregion

        #region Private Utility Functions
        // Update the interval step h based on problemNumber and number of nodes.
        private static void UpdateH(int problemNumber, int numberOfNodes)
        {
            double[] limits = Functions.GetLimits(problemNumber);
            h = (limits[1] - limits[0]) / (1.0 * numberOfNodes - 1);
        }

        // Compute the integral value for a function.
        private static void ComputeValue(PointPairList points)
        {
            Value = 0;
            for (int i = 0; i < points.Count - 1; i++)
            {
                Value += h * points[i].Y;
            }
        }
        
        // Compute the integral value for a function.
        private static void ComputeValueRectanglesV1(PointPairList points)
        {
            Value = 0;
            for (int i = 0; i < points.Count; i++)
            {
                Value += h * points[i].Y;
            }
        }

        // Get the value of the integral.
        protected internal static double Value { get; private set; }
        #endregion
    }
}
