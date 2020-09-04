using System;
using System.Collections.Generic;
using System.Drawing;
using ZedGraph;

/*This class handles the trapezoidal shapes for the first three methods of integration*/

namespace Project2
{
    class Trapezoid
    {
        #region Data
        private static GraphPane graphPane;
        private readonly PointPair leftPoint;
        private readonly PointPair rightPoint;
        private static List<Trapezoid> trapezoids = new List<Trapezoid>();
        private static PointPairList nodesV2 = new PointPairList();
        private static double totalValue;
        #endregion

        // Constructor.
        private Trapezoid(PointPair leftPoint, PointPair rightPoint)
        {
            // Increment trapezoid count.
            Count++;
            // Enter the points, both poins that are not on the x axis.
            this.leftPoint = leftPoint;
            this.rightPoint = rightPoint;
            // Calculate the area of the trapezoid.
            Value = (rightPoint.X - leftPoint.X) * (leftPoint.Y + rightPoint.Y) / 2.0;
        }

        #region Generation of trapezoidal shapes
        // Compute rectangles in variant one from the nodes.
        protected internal static void ComputeRectanglesV1(PointPairList nodesUniform, PointPairList nodesV1)
        {
            trapezoids.Clear();

            for (int i = 0; i < nodesUniform.Count - 1; i++)
            {
                trapezoids.Add(new Trapezoid(new PointPair(nodesUniform[i].X, nodesV1[i].Y), 
                    new PointPair(nodesUniform[i + 1].X, nodesV1[i].Y)));
            }
        }

        // Compute rectangles in variant two from the nodes.
        protected internal static void ComputeRectanglesV2(PointPairList nodesUniform, PointPairList nodesV2)
        {
            trapezoids.Clear();

            for (int i = 0; i < nodesUniform.Count - 1; i++)
            {
                trapezoids.Add(new Trapezoid(new PointPair(nodesUniform[i].X, nodesV2[i].Y), 
                    new PointPair(nodesUniform[i + 1].X, nodesV2[i].Y)));
            }
        }

        // Compute trapezia from the nodes.
        protected internal static void ComputeTrapezoids(PointPairList nodesTrapezoid)
        {
            trapezoids.Clear();

            for (int i = 0; i < nodesTrapezoid.Count- 1; i++)
            {
                trapezoids.Add(new Trapezoid(nodesTrapezoid[i], nodesTrapezoid[i + 1]));
            }
        }
        #endregion

        #region Getters and Setters
        #region static functions
        // Set the graph pane to be able to draw trapezoidal shapes.
        protected internal static void SetGraphPane(GraphPane graphP)
        {
            graphPane = graphP;
        }

        // Get the number of trapezoidal shapes.
        protected internal static int Count { get; private set; } = 0;

        // Get a list containing all trapezoidal shapes.
        protected internal static List<Trapezoid> GetTrapezoids()
        {
            return trapezoids;
        }

        // Get the nodes necessary to draw for version two integration.
        protected internal static PointPairList GetDrawNodes()
        {
            return nodesV2;
        }

        // Get the total value of all rectangles.
        protected internal static double GetValue()
        {
            totalValue = 0;
            foreach (Trapezoid t in trapezoids)
            {
                totalValue += t.Value;
            }
            return totalValue;
        }
        #endregion
        #region non-static functions
        // Get the value of one rectangle.
        private double Value { get; }

        // Get the x range of one trapezoidal shape.
        private double[] Domain
        {
            get
            {
                return new double[] { leftPoint.X, rightPoint.X };
            }
        }

        // Get the hight of one rectangle.
        private double Height
        {
            get
            {
                return leftPoint.Y;
            }
        }

        // Draw a trapezoidal shape.
        protected internal void Draw()
        {
            {// add lower limit line
                LineItem lowerLimit = graphPane.AddCurve("", new PointPairList { { leftPoint.X, 0 }, leftPoint }, Color.Black, SymbolType.None);
                lowerLimit.Line.IsVisible = true;
                lowerLimit.Line.Fill.Color = Color.Black;
                lowerLimit.Symbol.Fill.Type = FillType.Solid;
                lowerLimit.Line.Width = 2;
            }
            {// add upper limit line
                LineItem upperLimit = graphPane.AddCurve("", new PointPairList { { rightPoint.X, 0 }, rightPoint }, Color.Black, SymbolType.None);
                upperLimit.Line.IsVisible = true;
                upperLimit.Line.Fill.Color = Color.Black;
                upperLimit.Symbol.Fill.Type = FillType.Solid;
                upperLimit.Line.Width = 2;
            }
            {// add vertical line
                LineItem line = graphPane.AddCurve("", new PointPairList { leftPoint, rightPoint }, Color.Black, SymbolType.None);
                line.Line.IsVisible = true;
                line.Line.Fill.Color = Color.LightBlue;
                line.Symbol.Fill.Color = Color.Gray;
                line.Symbol.Fill.Type = FillType.Solid;
                line.Line.Width = 2;
                line.Line.Color = Color.Black;
                line.Line.Fill.Type = FillType.Solid;
            }
        }
        #endregion
        #endregion

        // Find the nodes that are used for drawing version 2.
        protected internal static void FindNodesV2()
        {
            PointPairList function = Functions.GetTestFunction();
            double margin = 0.001;
            double xMargin = 0.0005;
            bool passed = false;

            while (!passed)
            {
                nodesV2.Clear();
                try
                {
                    foreach (Trapezoid trap in trapezoids)
                    {
                        nodesV2.Add(function.Find(x => (Math.Abs(x.Y - trap.Height) <= margin &&
                                                (x.X >= trap.Domain[0] - xMargin && x.X <= trap.Domain[1] + xMargin))).X, trap.Height);
                    }
                    passed = true;
                }
                catch (NullReferenceException)
                {
                    margin += 0.002;
                }
            }
        }
    }
}

