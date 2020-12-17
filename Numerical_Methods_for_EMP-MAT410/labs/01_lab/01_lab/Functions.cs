using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using ZedGraph;

namespace _01_lab
{
    class Functions
    {
        #region Data
        private static readonly float startValue = 0;
        private static readonly float endValue = 1;
        private static readonly int computationSteps = 10000;
        private static float phi0;
        private static float phi1;
        private static float epsilon;
        private static int problemNumber;
        private static readonly PointPairList solutionPointPairList = new PointPairList();

        // constants for bvp 1
        private static readonly double para_bvp_1_zeta_0 = 1.0;
        private static readonly double para_bvp_1_zeta_1 = 1.0;
        private static readonly double para_bvp_1_eta_0 = 0.0;
        private static readonly double para_bvp_1_eta_1 = 0.0;

        // constants for bvp 2
        private static readonly double para_bvp_2_zeta_0 = 1.0;
        private static readonly double para_bvp_2_zeta_1 = 1.0;
        private static readonly double para_bvp_2_eta_0 = 1.0;
        private static readonly double para_bvp_2_eta_1 = 0.0;

        // constants for problem 2
        private static readonly double para_2_zeta_0 = 1.0;
        private static readonly double para_2_zeta_1 = 1.0;
        private static readonly double para_2_eta_0 = 0.0;
        private static readonly double para_2_eta_1 = 0.0;

        // constants for problem 3
        private static readonly double para_3_zeta_0 = 1.0;
        private static readonly double para_3_zeta_1 = 1.0;
        private static readonly double para_3_eta_0 = 1.0 / 3.0;
        private static readonly double para_3_eta_1 = 0.0;

        // constants for problem 5
        private static readonly double para_5_zeta_0 = 1.0;
        private static readonly double para_5_zeta_1 = 1.0;
        private static readonly double para_5_eta_0 = 0.0;
        private static readonly double para_5_eta_1 = 0.0;

        // list of analytic solution functions
        private static readonly List<Func<float, double>> solutionFunctionList = new List<Func<float, double>>()
        {
            { BVP_01 },
            { BVP_02 },
            { Solution_02 },
            { Solution_03 },
            { Solution_05 }
        };

        // list of a(x) functions
        private static readonly List<Func<float, double>> aOfXList = new List<Func<float, double>>(){
           { func_bvp_1_a },
           { func_bvp_2_a },
           { func_2_a },
           { func_3_a },
           { func_5_a }
        };

        // list of b(x) functions
        private static readonly List<Func<float, double>> bOfXList = new List<Func<float, double>>(){
           { func_bvp_1_b },
           { func_bvp_2_b },
           { func_2_b },
           { func_3_b },
           { func_5_b }
        };

        // lits of f(x) functions
        private static readonly List<Func<float, double>> fOfXList = new List<Func<float, double>>(){
           { func_bvp_1_f },
           { func_bvp_2_f },
           { func_2_f },
           { func_3_f },
           { func_5_f }
        };

        // list of phi_0 parameters
        private static readonly List<Func<double>> phi0List = new List<Func<double>>(){
           { para_bvp_1_phi_0 },
           { para_bvp_2_phi_0 },
           { para_2_phi_0 },
           { para_3_phi_0 },
           { para_5_phi_0 }
        };

        // list of phi_1 parameters
        private static readonly List<Func<double>> phi1List = new List<Func<double>>(){
           { para_bvp_1_phi_1 },
           { para_bvp_2_phi_1 },
           { para_2_phi_1 },
           { para_3_phi_1 },
           { _5_phi_1 }
        };

        // list of zeta_0
        private static readonly List<double> zeta0List = new List<double>(){
           { para_bvp_1_zeta_0 },
           { para_bvp_2_zeta_0 },
           { para_2_zeta_0 },
           { para_3_zeta_0 },
           { para_5_zeta_0 }
        };

        // list of zeta_1
        private static readonly List<double> zeta1List = new List<double>(){
           { para_bvp_1_zeta_1 },
           { para_bvp_2_zeta_1 },
           { para_2_zeta_1 },
           { para_3_zeta_1 },
           { para_5_zeta_1 }
        };

        // list of eta_0
        private static readonly List<double> eta0List = new List<double>(){
           { para_bvp_1_eta_0 },
           { para_bvp_2_eta_0 },
           { para_2_eta_0 },
           { para_3_eta_0 },
           { para_5_eta_0 }
        };

