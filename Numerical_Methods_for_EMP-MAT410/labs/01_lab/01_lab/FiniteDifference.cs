using System;
using ZedGraph;

namespace _01_lab
{
    class FiniteDifference
    {
        #region Data
        private static readonly PointPairList function = new PointPairList();
        private static int problemN, N;
        private static float h;
        private static float[] steps;
        private static bool isMonotonous, isStable;
        protected internal enum Scheme
        {
            CentralDifference,
            Ilin
        }
        #endregion

        //Private Constructor
        private FiniteDifference() { }

        //Compute the first method
        protected internal static void ComputeFiniteDifference(Scheme scheme)
        {
            // clear the problem function
            function.Clear();

            // get function for the difference method
            Func<float, double> aOfX = Functions.GetAOfX(problemN);
            Func<float, double> bOfX = Functions.GetBOfX(problemN);
            Func<float, double> fOfX = Functions.GetFOfX(problemN);
            Func<double> phi0 = Functions.GetPhi0(problemN);
            Func<double> phi1 = Functions.GetPhi1(problemN);

            // get the values
            double zeta0 = Functions.GetZeta0(problemN);
            double zeta1 = Functions.GetZeta1(problemN);
            double eta0 = Functions.GetEta0(problemN);
            double eta1 = Functions.GetEta1(problemN);
            double epsilon = Functions.GetEpsilon();

            // set step size
            h = (float)1.0 / (N - 1);

            // simplest version of theta
            double theta(float _x)
            {
                switch (scheme)
                {
                    case Scheme.Ilin:
                        return cth(R(_x)) - 1.0 / R(_x);
                    case Scheme.CentralDifference:
                        return 0;
                    default:
                        return 0;
                }
            }

            double R(float _x)
            {
                return (aOfX(_x) * h) / (2.0 * epsilon);
            }

            // hyperbolic cotangent
            double cth(double _x)
            {
                return (Math.Exp(_x) + Math.Exp(-_x)) / (Math.Exp(_x) - Math.Exp(-_x));
            }

            double gamma(float _x)
            {
                switch (scheme)
                {
                    case Scheme.Ilin:
                        return R(_x) * cth(R(_x));
                    case Scheme.CentralDifference:
                        return 1;
                    default:
                        return 1;
                }
            }

            // parameter mu for the accurate bounary conditions
            double mu(float _x)
            {
                return (gamma(_x) - 1) / R(_x);
            }

            // arrays for the variables for progonka
            double[]
                a = new double[N],
                b = new double[N],
                c = new double[N],
                f = new double[N],
                alpha = new double[N],
                beta = new double[N],
                u = new double[N];

            steps = new float[N];

            isStable = true;
            // right boundary
            steps[N - 1] = 1.0f;
            a[N - 1] = -eta1 * epsilon * (gamma(1) - R(1)) / h;
            b[N - 1] = zeta1 + bOfX(1) * h * (1 - mu(1)) / 2 + eta1 * epsilon * (gamma(0) - R(0)) / h;
            f[N - 1] = phi1() - eta1 * fOfX(1) * h * (1 - mu(1)) / 2;
            if (isStable)
            {
                switch (scheme)
                {
                    case Scheme.CentralDifference:
                        isStable = Math.Abs(R(1)) < 1 + R(1) * theta(1);
                        break;
                    case Scheme.Ilin:
                        isStable = Math.Abs(R(1)) < R(1) * cth(R(1));
                        break;
                    default:
                        isStable = false;
                        break;
                }
            }

            // left boundary
            steps[0] = 0.0f;
            b[0] = zeta0 + bOfX(0) * h * (1 + mu(0)) / (2) + eta0 * epsilon * (gamma(0) + R(0)) / h;
            c[0] = eta0 * epsilon * (gamma(0) + R(0)) / h;
            f[0] = phi0() - eta0 * fOfX(0) * h * (1 + mu(0)) / 2;
            if (isStable)
            {
                switch (scheme)
                {
                    case Scheme.CentralDifference:
                        isStable = Math.Abs(R(0)) < 1 + R(0) * theta(0);
                        break;
                    case Scheme.Ilin:
                        isStable = Math.Abs(R(0)) < R(0) * cth(R(0));
                        break;
                    default:
                        isStable = false;
                        break;
                }
            }

            // find the values for progonka
            float x;
            double part_1 = epsilon / Math.Pow(h, 2);
            for (int i = 1; i < N - 1; ++i)
            {
                x = i * h;
                steps[i] = x;

                if (isStable)
                {
                    switch (scheme)
                    {
                        case Scheme.CentralDifference:
                            isStable = Math.Abs(R(x)) < 1 + R(x) * theta(x);
                            break;
                        case Scheme.Ilin:
                            isStable = Math.Abs(R(x)) < R(x) * cth(R(x));
                            break;
                        default:
                            isStable = false;
                            break;
                    }
                }

                double part_2 = gamma(x) + theta(x) * R(x);
                a[i] = part_1 * (part_2 - R(x));
                b[i] = 2 * part_1 * part_2 + bOfX(x);
                c[i] = part_1 * (part_2 + R(x));
                f[i] = -fOfX(x);
            }

            // check monotony
            // condition 1
            isMonotonous = (b[0] != 0 && c[0] >= 0 && b[N - 1] != 0 && a[N - 1] >= 0);
            // condition 3
            if (isMonotonous)
            {
                isMonotonous = (b[0] >= c[0] && b[N - 1] >= a[N - 1]);
            }
            for (int i = 1; i < N - 1 && isMonotonous; ++i)
            {
                // condition 2
                isMonotonous = (a[i] > 0 && c[i] > 0);

                // condition 3
                isMonotonous = (b[i] >= (a[i] + c[i]));
            }

            // progonka
            alpha[0] = c[0] / b[0];
            beta[0] = f[0] / b[0];
            for (int i = 1; i < N; ++i)
            {
                alpha[i] = (c[i]) / (b[i] - alpha[i - 1] * a[i]);
                beta[i] = (f[i] + beta[i - 1] * a[i]) / (b[i] - alpha[i - 1] * a[i]);
            }

            u[N - 1] = (f[N - 1] + beta[N - 2] * a[N - 1]) / (b[N - 1] - alpha[N - 2] * a[N - 1]);

            for (int i = N - 2; i >= 0; --i)
            {
                u[i] = alpha[i] * u[i + 1] + beta[i];
            }

            // adding the result to a zedgraph list to draw them
            for (int i = 0; i < N; ++i)
            {
                function.Add(i * h, u[i]);
            }
        }

        // returns a boolean for the monotony of the function
        protected internal static bool IsMonotone()
        {
            return isMonotonous;
        }

        protected internal static bool IsStable()
        {
            return isStable;
        }

        // returns a list of x values
        protected internal static float[] GetSteps()
        {
            return steps;
        }

        //get the resulting points
        protected internal static PointPairList GetResult()
        {
            return new PointPairList(function);
        }

        //set the parameters for the function
        protected internal static void SetParameters(int newProblemN, int newN)
        {
            problemN = newProblemN;
            N = newN;
        }
    }
}