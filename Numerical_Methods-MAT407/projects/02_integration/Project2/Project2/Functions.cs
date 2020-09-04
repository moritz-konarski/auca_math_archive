using System;
using System.Collections.Generic;
using ZedGraph;

/*This class handles the computation of the test function 
 * as well as all y values attained through the test function*/

namespace Project2
{
    class Functions
    {
        #region Data
        private const int computationSteps = 10000;
        private static readonly List<Func<double, double, double>> functionList = new List<Func<double, double, double>>(){
            {Func1},
            {Func2},
            {Func3},
            {Func4},
            {Func5},
            {Func6},
            {Func7},
            {Func8},
            {Func9},
            {Func10},
            {Func11},
            {Func12},
            {Func13},
            {Func14},
            {Func15},
            {Func16},
            {Func17},
            {Func18},
            {Func19},
            {Func20},
            {Func21},
            {Func22},
            {Func23},
            {Func24}
        };
        private static readonly List<double[]> limitList = new List<double[]>(){
            {new double[] {0, 2} },
            {new double[] {0, 1}},
            {new double[] {0, 1}},
            {new double[] {1, 2}},
            {new double[] {0, 2}},
            {new double[] {0, 0.99}},
            {new double[] {0, 1}},
            {new double[] {0, 1}},
            {new double[] {0, 2}},
            {new double[] {0, Math.PI / 4}},
            {new double[] {1, 3}},
            {new double[] {0, 1}},
            {new double[] {0, 1}},
            {new double[] {1, 2}},
            {new double[] {1, 3}},
            {new double[] {1, 3}},
            {new double[] {1, 2 * Math.PI}},
            {new double[] {1, 3}},
            {new double[] {0.01, 2}},
            {new double[] {0.01, 2}},
            {new double[] {0, 5}},
            {new double[] {0.01, 0.99}},
            {new double[] {0.01, 3}},
            {new double[] {0.01, 3}}
        };
        private static readonly List<double> valueList = new List<double>(){
            {-1},
            {0},
            {0},
            {Math.Log(2)},
            {Math.Atan(2)},
            {Math.Asin(0.99)},
            {Math.Sqrt(3)/2 + Math.PI/3},
            {2 - Math.Sqrt(3)},
            {2 * (Math.Sqrt(2) - 1)},
            {0.5 * Math.Log(2)},
            {3 * (Math.Log(3) - 1) + 1},
            {(Math.E - 1) / (1 + 4 * Math.Pow(Math.PI, 2))},
            {2 * Math.PI * (1 - Math.E) / (1 + 4 * Math.Pow(Math.PI, 2))},
            {0},
            {3.0 / 2.0 * (Math.Sin(Math.Log(3)) - Math.Cos(Math.Log(3)) + 1.0 / 3)},
            {3.0 / 2.0 * (Math.Sin(Math.Log(3)) + Math.Cos(Math.Log(3)) - 1.0 / 3)},
            {4 * Math.PI},
            {-1},
            {-1},
            {-1},
            {-1},
            {-1},
            {-1},
            {-1}
        };
        private static PointPairList nodesUniform = new PointPairList();
        private static PointPairList nodesV1 = new PointPairList();
        private static PointPairList nodesV2 = new PointPairList();
        private static PointPairList nodesTrapezoid = new PointPairList();
        private static PointPairList nodesSimpson = new PointPairList();
        private static PointPairList graphTestFunction = new PointPairList();
        private static PointPairList graphSimpson = new PointPairList();
        #endregion

        // Constructor.
        private Functions()
        {

        }

