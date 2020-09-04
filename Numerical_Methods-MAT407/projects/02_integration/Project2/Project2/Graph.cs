using System.Drawing;
using ZedGraph;

/*This class handles the drawing of functions on the ZedGraph pane*/

namespace Project2
{
    class Graph
    {
        #region DataStrunctures
        private readonly Color shadeColor;
        private const double smallAxisStep = 0.1;
        private const double largeAxisStep = 5;
        private const double majorMinorFactor = 2;
        private GraphPane GraphPane { get; set; }
        private ZedGraphControl Control { get; set; }
        #endregion

        // Constructor.
        protected internal Graph(ZedGraphControl control, Color shadeColor)
        {
            // Receive the ZedGraph control
            Control = control;
            GraphPane = Control.GraphPane;
            // Set the color for shading the integral value.
            this.shadeColor = shadeColor;
            // Set titles.
            GraphPane.Title.Text = "Numerical Integration";
            GraphPane.YAxis.Title.Text = "Y Axis";
            GraphPane.XAxis.Title.Text = "X Axis";
            // Set steps.
            GraphPane.XAxis.Scale.MajorStep = smallAxisStep;
            GraphPane.YAxis.Scale.MajorStep = smallAxisStep;
            GraphPane.XAxis.Scale.MinorStep = smallAxisStep / majorMinorFactor;
            GraphPane.YAxis.Scale.MinorStep = smallAxisStep / majorMinorFactor;
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
        private void SetTitle(int problemNumber)
        {
            GraphPane.Title.Text = string.Format("Problem {0}", problemNumber + 1);
        }

        // Set the axis limits to the correct values.
        private void SetAxis(int problemNumber)
        {
            // Set axis range.
            GraphPane.XAxis.Scale.Min = Functions.GetLimits(problemNumber)[0] - 0.25;
            GraphPane.XAxis.Scale.Max = Functions.GetLimits(problemNumber)[1] + 0.25;
            GraphPane.YAxis.Scale.Min = Bounds.GetFunctionYLimts()[0];
            GraphPane.YAxis.Scale.Max = Bounds.GetFunctionYLimts()[1];
            // Set step size for y.
            if (GraphPane.YAxis.Scale.Max > 10 || GraphPane.YAxis.Scale.Min < -10)
            {
                GraphPane.YAxis.Scale.MajorStep = largeAxisStep;
                GraphPane.YAxis.Scale.MinorStep = largeAxisStep / majorMinorFactor;
            }
            else
            {
                GraphPane.YAxis.Scale.MajorStep = smallAxisStep;
                GraphPane.YAxis.Scale.MinorStep = smallAxisStep / majorMinorFactor;
            }
        }

        // Graph the test function.
        protected internal void GraphTestFunction(int problemNumber)
        {
            AddCurve("Test Function", Functions.GetTestFunction(), false, true, 2.0f, Color.Blue, SymbolType.None);

            DrawLimits(problemNumber);

            SetAxis(problemNumber);

            SetTitle(problemNumber);
        }

        // Graph the nodes for variant 1.
        protected internal void GraphNodesV1() 
        {
            AddCurve("Nodes for calculation", Functions.GetNodesV1(), false, false, 4, Color.Red, SymbolType.Diamond);
        }

        // Graph the nodes for variant 2.
        protected internal void GraphNodesV2() 
        {
            // Find the nodes that are to be drawn.
            Trapezoid.FindNodesV2();
            
            AddCurve("Nodes for calculation", Trapezoid.GetDrawNodes(), false, false, 4, Color.Red, SymbolType.Diamond);
        }

        // Graph the nodes for trapezoids.
        protected internal void GraphTrapezoidNodes()
        {
            AddCurve("Nodes", Functions.GetNodesUniform(), false, false, 4, Color.Red, SymbolType.Diamond);
        }

        // Graph the nodes for Simpson's rule.
        protected internal void GraphSimpsonNodes()
        {
            AddCurve("Nodes", Functions.GetNodesSimpson(), false, false, 4, Color.Red, SymbolType.Diamond);
        }

        // Graph the graph for simpson's rule.
        protected internal void GraphSimpsonGraph()
        {
            AddCurve("Simpson's Graph", Functions.GetSimpsonGraph(), true, true, 2, Color.Red, SymbolType.None);
        }

        // Draw the limits of the integral.
        private void DrawLimits(int problemNumber)
        {
            // lower limit
            AddCurve("", Functions.GetLowerLimit(problemNumber), false, true, 2, Color.Black, SymbolType.None);
            // upper limit
            AddCurve("", Functions.GetUpperLimit(problemNumber), false, true, 2, Color.Black, SymbolType.None);
        }

        // Function to add any type of curve.
        private void AddCurve(string name, PointPairList data, bool shaded, bool visible, float width, Color color, SymbolType symbol)
        {
            LineItem curve = GraphPane.AddCurve(name, data, color, symbol);
            curve.Line.IsVisible = visible;
            curve.Line.Fill.Color = color;
            curve.Line.Color = color;
            curve.Symbol.Fill.Type = FillType.Solid;
            curve.Line.Width = width;
            if (shaded)
            {
                curve.Line.Fill.Type = FillType.Solid;
                curve.Line.Fill.Color = shadeColor;
            }
        }
        #endregion
    }
}
