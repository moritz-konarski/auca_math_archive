using System;
using System.Collections.Generic;

namespace Project_One
{
    // This class computes the x values of the interpolation nodes based on node type and number of nodes
    class Nodes : Data
    {
        private Nodes()
        {

        }

        #region ComputationOfNodes
        // Computes the nodes according to Chebyshev.
        internal protected static void ComputeChebyshevNodes()
        {
            List<double> nodes = new List<double>();
            int numberOfNodes = GetNumberOfNodes();

            for (int n = 1; n <= numberOfNodes; n++)
            {
                nodes.Add(0.5 + 0.5 * Math.Cos((2.0 * n - 1) / (2.0 * numberOfNodes) * Math.PI));
            }
            nodes.Sort();
            SetXOfNodes(nodes.ToArray());
        }

        // Computes normal nodes.
        internal protected static void ComputeNormalNodes()
        {
            int numberOfNodes = GetNumberOfNodes();
            SetXOfNodes(new double[numberOfNodes]);

            double nodeStep = 1.0 / (numberOfNodes - 1);
            double x = 0;

            for (int n = 0; n < numberOfNodes - 1; n++)
            {
                x = n * nodeStep;
                SetXOfNodes(n, x);
            }
            SetXOfNodes(numberOfNodes - 1, 1);
        }
        #endregion
    }
}
