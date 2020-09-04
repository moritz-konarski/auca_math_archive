using ZedGraph;
using System.Drawing;
using System;

namespace Project_One
{
    // This class is used to interface with ZedGraph and to draw the function, interpolation, the error and the node points
    class Graphing : Data
    {
        #region DataStrunctures
        private const double smallAxisStep = 0.1;
        private const double largeAxisStep = 1;
        private const double majorMinorFactor = 2;
        private const double xMin = -0.25;
        private const double xMax = 1.25;
        private GraphPane graphPane;
        private ZedGraphControl control;
        #endregion

        // Constructor.
        protected internal Graphing(ZedGraphControl control)
        {
            this.control = control;
            graphPane = this.control.GraphPane;
            graphPane.Title.Text = GetDiagramTitle();
            graphPane.YAxis.Title.Text = GetYAxisTitle();
            graphPane.XAxis.Title.Text = GetXAxisTitle();
            graphPane.XAxis.Scale.MajorStep = smallAxisStep;
            graphPane.YAxis.Scale.MajorStep = smallAxisStep;
            graphPane.XAxis.Scale.MinorStep = smallAxisStep / majorMinorFactor;
            graphPane.YAxis.Scale.MinorStep = smallAxisStep / majorMinorFactor;
        }

        #region Functions
        // Clear the graph pane.
        protected internal void Clear()
        {
            graphPane.CurveList.Clear();
        }

        // Refresh the graph pane and set correct title.
        protected internal void Refresh()
        {
            graphPane.Title.Text = String.Format("Problem {0}", GetProblemNumber() + 1);
            control.Refresh();
        }

        // Set the axis limits to the correct values for each problem.
        protected internal void SetAxis()
        {
            //if delta y is >5, set the majorstep to something more reasonable
            graphPane.XAxis.Scale.Min = xMin;
            graphPane.XAxis.Scale.Max = xMax;
            graphPane.YAxis.Scale.Min = GetYMin();
            graphPane.YAxis.Scale.Max = GetYMax();
            if (Math.Abs(GetYMax()) + Math.Abs(GetYMin()) > 5)
            {
                graphPane.YAxis.Scale.MajorStep = largeAxisStep;
                graphPane.YAxis.Scale.MinorStep = largeAxisStep / majorMinorFactor;
            }
            else
            {
                graphPane.XAxis.Scale.MajorStep = smallAxisStep;
                graphPane.YAxis.Scale.MinorStep = smallAxisStep / majorMinorFactor;
            }
        }

        // Graph the test function.
        protected internal void GraphTestFunction(Color color, float width, SymbolType symbol)
        {
            LineItem testFunction = graphPane.AddCurve("Test Function", GetTestPoints(), color, symbol);
            testFunction.Line.IsVisible = true;
            testFunction.Line.Fill.Color = color;
            testFunction.Symbol.Fill.Type = FillType.Solid;
            testFunction.Line.Width = width;
        }

        // Graph the nodes points.
        protected internal void GraphNodePoints(Color color, float width, SymbolType symbol)
        {
            LineItem nodes = graphPane.AddCurve("Nodes", GetNodePoints(), color, symbol);
            nodes.Line.IsVisible = false;
            nodes.Line.Fill.Color = color;
            nodes.Symbol.Fill.Type = FillType.Solid;
            nodes.Line.Width = width;
        }

        // Graph the interpolated function.
        protected internal void GraphInterpolation(Color color, float width, SymbolType symbol)
        {
            LineItem interpolation = graphPane.AddCurve("Interpolation", GetInterpolationPoints(), color, symbol);
            interpolation.Line.IsVisible = true;
            interpolation.Line.Fill.Color = color;
            interpolation.Symbol.Fill.Type = FillType.Solid;
            interpolation.Line.Width = width;
        }

        // Graph the error of interpolation
        protected internal void GraphError(Color color, float width, SymbolType symbol)
        {
            LineItem error = graphPane.AddCurve("Error", GetErrorPoints(), color, symbol);
            error.Line.IsVisible = true;
            error.Line.Fill.Color = color;
            error.Symbol.Fill.Type = FillType.Solid;
            error.Line.Width = width;
        }
        #endregion
    }
}
