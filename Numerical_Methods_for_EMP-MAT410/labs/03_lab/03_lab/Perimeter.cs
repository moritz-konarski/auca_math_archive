using System;

namespace _03_lab
{
    class Perimeter1
    {
        private readonly bool inBounds;
        private readonly double tauMin, tauMax, thetaMin, thetaMax;
        protected internal Perimeter1(double theta, double tau, double mu, double v)
        {
            thetaMin = 0.0;
            thetaMax = 2.0;
            tauMin = 0.0;
            double element1 = (2.0 / mu) * (2.0 - theta);
            double element2 = Math.Pow(2.0 - theta, 3) / (theta * mu * v + 2 * Math.Pow(2.0 - theta, 2));
            tauMax = theta + Math.Min(element1, element2);
            inBounds = theta >= thetaMin && tau > tauMin && tau < tauMax;
        }
        protected internal bool IsInBounds()
        {
            return inBounds;
        }

        protected internal double[] GetThetaBounds()
        {
            double[] bounds = new double[2];
            bounds[0] = thetaMin;
            bounds[1] = thetaMax;
            return bounds;
        }

        protected internal double[] GetTauBounds()
        {
            double[] bounds = new double[2];
            bounds[0] = tauMin;
            bounds[1] = tauMax;
            return bounds;
        }
    }

    class Perimeter2
    {
        private readonly bool inBounds;
        private readonly double tauMin, tauMax, thetaMin, thetaMax;

        protected internal Perimeter2(double theta, double tau, double mu, double v)
        {
            thetaMin = 0.0;
            thetaMax = 2.0;
            tauMin = theta + Math.Pow(2.0 - theta, 3) / (theta * mu * v + 2.0 * Math.Pow(2 - theta, 2));
            tauMax = theta + (2.0 / v) * (2.0 - theta);
            inBounds = theta >= thetaMin && theta <= thetaMax && tau >= tauMin && tau < tauMax;
        }
        protected internal bool IsInBounds()
        {
            return inBounds;
        }

        protected internal double[] GetThetaBounds()
        {
            double[] bounds = new double[2];
            bounds[0] = thetaMin;
            bounds[1] = thetaMax;
            return bounds;
        }

        protected internal double[] GetTauBounds()
        {
            double[] bounds = new double[2];
            bounds[0] = tauMin;
            bounds[1] = tauMax;
            return bounds;
        }
    }
}
