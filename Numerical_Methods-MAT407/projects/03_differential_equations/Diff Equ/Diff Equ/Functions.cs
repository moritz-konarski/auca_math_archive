using System;
using System.Collections.Generic;
using ZedGraph;

namespace Diff_Equ
{
    class Functions
    {
        #region Data
        private static readonly int endValue = 1;
        private static readonly int startValue = 0;
        private static readonly double computationSteps = 1000;
        private static double phiParameter;
        private static double epsilonParameter;
        private static int problemNumber;
        private static PointPairList solutionPointPairList = new PointPairList();
        private static readonly List<Func<double, double, double, double>> solutionFunctionList = new List<Func<double, double, double, double>>()
        {
            { Solution_01 },
            { Solution_02 },
            { Solution_03 },
            { Solution_04 },
            { Solution_05 },
            { Solution_06 },
            { Solution_07 },
            { Solution_08 },
            { Solution_09 },
            { Solution_12_2 },
            { Solution_13_1 },
            { Solution_13_2 },
            { Solution_14 }
        };

        private static readonly List<Func<double, double, double, double, double>> problemFunctionList = new List<Func<double, double, double, double, double>>(){
            { Function_01 },
            { Function_02 },
            { Function_03 },
            { Function_04 },
            { Function_05 },
            { Function_06 },
            { Function_07 },
            { Function_08 },
            { Function_09 },
            { Function_12_2 },
            { Function_13_1 },
            { Function_13_2 },
            { Function_14 }
        };

        private static readonly List<double> initialValueList = new List<double>()
        {
            { 2 },
            { 2 },
            { -1 },
            { -1 },
            { 0 },
            { 0 },
            { 1 },
            { 0.5 },
            { -1 },
            { -0.1 },
            { 1 },
            { -2 },
            { -1 }
        };
        #endregion

        #region Solution Functions
        //Solution 01
        private static double Solution_01(double t, double phi, double epsilon)
        {
            return 2 / Math.Pow(1 + t, 2.0 / epsilon);
        }
        //Solution 02
        private static double Solution_02(double t, double phi, double epsilon)
        {
            return (2 + Math.Pow(t, 2) / (2 * epsilon)) * Math.Exp((-Math.Pow(t, 2)) / epsilon);
        }
        //Solution 03
        private static double Solution_03(double t, double phi, double epsilon)
        {
            return (phi + epsilon) * Math.Exp(-t / epsilon) + t - epsilon;
        }
        //Solution 04
        private static double Solution_04(double t, double phi, double epsilon)
        {
            return 1 + (phi - 1) * Math.Exp(-Math.Tan(Math.PI * t) / (Math.PI * epsilon));
        }
        //Solution 05
        private static double Solution_05(double t, double phi, double epsilon)
        {
            return Math.Sin(t / (epsilon * (2 - t)));
        }
        //Solution 06
        private static double Solution_06(double t, double phi, double epsilon)
        {
            return Math.Tan(t / (epsilon * (1 + t)));
        }
        //Solution 07
        private static double Solution_07(double t, double phi, double epsilon)
        {
            return 1 / (Math.Pow((2 / Math.Pow(1 - t, 1 / epsilon)) - 1, 1.0 / 3.0));
        }
        //Solution 08
        private static double Solution_08(double t, double phi, double epsilon)
        {
            return 1 / Math.Sqrt(1 + 3 * Math.Exp(Math.Pow(t, 2) / epsilon));
        }
        //Solution 09
        private static double Solution_09(double t, double phi, double epsilon)
        {
            return Math.Pow(1 - t, 1 / epsilon) / (1 / phi + 1 - Math.Pow(1 - t, 1 / epsilon));
        }
        //Solution 12.2
        private static double Solution_12_2(double t, double phi, double epsilon)
        {
            return 1 / (epsilon - t - (10 + epsilon) * Math.Exp(-t / epsilon));
        }
        //Solution 13.1
        private static double Solution_13_1(double t, double phi, double epsilon)
        {
            return (-1 + 4 * Math.Exp(-3 * t / epsilon)) / (1 + 2 * Math.Exp(-3 * t / epsilon));
        }
        //Solution 13.2
        private static double Solution_13_2(double t, double phi, double epsilon)
        {
            return -6 / (2 + Math.Exp(3 * t / epsilon));
        }
        //Solution 14
        private static double Solution_14(double t, double phi, double epsilon)
        {
            return Math.Sqrt((Math.Pow(phi, 2) - 1) * Math.Exp(Math.Sin(2 * Math.PI * t)) + 1);
        }
        #endregion