        // list of eta_1
        private static readonly List<double> eta1List = new List<double>(){
           { para_bvp_1_eta_1 },
           { para_bvp_2_eta_1 },
           { para_2_eta_1 },
           { para_3_eta_1 },
           { para_5_eta_1 }
        };
        #endregion

        // data for bvp 1
        #region BVP 1
        private static double func_bvp_1_a(float x)
        {
            return 1.0;
        }
        private static double func_bvp_1_b(float x)
        {
            return 0.0;
        }
        private static double func_bvp_1_f(float x)
        {
            return Math.Pow(x, 3);
        }
        private static double para_bvp_1_phi_0()
        {
            return phi0;
        }
        private static double para_bvp_1_phi_1()
        {
            return phi1;
        }
        #endregion

        // data for bvp 2
        #region BVP 2
        private static double func_bvp_2_a(float x)
        {
            return 1.0;
        }
        private static double func_bvp_2_b(float x)
        {
            return 0.0;
        }
        private static double func_bvp_2_f(float x)
        {
            return Math.Pow(x, 3);
        }
        private static double para_bvp_2_phi_0()
        {
            return phi0;
        }
        private static double para_bvp_2_phi_1()
        {
            return phi1;
        }
        #endregion

        // data for problem 2
        #region Problem 2
        private static double func_2_a(float x)
        {
            return (2 * epsilon) / (1 + x) - (2) / (Math.Pow(1 + x, 2));
        }
        private static double func_2_b(float x)
        {
            return 0.0;
        }
        private static double func_2_f(float x)
        {
            return (1 - 2 * x) / (Math.Pow(1 + x, 2)) * (epsilon * (1 + x) - 1) - epsilon;
        }
        private static double para_2_phi_0()
        {
            return 0.5 * Math.Exp(-1 / epsilon);
        }
        private static double para_2_phi_1()
        {
            return 0;
        }
        #endregion

        // data for problem 3
        #region Problem 3
        private static double func_3_a(float x)
        {
            return 3.0 * Math.Pow(1.0 + x, 2) - (2.0 * epsilon) / (1.0 + x);
        }
        private static double func_3_b(float x)
        {
            return 0.0;
        }
        private static double func_3_f(float x)
        {
            return (3.0 * epsilon) / (2.0 * Math.Pow(1.0 + x, 2)) - (3.0 + 3.0 * x) / (2.0);
        }
        private static double para_3_phi_0()
        {
            return (epsilon) / (6.0) - (1.0) / (1.0 - Math.Exp(-7.0 / epsilon));
        }
        private static double para_3_phi_1()
        {
            return 1.0 - Math.Log(2) / 2.0;
        }
        #endregion

        // data for problem 5
        #region Problem 5
        private static double func_5_a(float x)
        {
            return (2.0 * epsilon) / (1.0 + x) + (2.0) / (Math.Pow(1.0 + x, 2.0));
        }
        private static double func_5_b(float x)
        {
            return 0.0;
        }
        private static double func_5_f(float x)
        {
            return (4.0) / (Math.Pow(1.0 + x, 4.0));
        }
        private static double para_5_phi_0()
        {
            return -1.0;
        }
        private static double _5_phi_1()
        {
            return 1.0;
        }
        #endregion

