using System;
using ZedGraph;

namespace Project_One
{
    // This class handles the interpolation of the function and computes the error of the interpolation
    class Interpolation : Data
    {
        // Constructor.
        private Interpolation()
        {
            
        }

        #region InterpolationFunctions
        // Compute the lagrange interpolation for the given type of nodes.
        protected internal static void ComputeLagrange()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            ClearInterpolationPoints();
            double partialResult;
            int numberOfNodes = GetNumberOfNodes();

            foreach (double x in GetXValues())
            {
                partialResult = 0;
                for (int k = 0; k < numberOfNodes; k++)
                {
                    PointPairList nodePoints = GetNodePoints();
                    double term = nodePoints[k].Y;
                    for (int i = 0; i < numberOfNodes; i++)
                    {
                        if (k != i)
                            term *= (x - nodePoints[i].X) / (nodePoints[k].X - nodePoints[i].X);
                    }
                    partialResult += term;
                }
                AddInterpolationPoint(x, partialResult);
            }
            watch.Stop();
            SetComputationTime(watch.ElapsedMilliseconds);
        }

        // Computes the error of the lagrange interpolation relative to the test function.
        protected internal static void ComputeError()
        {
            ClearErrorPoints();
            double maxError = 0;
            PointPairList interpolationPoints = GetInterpolationPoints();

            for (int i = 0; i < interpolationPoints.Count; i++)
            {
                AddErrorPoint(interpolationPoints[i].X, (GetTestPointY(i) - interpolationPoints[i].Y));
                maxError = (Math.Abs(GetErrorPointY(i)) > maxError) ? Math.Abs(GetErrorPointY(i)) : maxError ;
            }
            SetMaxError(maxError);
        }

        protected internal static void ComputeNeville()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // This algorithm is the result of inspiration by badjr on StackOverflow
            // https://stackoverflow.com/questions/14206013/nevilles-algorithm-in-c
            ClearInterpolationPoints();
            int numberOfNodes = GetNumberOfNodes();
            double[,] neville = new double[numberOfNodes, numberOfNodes];
            PointPairList nodePoints = GetNodePoints();

            for (int i = 0; i < numberOfNodes; i++)
            {
                neville[i, 0] = nodePoints[i].Y;
            }

            foreach (double x in GetXValues())
            {
                for (int i = 1; i < numberOfNodes; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        neville[i, j] = ((x - nodePoints[i - j].X) * neville[i, j - 1] - (x - nodePoints[i].X) * neville[i - 1, j - 1]) / (nodePoints[i].X - nodePoints[i - j].X);
                    }
                }
                AddInterpolationPoint(x, neville[numberOfNodes - 1, numberOfNodes - 1]);
            }

            watch.Stop();
            SetComputationTime(watch.ElapsedMilliseconds);
        }
        #endregion
    }
}