        #region Given Functions
        //Function 01
        private static double Function_01(double t, double phi, double epsilon, double u_k)
        {
            return -((2 * u_k) / (epsilon * t + epsilon));
        }
        //Function 02
        private static double Function_02(double t, double phi, double epsilon, double u_k)
        {
            return (t / epsilon) * (Math.Exp(-Math.Pow(t, 2) / epsilon) - 2 * u_k);
        }
        //Function 03
        private static double Function_03(double t, double phi, double epsilon, double u_k)
        {
            return (t - u_k) / epsilon;
        }
        //Function 04
        private static double Function_04(double t, double phi, double epsilon, double u_k)
        {
            return (1 - u_k) / (epsilon * Math.Pow(Math.Cos(Math.PI * t), 2));
        }
        //Function 05
        private static double Function_05(double t, double phi, double epsilon, double u_k)
        {
            //TODO: note that this is done to avoid crashing because of inaccuracies
            //if (Math.Pow(u_k, 2) >= 1)
            //{
            //    return 0;
            //}
            //else
            //{
            //return (2 * Math.Sqrt(Math.Abs(1 - Math.Pow(u_k, 2)))) / (epsilon * Math.Pow((2 - t), 2));
            //}
            return (2 * Math.Sqrt(1 - Math.Pow(u_k, 2))) / (epsilon * Math.Pow((2 - t), 2));
        }
        //Function 06
        private static double Function_06(double t, double phi, double epsilon, double u_k)
        {
            return (1 + Math.Pow(u_k, 2)) / (epsilon * Math.Pow((1 + t), 2));
        }
        //Function 07
        private static double Function_07(double t, double phi, double epsilon, double u_k)
        {
            return (Math.Pow(u_k, 4) + u_k) / (3 * epsilon * (t - 1));
        }
        //Function 08
        private static double Function_08(double t, double phi, double epsilon, double u_k)
        {
            return (t * (Math.Pow(u_k, 3) - u_k)) / epsilon;
        }
        //Function 09
        private static double Function_09(double t, double phi, double epsilon, double u_k)
        {
            return (u_k + Math.Pow(u_k, 2)) / (epsilon * (t - 1));
        }
        //Function 12.2
        private static double Function_12_2(double t, double phi, double epsilon, double u_k)
        {
            return (u_k + t * Math.Pow(u_k, 2)) / epsilon;
        }
        //Function 13.1
        private static double Function_13_1(double t, double phi, double epsilon, double u_k)
        {
            return ((u_k + 1) * (u_k - 2)) / epsilon;
        }
        //Function 13.2
        private static double Function_13_2(double t, double phi, double epsilon, double u_k)
        {
            return -(u_k * (u_k + 3)) / epsilon;
        }
        //Function 14
        private static double Function_14(double t, double phi, double epsilon, double u_k)
        {
            return (u_k - 1 / u_k) * Math.PI * Math.Cos(2 * Math.PI * t);
        }
        #endregion

        //Private Constructor
        private Functions() { }

        //Compute the graph for the given solution
        protected internal static void ComputeSolution()
        {
            double startValue = Functions.startValue + endValue / computationSteps;
            double step = endValue / computationSteps;
            Func<double, double, double, double> currFunc = solutionFunctionList[problemNumber];
            solutionPointPairList.Clear();
            for (double x = startValue; x <= endValue; x += step)
            {
                solutionPointPairList.Add(x, currFunc(x, phiParameter, epsilonParameter));
            }
        }

        #region Getters
        //Get the list of points of the solution
        protected internal static PointPairList GetSolutionPointPairList()
        {
            return new PointPairList(solutionPointPairList);
        }
        //Get the problem function 
        protected internal static Func<double, double, double, double, double> GetProblemFunction(int problemNumber)
        {
            return problemFunctionList[problemNumber];
        }
        //Get the solution function
        protected internal static Func<double, double, double, double> GetSolutionFunction(int problemNumber)
        {
            return solutionFunctionList[problemNumber];
        }
        //Get the initial value of the differential equation
        protected internal static double GetInitialValue(int problemNumber)
        {
            return initialValueList[problemNumber];
        }
        #endregion

        #region Setters
        //Set the parameters for the functions, so they are not passed every single time
        protected internal static void SetParameters(int newProblemNumber, double newPhi, double newEpsilon)
        {
            epsilonParameter = newEpsilon;
            phiParameter = newPhi;
            problemNumber = newProblemNumber;
        }
        #endregion
    }
}
