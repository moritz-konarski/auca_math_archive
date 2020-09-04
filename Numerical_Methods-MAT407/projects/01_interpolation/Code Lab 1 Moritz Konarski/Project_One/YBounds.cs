using ZedGraph;

namespace Project_One
{
    class YBounds : Data
    {
        // This class is used to find appropriate values for the y axis min and max
        private YBounds()
        {

        }

        // Finds the larges and smallest values of the function to be used as limits for the graph
        protected internal static void ComputeYLimits()
        {
            PointPairList function = GetTestPoints();
            double min = 0;
            double max = 0;

            foreach (PointPair point in function)
            {
                min = (point.Y < min) ? point.Y : min;
                max = (point.Y > max) ? point.Y : max;
            }

            SetYMin(min - 0.25);
            SetYMax(max + 0.25);
        }
    }
}
