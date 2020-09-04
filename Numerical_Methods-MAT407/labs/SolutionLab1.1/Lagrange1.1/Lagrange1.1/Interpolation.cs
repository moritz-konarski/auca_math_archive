using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace Lagrange1._1
{
    public class Interpolation
    {
        readonly double leftLimit;
        readonly double rightLimit;
        readonly double step;

        //constructor
        public Interpolation(Function function)
        {
            this.leftLimit = function.getLeftLimit();
            this.rightLimit = function.getRightLimit();
            this.step = function.getStep();
        }

        public PointPairList lagrange(Function function)
        {
            return new PointPairList();
        }

        public PointPairList cubicSpline(Function function)
        {
            return new PointPairList();
        }
    }
}