        #region Test Funtions
        #region 1-6
        // Problem 1.
        private static double Func1(double x, double parameter)
        {
            return Math.Pow(x, parameter);
        }
        // Problem 2.
        private static double Func2(double x, double parameter)
        {
            return Math.Cos(2 * Math.PI * x);
        }
        // Problem 3.
        private static double Func3(double x, double parameter)
        {
            return Math.Sin(2 * Math.PI * x);
        }
        // Problem 4.
        private static double Func4(double x, double parameter)
        {
            return 1 / x;
        }
        // Problem 5.
        private static double Func5(double x, double parameter)
        {
            return 1 / (1 + Math.Pow(x, 2));
        }
        // Problem 6.
        private static double Func6(double x, double parameter)
        {
            return 1 / Math.Sqrt(1 - Math.Pow(x, 2));
        }
        #endregion
        #region 7-20
        // Problem 7.
        private static double Func7(double x, double parameter)
        {
            return Math.Sqrt(4 - Math.Pow(x, 2));
        }
        // Problem 8.
        private static double Func8(double x, double parameter)
        {
            return x / Math.Sqrt(4 - Math.Pow(x, 2));
        }
        // Problem 9.
        private static double Func9(double x, double parameter)
        {
            return x / Math.Sqrt(4 + Math.Pow(x, 2));
        }
        // Problem 10.
        private static double Func10(double x, double parameter)
        {
            return Math.Tan(x);
        }
        // Problem 11.
        private static double Func11(double x, double parameter)
        {
            return Math.Log(x);
        }
        // Problem 12.
        private static double Func12(double x, double parameter)
        {
            return Math.Exp(x) * Math.Cos(2 * Math.PI * x);
        }
        // Problem 13.
        private static double Func13(double x, double parameter)
        {
            return Math.Exp(x) * Math.Sin(2 * Math.PI * x);
        }
        // Problem 14.
        private static double Func14(double x, double parameter)
        {
            return (2 * x - 3) / ((x + 2) * (5 - x));
        }
        // Problem 15.
        private static double Func15(double x, double parameter)
        {
            return Math.Sin(Math.Log(x));
        }
        // Problem 16.
        private static double Func16(double x, double parameter)
        {
            return Math.Cos(Math.Log(x));
        }
        // Problem 17.
        private static double Func17(double x, double parameter)
        {
            return Math.Pow(x, 2) * Math.Cos(x);
        }
        // Problem 18.
        private static double Func18(double x, double parameter)
        {
            return Math.Pow(parameter / x, 2) * Math.Sin(parameter / x);
        }
        // Problem 19.
        private static double Func19(double x, double parameter)
        {
            return Math.Sin(1 / x);
        }
        // Problem 20.
        private static double Func20(double x, double parameter)
        {
            return Math.Cos(1 / x);
        }
        #endregion
        #region 21-24
        // Problem 21.
        private static double Func21(double x, double parameter)
        {
            return Math.Exp(-Math.Pow(x, 2));
        }
        // Problem 22.
        private static double Func22(double x, double parameter)
        {
            return 1 / Math.Log(x);
        }
        // Problem 23.
        private static double Func23(double x, double parameter)
        {
            return Math.Sin(x) / x;
        }
        // Problem 24.
        private static double Func24(double x, double parameter)
        {
            return Math.Cos(x) / x;
        }
        #endregion
        #endregion

        #region Getters and Setters
        // Get the test function for the problem.
        protected internal static Func<double, double, double> GetTestFunction(int problemNumber)
        {
            return functionList[problemNumber];
        }
        // Get the value for a problem.
        protected internal static double GetValue(int problemNumber)
        {
            return valueList[problemNumber];
        }
        // Get the number of steps for any interval.
        protected internal static int GetComputationSteps()
        {
            return computationSteps;
        }
        // Get the limits of integration.
        protected internal static double[] GetLimits(int problemBumber)
        {
            return limitList[problemBumber];
        }
        // Get the PPL for the test Function.
        protected internal static PointPairList GetTestFunction()
        {
            return new PointPairList(graphTestFunction);
        }
        // Get the PPL for uniform nodes.
        protected internal static PointPairList GetNodesUniform()
        {
            return new PointPairList(nodesUniform);
        }
        // Get the PPL for nodes in version one.
        protected internal static PointPairList GetNodesV1()
        {
            return new PointPairList(nodesV1);
        }
        // Set the PPL for the nodes of version two.
        protected internal static void SetNodesV2(PointPairList nodes)
        {
            nodesV2 = nodes;
        }
        // Get the PPL for nodes of version two.
        protected internal static PointPairList GetNodesV2()
        {
            return new PointPairList(nodesV2);
        }
        // Set the PPL for simpson's rule nodes.
        protected internal static void SetNodesSimpson(PointPairList nodes)
        {
            nodesSimpson = nodes;
        }
        // Set the PPL for simpson's rule nodes.
        protected internal static PointPairList GetNodesSimpson()
        {
            return new PointPairList(nodesSimpson);
        }
        // Get the PPL for the graph of simpson's rule.
        protected internal static PointPairList GetSimpsonGraph()
        {
            return new PointPairList(graphSimpson);
        }
        // Set the PPL for trapezoidal rule.
        protected internal static void SetNodesTrapezoid(PointPairList nodes)
        {
            nodesTrapezoid = nodes;
        }
        // Get the PPL for trapezoidal nodes.
        protected internal static PointPairList GetNodesTrapezoid()
        {
            return new PointPairList(nodesTrapezoid);
        }
        // Get the vertical line of the lower limit.
        protected internal static PointPairList GetLowerLimit(int problemNumber)
        {
            double y = graphTestFunction[0].Y;
            double x = limitList[problemNumber][0];
            return new PointPairList { {x, 0}, {x, y} };
        }
        // Get the vertical line of the upper limit.
        protected internal static PointPairList GetUpperLimit(int problemNumber)
        {
            double y = graphTestFunction[graphTestFunction.Count - 1].Y;
            double x = limitList[problemNumber][1];
            return new PointPairList { { x, 0 }, { x, y } };
        }
        #endregion