        #region Solution Functions
        // BVP 1 -- a = 1, f(x) = x^3
        private static double BVP_01(float x)
        {
            double c2 = (phi0 - phi1 + 0.25 - epsilon + 3 * Math.Pow(epsilon, 2) - 6 * Math.Pow(epsilon, 3)) / (1 - Math.Exp(-1 / epsilon));

            return (Math.Exp(-1 / epsilon * x) - 1) * c2 + 0.25 * Math.Pow(x, 4) - epsilon * Math.Pow(x, 3) + 3 * Math.Pow(epsilon, 2) * Math.Pow(x, 2) - 6 * Math.Pow(epsilon, 3) * x + phi0;
        }
        // BVP 2 -- a = 1, f(x) = x^3
        private static double BVP_02(float x)
        {
            double c2 = (phi0 - phi1 + 0.25 - epsilon + 3 * Math.Pow(epsilon, 2) - 6 * Math.Pow(epsilon, 3) - 6 * Math.Pow(epsilon, 4)) / (2 - Math.Exp(-1 / epsilon));

            return phi0 + (Math.Exp(-1 / epsilon * x) - 2) * c2 + 0.25 * Math.Pow(x, 4) - epsilon * Math.Pow(x, 3) + 3 * Math.Pow(epsilon, 2) * Math.Pow(x, 2) - 6 * Math.Pow(epsilon, 3) * x - 6 * Math.Pow(epsilon, 4);
        }
        // Problem 2 -- from lab1.pdf
        private static double Solution_02(float x)
        {
            return (x * (1.0 - x)) / (2.0) + (Math.Exp(-1.0 / epsilon) - Math.Exp(-(2.0) / (epsilon * (1.0 + x)))) / (2.0 * (1.0 - Math.Exp(-1.0 / epsilon)));
        }
        // Problem 3 -- from lab1.pdf
        private static double Solution_03(float x)
        {
            double exponent = (1.0 - Math.Pow(1.0 + x, 3)) / (epsilon);
            return (1.0 - Math.Exp(exponent)) / (1.0 - Math.Exp(-7.0 / epsilon)) - (Math.Log(1.0 + x)) / (2.0);
        }
        // problem 5 -- from lab1.pdf
        private static double Solution_05(float x)
        {
            return (2.0 * x) / (1.0 + x) + (Math.Exp(-1.0 / epsilon) - Math.Exp(-(2.0 * x) / (epsilon * (1.0 + x)))) / (1.0 - Math.Exp(-1.0 / epsilon));
        }
        #endregion

        //Private Constructor
        private Functions() { }

        //Compute the graph for the given solution
        protected internal static void ComputeSolution()
        {
            ComputeSolution(computationSteps);
        }

        protected internal static void ComputeSolution(int steps)
        {
            float step = (endValue - startValue) / steps;
            Func<float, double> analyticFunction = solutionFunctionList[problemNumber];
            solutionPointPairList.Clear();
            for (float x = startValue; x <= endValue; x += step)
            {
                solutionPointPairList.Add(x, analyticFunction(x));
            }
        }

        #region Getters
        //Get the list of points of the solution
        protected internal static PointPairList GetSolutionPointPairList()
        {
            return new PointPairList(solutionPointPairList);
        }
        //Get the problem f(x) function 
        protected internal static Func<float, double> GetFOfX(int _problemNumber)
        {
            return fOfXList[_problemNumber];
        }
        //Get the problem a(x) function 
        protected internal static Func<float, double> GetAOfX(int _problemNumber)
        {
            return aOfXList[_problemNumber];
        }
        //Get the problem b(x) function 
        protected internal static Func<float, double> GetBOfX(int _problemNumber)
        {
            return bOfXList[_problemNumber];
        }
        //Get zeta 0
        protected internal static double GetZeta0(int _problemNumber)
        {
            return zeta0List[_problemNumber];
        }
        //Get zeta 1
        protected internal static double GetZeta1(int _problemNumber)
        {
            return zeta1List[_problemNumber];
        }
        //Get eta 0
        protected internal static double GetEta0(int _problemNumber)
        {
            return eta0List[_problemNumber];
        }
        //Get eta 1
        protected internal static double GetEta1(int _problemNumber)
        {
            return eta1List[_problemNumber];
        }
        //Get the phi 0 
        protected internal static Func<double> GetPhi0(int _problemNumber)
        {
            return phi0List[_problemNumber];
        }
        //Get the phi 1 
        protected internal static Func<double> GetPhi1(int _problemNumber)
        {
            return phi1List[_problemNumber];
        }
        //Get epsilon
        protected internal static double GetEpsilon()
        {
            return epsilon;
        }
        //Get the solution function
        protected internal static Func<float, double> GetSolutionFunction(int _problemNumber)
        {
            return solutionFunctionList[_problemNumber];
        }
        #endregion

        #region Setters
        //Set the parameters for the functions, so they are not passed every single time
        protected internal static void SetParameters(int newProblemNumber, float newPhi0, float newPhi1, float newEpsilon)
        {
            epsilon = newEpsilon;
            phi0 = newPhi0;
            phi1 = newPhi1;
            problemNumber = newProblemNumber;
        }
        #endregion
    }
}