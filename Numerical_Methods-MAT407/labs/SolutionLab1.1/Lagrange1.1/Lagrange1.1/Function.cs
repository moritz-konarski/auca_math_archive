using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace Lagrange1._1
{
    public class Function
    {
        readonly double leftLimit;
        readonly double rightLimit;
        readonly double step;

        //constructor
        public Function(double leftLimit, double rightLimit, double step)
        {
            this.leftLimit = leftLimit;
            this.rightLimit = rightLimit;
            this.step = step;
        }

        public double getLeftLimit()
        {
            return this.leftLimit;
        }

        public double getRightLimit()
        {
            return this.rightLimit;
        }

        public double getStep()
        {
            return this.step;
        }

        public PointPairList function(int problemNumber)
        {
            return new PointPairList();
        }

        public PointPairList nodes(int nNodes, int problemNumber)
        {
            return new PointPairList();
        }
    }
}
