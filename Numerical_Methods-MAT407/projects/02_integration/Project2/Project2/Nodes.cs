using System;
using ZedGraph;

/*This class computes the nodes of the integration variant*/

namespace Project2
{
    class Nodes
    {
        #region Data
        private static double[] nodesUniform;
        private static double[] nodesV1;
        #endregion

        // Constructor.
        private Nodes()
        {

        }

        #region Functions
        // Compute nodes for uniform mesh.
        private static void ComputeNodesUniform(int problemNumber, int numberOfNodes, double parameter)
        {
            nodesUniform = new double[numberOfNodes];
            double[] limits = Functions.GetLimits(problemNumber);
            double a = limits[0];
            double h = (limits[1] - limits[0]) / (1.0 * numberOfNodes - 1);

            for (int n = 0; n < numberOfNodes - 1; n++)
            {
                nodesUniform[n] = a + h * n;
            }
            nodesUniform[numberOfNodes - 1] = limits[1];
            Functions.ComputeNodesUniform(problemNumber, parameter);
        }
       
        // Change uniform nodes according to theta in version 1.
        protected internal static void ComputeNodesV1(int problemNumber, int numberOfNodes, double theta, double parameter)
        {
            ComputeNodesUniform(problemNumber, numberOfNodes, parameter);
            nodesV1 = new double[numberOfNodes - 1];
            for (int n = 0; n < numberOfNodes - 1; n++)
            {
                nodesV1[n] = theta * nodesUniform[n + 1] + (1 - theta) * nodesUniform[n];
            }
            Functions.ComputeNodesV1(problemNumber, parameter);
        }

        // Change uniform nodes according to theta in version 2.
        protected internal static void ComputeNodesV2(int problemNumber, int numberOfNodes, double theta, double parameter)
        {
            ComputeNodesUniform(problemNumber, numberOfNodes, parameter);
            PointPairList nodes = Functions.GetNodesUniform();
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                nodes[i].Y = (1 - theta) * nodes[i].Y + theta * nodes[i + 1].Y;
            }
            Functions.SetNodesV2(nodes);
        }

        // Change uniform nodes for trapezia.
        protected internal static void ComputeNodesTrapezoid(int problemNumber, int numberOfNodes, double parameter)
        {
            ComputeNodesUniform(problemNumber, numberOfNodes, parameter);
            PointPairList nodes = Functions.GetNodesUniform();
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                nodes[i].Y = (nodes[i].Y + nodes[i + 1].Y) / 2.0;
            }
            Functions.SetNodesTrapezoid(nodes);
        }

        // Change uniform nodes for simpsons method.
        protected internal static void ComputeNodesSimpson(int problemNumber, int numberOfNodes, double parameter)
        {
            ComputeNodesUniform(problemNumber, numberOfNodes, parameter);
            PointPairList nodes = Functions.GetNodesUniform();
            Func<double, double, double> func = Functions.GetTestFunction(problemNumber);

            for (int i = 0; i < nodes.Count - 1; i++)
            {
                nodes[i].Y = ((nodes[i].Y + nodes[i + 1].Y + 4 * func((nodes[i].X + nodes[i + 1].X) / 2, parameter)) / 6.0);
            }
            Functions.SetNodesSimpson(nodes);
        }
        #endregion

        #region Getters
        // Get Uniform Nodes
        protected internal static double[] GetUniformNodes()
        {
            return nodesUniform;
        }

        // Get nodes for version 1.
        protected internal static double[] GetNodesV1()
        {
            return nodesV1;
        }
        #endregion
    }
}
