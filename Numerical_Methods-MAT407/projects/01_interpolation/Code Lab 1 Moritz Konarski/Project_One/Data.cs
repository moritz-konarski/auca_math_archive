using System;
using System.Collections.Generic;
using ZedGraph;

namespace Project_One
{ 
    // This class handles all the data the other classes use and keeps it in one place
    class Data
    {
        #region DataStructures
        // Variables.
        private static int numberOfNodes;
        private static int problemNumber;
        private static int typeOfMesh;
        private static long computationTime;
        private static bool shouldOptimize;
        private static double yMin;
        private static double yMax;
        private static double epsilon;
        private static double maxError;
        private static double givenError;
        private static double[] xOfNodes;
        private static PointPairList interpolationPoints;
        private static PointPairList nodePoints;
        private static PointPairList errorPoints;
        private static PointPairList testPoints;
        // Readonly/constant values.
        private const int loopStart = 0;
        private const int loopEnd = 1;
        private const double loopStep = 0.001;
        private const string xAxisTitle = "X Axis";
        private const string yAxisTitle = "Y Axis";
        private const string diagramTitle = "Lagrange Interpolation";
        private static readonly double[] xValues;
        private static readonly Dictionary<int, Func<double, double, double>> testFunctions = new Dictionary<int, Func<double, double, double>>()
        {
            {0, Func1},
            {1, Func2},
            {2, Func3},
            {3, Func4},
            {4, Func5},
            {5, Func6},
            {6, Func7},
            {7, Func8},
            {8, Func9},
            {9, Func10},
            {10, Func11},
            {11, Func12},
            {12, Func13},
            {13, Func14},
        };
        #endregion

        #region Functions
        // Problem 1.
        private static double Func1(double x, double epsilon)
        {
            return (1 - Math.Exp(-x / epsilon)) / (1 - Math.Exp(-1 / epsilon));
        }

        // Problem 2.
        private static double Func2(double x, double epsilon)
        {
            return 1 - (((Math.Exp(-x / Math.Sqrt(epsilon)) + Math.Exp((x - 1) / Math.Sqrt(epsilon))) / (1 + (Math.Exp(-1 / Math.Sqrt(epsilon))))));
        }

        // Problem 3.
        private static double Func3(double x, double epsilon)
        {
            return (((Math.Exp(-(1 - x) / epsilon) - Math.Exp(-1 / epsilon)) / (1 - (Math.Exp(-1 / epsilon)))));
        }

        // Problem 4.
        private static double Func4(double x, double epsilon)
        {
            return (Math.Log(1 + (x / epsilon)) / Math.Log(1 + (1 / epsilon)));
        }

        // Problem 5.
        private static double Func5(double x, double epsilon)
        {
            return Math.Cos((Math.PI * x) / epsilon);
        }

        // Problem 6.
        private static double Func6(double x, double epsilon)
        {
            return x * Math.Sin((Math.PI * x) / epsilon);
        }

        // Problem 7.
        private static double Func7(double x, double epsilon)
        {
            return (epsilon / (epsilon + Math.Pow((2 * x - 1), 2)));
        }

        // Problem 8.
        private static double Func8(double x, double epsilon)
        {
            if (x == 0)
                return 0;
            else
                return Math.Exp(-((1 - x) / (epsilon * x)));
        }

        // Problem 9.
        private static double Func9(double x, double epsilon)
        {
            if (x == 0)
                return 0;
            else
                return x * Math.Log(1 / x);
        }

        // Problem 10.
        private static double Func10(double x, double epsilon)
        {
            if (x <= 0.5)
                return (-2.0 / 3) * (Math.Exp((2 * x - 1) / epsilon) - 1) / (Math.Exp((2 * x - 1) / epsilon) + 1);
            else
                return (-2.0 / 3) * (1 - Math.Exp((1 - 2 * x) / epsilon)) / (1 + Math.Exp((1 - 2 * x) / epsilon));
        }

        // Problem 11.
        private static double Func11(double x, double epsilon)
        {
            if (x < 0.5 - epsilon)
                return 0.5;
            else if (x <= 0.5 + epsilon)
                return (1 - 2 * x) / (4 * epsilon);
            else
                return -0.5;
        }

        // Problem 12.
        private static double Func12(double x, double epsilon)
        {
            if (x < epsilon / 2)
                return 2 * x / epsilon;
            else if (x < 1 - epsilon / 2)
                return 1;
            else
                return 2 * (1 - x) / epsilon;
        }

        // Problem 13.
        private static double Func13(double x, double epsilon)
        {
            if (x <= (1 - epsilon) / 2)
                return 0;
            else if (x <= 0.5)
                return (2 * x - 1) / epsilon;
            else if (x <= (1 + epsilon) / 2)
                return (1 - 2 * x) / epsilon;
            else
                return 0;
        }

