using System;
using System.Drawing;
using ZedGraph;

namespace Diff_Equ
{
    class Graph
    {
        #region DataStrunctures
        private const double smallAxisStep = 0.02;
        private const double largeAxisStep = 0.1;
        private const double majorMinorFactor = 2;
        private GraphPane GraphPane { get; set; }
        private ZedGraphControl Control { get; set; }
        #endregion

        // Constructor.
        protected internal Graph(ZedGraphControl control)
        {
            // Receive the ZedGraph control
            this.Control = control;
            GraphPane = this.Control.GraphPane;
            // Set titles.
            GraphPane.Title.Text = "Runge-Kutta Methods";
            GraphPane.YAxis.Title.Text = "u(t)";
            GraphPane.XAxis.Title.Text = "t";
            // Set steps.
            GraphPane.XAxis.Scale.MajorStep = largeAxisStep;
            GraphPane.YAxis.Scale.MajorStep = 2 * largeAxisStep;
            GraphPane.XAxis.Scale.MinorStep = smallAxisStep;
            GraphPane.YAxis.Scale.MinorStep = 5 * smallAxisStep;
        }

        #region Functions
        // Clear the graph pane.
        protected internal void Clear()
        {
            GraphPane.CurveList.Clear();
        }

        // Refresh the graph pane.
        protected internal void Refresh()
        {
            Control.Refresh();
        }

        // Set the title of the graph pane.
        protected internal void SetTitle(string problemNumber, int numberOfNodes)
        {
            GraphPane.Title.Text = string.Format("Problem {0} - {1} nodes", problemNumber, numberOfNodes);
        }

        // Set the axis limits to the correct values.
        protected internal void SetAxis(double[] minMax)
        {
            GraphPane.XAxis.Scale.Min = -0.1;
            GraphPane.XAxis.Scale.Max = 1.1;
            GraphPane.YAxis.Scale.Min = minMax[0] - 0.1 * Math.Abs(minMax[0]) - 0.1;
            GraphPane.YAxis.Scale.Max = minMax[1] + 0.1 * Math.Abs(minMax[1]) + 0.1; 
        }

        // Function to add any type of curve.
        protected internal void AddCurve(string name, PointPairList data, bool visible, float width, Color color, SymbolType symbol)
        {
            LineItem curve = GraphPane.AddCurve(name, data, color, symbol);
            curve.Line.IsVisible = visible;
            curve.Line.Fill.Color = color;
            curve.Line.Color = color;
            curve.Symbol.Fill.Type = FillType.Solid;
            curve.Line.Width = width;
        }
        #endregion
    }
}

