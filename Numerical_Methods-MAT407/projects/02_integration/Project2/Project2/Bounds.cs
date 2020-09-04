using ZedGraph;

/*This class finds the largest and smallest values y takes in a function*/

namespace Project2
{
    class Bounds
    {
        private Bounds()
        {

        }

        // Get the upper and lower limits of the y values of a function
        protected internal static double[] GetFunctionYLimts()
        {
            double yMin = 0, yMax = 0;
            foreach (PointPair point in Functions.GetTestFunction())
            {
                yMin = (point.Y < yMin) ? point.Y : yMin;
                yMax = (point.Y > yMax) ? point.Y : yMax;
            }
            double delta = yMax - yMin;
            return new double[] { yMin - .1 * delta - 0.25, yMax + .1 * delta + 0.25 };
        }
    }
}