        // Problem 14.
        // The Dirac Delta function with epsilon as a
        private static double Func14(double x, double epsilon)
        {
            return (1)/(epsilon * Math.Sqrt(Math.PI)) * Math.Exp(-Math.Pow((x - 0.5) / epsilon, 2));
        }
        #endregion

        #region Getters And Setters
        // move this to functions.cs
        protected internal static Func<double, double, double> GetTestFunction(int problemNumber)
        {
            return testFunctions[problemNumber];
        }

        protected internal static double[] GetXValues()
        {
            return xValues;
        }

        //move to graphing
        protected internal static string GetDiagramTitle()
        {
            return diagramTitle;
        }
        //move to graphing
        protected internal static string GetXAxisTitle()
        {
            return xAxisTitle;
        }
        //move to graphing
        protected internal static string GetYAxisTitle()
        {
            return yAxisTitle;
        }

        protected internal static double GetMaxError()
        {
            return maxError;
        }

        protected internal static void SetMaxError(double value)
        {
            maxError = value;
        }

        protected internal static double GetGivenError()
        {
            return givenError;
        }

        protected internal static void SetGivenError(double value)
        {
            givenError = value;
        }

        protected internal static bool ShouldOptimize()
        {
            return shouldOptimize;
        }

        protected internal static void SetShouldOptimize(bool value)
        {
            shouldOptimize = value;
        }

        //move to functions.cs
        protected internal static double GetEpsilon()
        {
            return epsilon;
        }
        //move to functions.cs
        protected internal static void SetEpsilon(double value)
        {
            epsilon = value;
        }

        protected internal static int GetProblemNumber()
        {
            return problemNumber;
        }

        protected internal static void SetProblemNumber(int value)
        {
            problemNumber = value;
        }

        protected internal static int GetNumberOfNodes()
        {
            return numberOfNodes;
        }

        protected internal static void SetNumberOfNodes(int value)
        {
            numberOfNodes = value;
        }

        protected internal static int GetTypeOfMesh()
        {
            return typeOfMesh;
        }

        // move this to nodes.cs
        protected internal static void SetTypeOfMesh(int value)
        {
            typeOfMesh = value;
        }

        protected internal static double[] GetXOfNodes()
        {
            return xOfNodes;
        }

        protected internal static void SetXOfNodes(double [] value)
        {
            xOfNodes = value;
        }

        protected internal static void SetXOfNodes(int index, double value)
        {
            xOfNodes[index] = value;
        }

        protected internal static void ClearNodePoints()
        {
            nodePoints.Clear();
        }

        protected internal static void AddNodePoint(double x, double y)
        {
            nodePoints.Add(x, y);
        }

        protected internal static PointPairList GetNodePoints()
        {
            return new PointPairList(nodePoints);
        }

        protected internal static PointPairList GetInterpolationPoints()
        {
            return new PointPairList(interpolationPoints);
        }

        protected internal static void ClearInterpolationPoints()
        {
            interpolationPoints.Clear();
        }

        protected internal static void AddInterpolationPoint(double x, double y)
        {
            interpolationPoints.Add(x, y);
        }

        protected internal static PointPairList GetErrorPoints()
        {
            return new PointPairList(errorPoints);
        }

        protected internal static double GetErrorPointY(int index)
        {
            return errorPoints[index].Y;
        }

        protected internal static void ClearErrorPoints()
        {
            errorPoints.Clear();
        }

        protected internal static void AddErrorPoint(double x, double y)
        {
            errorPoints.Add(x, y);
        }

        protected internal static PointPairList GetTestPoints()
        {
            return new PointPairList(testPoints);
        }

        protected internal static double GetTestPointY(int index)
        {
            return testPoints[index].Y;
        }

        protected internal static void ClearTestPoints()
        {
            testPoints.Clear();
        }

        protected internal static void AddTestPoint(double x, double y)
        {
            testPoints.Add(x, y);
        }

        // move the rest to ybounds.cs
        protected internal static void SetYMin(double value)
        {
            yMin = value;
        }

        protected internal static double GetYMin()
        {
            return yMin;
        }

        protected internal static void SetYMax(double value)
        {
            yMax = value;
        }

        protected internal static double GetYMax()
        {
            return yMax;
        }

        protected internal static long GetComputationTime()
        {
            return computationTime;
        }

        protected internal static void SetComputationTime(long value)
        {
            computationTime = value;
        }
       
        #endregion

        static Data()
        {
            interpolationPoints = new PointPairList();
            nodePoints = new PointPairList();
            errorPoints = new PointPairList();
            testPoints = new PointPairList();
            maxError = 0;
            givenError = 1;
            yMin = 0;
            yMax = 0;
            List<double> list = new List<double>();
            for (double n = loopStart; n < loopEnd; n += loopStep)
                list.Add(n);
            xValues = list.ToArray();
        }
    }
}
