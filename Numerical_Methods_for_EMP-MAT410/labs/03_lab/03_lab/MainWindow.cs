using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using ZedGraph;
using System.IO;

namespace _03_lab
{
    public partial class MainWindow : Form
    {
        #region Private Data Fields
        private static Graph xSliceGraph, ySliceGraph;
        private static Perimeter1 p1;
        private static Perimeter2 p2;
        private static PointPairList xSliceExactSolution, xSliceNumericalSolution;
        private static PointPairList ySliceExactSolution, ySliceNumericalSolution;

        private static int schemeIndex;
        private static int gridNodeCount;
        private static int iterationIndex;
        private static int xSliceNode, ySliceNode;
        private static readonly int analyticSteps = 1000;

        private static double h;
        private static double q;
        private static double theta, tau, sigma, mu, v;
        private static double errorX, maxErrorX, errorY, maxErrorY;
        private static double lambda;
        private static readonly double analyticStep = 1.0 / (analyticSteps - 1.0);
        private static readonly double parameterL = 2.0, parameterM = 2.0;

        private static double[,] uValues;
        private static double[,] uValuesPrevious;

        private static bool iterationFinished;
        private static readonly bool logError = false;
        private static StringBuilder csv;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            xSliceGraph = new Graph(XSliceGraphPane, true);
            ySliceGraph = new Graph(YSliceGraphPane, false);

            SchemeComboBox.SelectedIndex = 0;
            SigmaComboBox.SelectedIndex = 0;
            GridNodeComboBox.SelectedIndex = 0;

            xSliceExactSolution = new PointPairList();
            xSliceNumericalSolution = new PointPairList();

            ySliceExactSolution = new PointPairList();
            ySliceNumericalSolution = new PointPairList();
            GetParameters();
        }

        private void GetParameters()
        {
            maxErrorX = 0;
            errorX = 0;
            maxErrorY = 0;
            errorY = 0;
            iterationFinished = false;
            IsFinishedLabel.Text = "No";

            gridNodeCount = Int32.Parse(GridNodeComboBox.Text);
            h = 1.0 / (gridNodeCount - 1.0);

            Iterator.Interval = 2000 / gridNodeCount;

            lambda = 4.0 / Math.Pow(h, 2) * (Math.Pow(Math.Sin(Math.PI * parameterL * h / 2.0), 2) + Math.Pow(Math.Sin(Math.PI * parameterM * h / 2.0), 2));

            xSliceNode = gridNodeCount / 2 - 1;
            ySliceNode = xSliceNode;

            uValues = new double[gridNodeCount, gridNodeCount];
            uValuesPrevious = new double[gridNodeCount, gridNodeCount];

            schemeIndex = SchemeComboBox.SelectedIndex;
            if (schemeIndex == 0)
            {
                tau = 1;
                theta = 0;
            }
            else if (schemeIndex == 1)
            {
                tau = 1;
                theta = 1;
            }

            sigma = Double.Parse(SigmaComboBox.Text);

            mu = 4.0 * Math.Pow(Math.Sin(h * Math.PI / 2.0), 2);
            v = 4.0 * Math.Pow(Math.Cos(h * Math.PI / 2.0), 2);

            p1 = new Perimeter1(theta, tau, mu, v);
            p2 = new Perimeter2(theta, tau, mu, v);

            if (p1.IsInBounds())
            {
                q = Math.Sqrt(1.0 - tau * mu * (mu * (theta - tau) + 2.0 * (2.0 - theta)) / (2.0 * mu * theta + Math.Pow(2.0 - theta, 2)));
            }
            else if (p2.IsInBounds())
            {
                q = Math.Sqrt(1.0 - tau * v * (v * (theta - tau) + 2.0 * (2.0 - theta)) / (2.0 * v * theta + Math.Pow(2.0 - theta, 2)));
            }
            Console.WriteLine(q);

            SetErrorLabels();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Iterator.Stop();
            iterationIndex = 0;
            iterationFinished = false;

            SetIterationLabel();

            xSliceGraph.Clear();
            xSliceGraph.Refresh();

            ySliceGraph.Clear();
            ySliceGraph.Refresh();

            ErrorXLabel.Text = "0";
            ErrorYLabel.Text = "0";
            IsFinishedLabel.Text = "No";
        }

        private void InitializeErrorLog()
        {
            if (logError)
            {
                csv = new StringBuilder();
                csv.AppendLine($"iteration    errorX    errorY");
            }
        }

        private void LogError()
        {
            if (logError)
            {
                csv.AppendLine($"{iterationIndex}    {errorX}    {errorY}");
            }
        }

        private void CloseLogger()
        {
            if (logError)
            {
                string filename = $"{SchemeComboBox.Text}_{gridNodeCount}_sigma{sigma}_l{parameterL}_m{parameterM}.dat";
                File.WriteAllText(filename, csv.ToString());
            }
        }

        private double AnalyticFunction(double x, double y)
        {
            return Math.Sin(Math.PI * parameterL * x) * Math.Sin(Math.PI * parameterM * y);
        }

        private double Numerical_F_Function(double x, double y)
        {
            return lambda * Math.Sin(Math.PI * parameterL * x) * Math.Sin(Math.PI * parameterM * y);
        }

        private void CalculateAnalyticalSolution()
        {
            double y, x;
            xSliceExactSolution.Clear();
            ySliceExactSolution.Clear();

            for (int i = 0; i < analyticSteps; ++i)
            {
                y = ySliceNode * h;
                x = i * analyticStep;
                xSliceExactSolution.Add(x, AnalyticFunction(x, y));

                x = xSliceNode * h;
                y = i * analyticStep;
                ySliceExactSolution.Add(y, AnalyticFunction(x, y));
            }
        }