        #region Functions
        // Compute the PPL for the test function.
        protected internal static void ComputeFunction(int problemNumber, double parameter)
        {
            Func<double, double, double> testFunction = functionList[problemNumber];
            graphTestFunction.Clear();
            foreach (double x in ComputeXValues(problemNumber))
            {
                graphTestFunction.Add(x, testFunction(x, parameter));
            }
        }

        // Compute the y values for uniform nodes.
        protected internal static void ComputeNodesUniform(int problemNumber, double parameter)
        {
            Func<double, double, double> testFunction = functionList[problemNumber];
            nodesUniform.Clear();
            double[] nodes = Nodes.GetUniformNodes();

            foreach (double x in nodes)
            {
                nodesUniform.Add(x, testFunction(x, parameter));
            }
        }

        // Compute y values for nodes for variant 1.
        protected internal static void ComputeNodesV1(int problemNumber, double parameter)
        {
            Func<double, double, double> testFunction = functionList[problemNumber];
            nodesV1.Clear();
            double[] nodes = Nodes.GetNodesV1();

            foreach (double x in nodes)
            {
                nodesV1.Add(x, testFunction(x, parameter));
            }
        }

        // Compute the graph for Simpson's method.
        protected internal static void ComputeSimpsonGraph(int problemNumber, int numberOfNodes, double parameter)
        {
            double[] limits = GetLimits(problemNumber);
            double h = (limits[1] - limits[0]) / computationSteps;
            Func<double, double, double> testFunction = functionList[problemNumber];
            double[] points = ComputeXValues(problemNumber);
            PointPairList nodes = GetNodesUniform();
            graphSimpson.Clear();
            double f_a, f_b, a, b, m;
            // Function for the Lagrange polynomial for simpson's method.
            double func(double x)
            {
                return f_a * ((x - m) * (x - b)) / ((a - m) * (a - b)) + 
                       testFunction(m, parameter) * ((x - a) * (x - b)) / ((m - a) * (m - b)) + 
                       f_b * ((x - a) * (x - m)) / ((b - a) * (b - m));
            }
            // Calculate the graph.
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                a = nodes[i].X;
                b = nodes[i + 1].X;
                m = (a + b) / 2;
                f_a = testFunction(a, parameter);
                f_b = testFunction(b, parameter);

                for (double x = a; x <= b; x += h)
                {
                    double result = func(x);
                    graphSimpson.Add(x, result);
                }
            }
        }

        // Compute the value of problem 1.
        protected internal static double ComputeValueP1(int problemNumber, double parameter)
        {
            return Math.Pow(2, parameter + 1) / (parameter + 1);
        }

        // Find x coordinates for computation based on the step size and interval.
        private static double[] ComputeXValues(int problemNumber)
        {
            double[] xValues = new double[computationSteps];
            double[] limits = GetLimits(problemNumber);
            double step = (limits[1] - limits[0]) / computationSteps;
            double x = limits[0];
            for (int n = 0; n < computationSteps; n++)
            {
                xValues[n] = x;
                x += step;
            }
            return xValues;
        }
        #endregion
    }
}