        private void CalculateNumericalSolution()
        {
            xSliceNumericalSolution.Clear();
            ySliceNumericalSolution.Clear();

            if (iterationIndex == 0)
            {
                double x;
                for (int i = 0; i < gridNodeCount; ++i)
                {
                    x = i * h;
                    xSliceNumericalSolution.Add(x, 0);
                    ySliceNumericalSolution.Add(x, 0);
                }
            }
            else
            {
                // y values
                for (int j = 1; j < gridNodeCount - 1; ++j)
                {
                    // x values
                    for (int i = 1; i < gridNodeCount - 1; ++i)
                    {
                        uValues[i, j] = theta / 4.0 * (uValues[i - 1, j] + uValues[i, j - 1]) + (tau - theta) / 4.0 * (uValuesPrevious[i - 1, j] + uValuesPrevious[i, j - 1]) + tau / 4.0 * (uValuesPrevious[i + 1, j] + uValuesPrevious[i, j + 1]) + (1 - tau) * uValuesPrevious[i, j] + tau * h * h / 4.0 * Numerical_F_Function(i * h, j * h);
                    }
                }
                for (int i = 0; i < gridNodeCount; ++i)
                {
                    xSliceNumericalSolution.Add(i * h, uValues[i, xSliceNode]);
                    ySliceNumericalSolution.Add(i * h, uValues[ySliceNode, i]);
                }
            }

            uValuesPrevious = (double[,])(uValues.Clone());
        }

        private void GraphFunctions()
        {
            xSliceGraph.Clear();
            ySliceGraph.Clear();

            xSliceGraph.AddCurve("Numerical Solution", xSliceNumericalSolution, true, 2.5f, Color.Blue, SymbolType.Diamond);

            xSliceGraph.AddCurve("Excact Solution", xSliceExactSolution, true, 2.5f, Color.Red, SymbolType.None);

            ySliceGraph.AddCurve("Numerical Solution", ySliceNumericalSolution, true, 2.5f, Color.Blue, SymbolType.Diamond);

            ySliceGraph.AddCurve("Excact Solution", ySliceExactSolution, true, 2.5f, Color.Red, SymbolType.None);

            xSliceGraph.SetAxis(FindMinMax(xSliceExactSolution));
            xSliceGraph.Refresh();

            ySliceGraph.SetAxis(FindMinMax(ySliceExactSolution));
            ySliceGraph.Refresh();
        }

        private void CalculateError()
        {
            int index = 0;
            double
                maximumDifference = 0,
                difference,
                functionValue;

            for (int i = 0; i < gridNodeCount; ++i)
            {
                functionValue = AnalyticFunction(i * h, xSliceNode * h);
                difference = Math.Abs(functionValue - xSliceNumericalSolution[index++].Y);
                maximumDifference = (maximumDifference > difference) ? maximumDifference : difference;
            }
            errorX = maximumDifference;

            index = 0;
            for (int i = 0; i < gridNodeCount; ++i)
            {
                functionValue = AnalyticFunction(ySliceNode * h, i * h);
                difference = Math.Abs(functionValue - ySliceNumericalSolution[index++].Y);
                maximumDifference = (maximumDifference > difference) ? maximumDifference : difference;
            }
            errorY = maximumDifference;

            SetErrorLabels();

            if (maxErrorX < errorX || maxErrorY < errorY)
            {
                maxErrorX = maxErrorX < errorX ? errorX : maxErrorX;
                maxErrorY = maxErrorY < errorY ? errorY : maxErrorY;
            }
        }

        private static double[] FindMinMax(PointPairList ComputedFunction)
        {
            double[] minMax = new double[2];
            minMax[0] = ComputedFunction[0].Y;
            minMax[1] = ComputedFunction[0].Y;
            foreach (PointPair point in ComputedFunction)
            {
                minMax[0] = (minMax[0] > point.Y) ? point.Y : minMax[0];
                minMax[1] = (minMax[1] < point.Y) ? point.Y : minMax[1];
            }
            return minMax;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            InitializeIteration();
            StartIterator();
        }

        private void SetIterationLabel()
        {
            CurrentIterationsLabel.Text = iterationIndex.ToString();
        }

        private void SetErrorLabels()
        {
            if (Double.IsNaN(errorX))
            {
                ErrorXLabel.Text = "--";
            }
            else
            {
                ErrorXLabel.Text = string.Format("{0:f10}", errorX);
            }

            if (Double.IsNaN(errorY))
            {
                ErrorYLabel.Text = "--";
            }
            else
            {
                ErrorYLabel.Text = string.Format("{0:f10}", errorY);
            }
        }

        private void Iterator_Tick(object sender, EventArgs e)
        {
            IterateManually();
        }

        private void StepButton_Click(object sender, EventArgs e)
        {
            if (iterationIndex == 0)
            {
                InitializeIteration();
            }
            else if (!iterationFinished)
            {
                IterateManually();
            }
        }

        private void InitializeIteration()
        {
            InitializeErrorLog();

            GetParameters();

            Iterator.Stop();
            iterationIndex = 0;

            CalculateAnalyticalSolution();

            IterateManually();
        }

        private void StartIterator()
        {
            Iterator.Start();
        }

        private void IterateManually()
        {
            CalculateNumericalSolution();

            GraphFunctions();

            CalculateError();

            LogError();

            AdvanceIterationStep();
        }

        private void AdvanceIterationStep()
        {
            SetIterationLabel();

            if ((errorX > errorY ? errorX : errorY) < sigma)
            {
                Iterator.Stop();
                CloseLogger();
                IsFinishedLabel.Text = "Yes";
                iterationFinished = true;
            }
            else
            {
                ++iterationIndex;
            }
        }
    }
}
