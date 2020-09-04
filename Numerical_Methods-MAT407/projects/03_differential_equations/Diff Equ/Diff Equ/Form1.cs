using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace Diff_Equ
{
    public partial class Form1 : Form
    {
        #region Data
        private static int start = 0;
        private static int end = 1;
        private int numberOfSteps;
        private int problemNumber;
        private double phi;
        private double epsilon;
        private double lambda;
        private double error;
        private Graph graph;
        #endregion

        //Constructor
        public Form1()
        {
            InitializeComponent();
            graph = new Graph(GraphPane);
            ProblemBox.SelectedIndex = 0;
            MethodBox.SelectedIndex = 0;
            NodeBox.SelectedIndex = 0;
            LambdaBox.SelectedIndex = 0;
            EpsilonBox.SelectedIndex = 0;
            PhiBox.SelectedIndex = 0;
            ErrorLabel.Text = "Relative Error: --";
        }

        // if the draw button is clicked
        private void DrawButton_Click(object sender, EventArgs e)
        {
            //get the problem parameters
            problemNumber = ProblemBox.SelectedIndex;
            GetEpsilon();
            GetNumberOfSteps();
            GetPhi();
            switch (MethodBox.SelectedIndex)
            {
                case 1:
                    GetLambda();
                    break;
                case 2:
                    GetSigma();
                    break;
            }
            //do the computation
            if (epsilon != -1 && lambda != -1 && numberOfSteps != -1 && phi != -1)
            {
                Functions.SetParameters(problemNumber, phi, epsilon);
                Functions.ComputeSolution();
                RungeKuttaMethod.ComputeIntervals(start, end, numberOfSteps);
                RungeKuttaMethod.SetParameters(problemNumber, phi, epsilon, lambda);
                switch (MethodBox.SelectedIndex)
                {
                    case 0:
                        RungeKuttaMethod.ComputeFirstMethod();
                        break;
                    case 1:
                        RungeKuttaMethod.ComputeSecondMethod();
                        break;
                    case 2:
                        RungeKuttaMethod.ComputeThirdMethod();
                        break;
                }
                //draw the graph
                graph.Clear();
                graph.SetTitle(ProblemBox.Text, numberOfSteps + 1);
                graph.SetAxis(FindMinMax(RungeKuttaMethod.GetResult()));
                graph.AddCurve("Solution", Functions.GetSolutionPointPairList(), true, 2.5f, Color.Red, SymbolType.None);
                graph.AddCurve("Computation", RungeKuttaMethod.GetResult(), true, 2.5f, Color.Blue, SymbolType.Diamond);
                graph.Refresh();
                //calculate the error
                CalculateError();
                //output the error value
                ErrorLabel.Text = string.Format("Relative Error: {0:F8} %", error);
            }
        }

        //if the exit button is clicked
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //to calculate the error
        private void CalculateError()
        {
            PointPairList computedSolution = RungeKuttaMethod.GetResult();
            double[] tValues = RungeKuttaMethod.GetTValues();
            double maxFunc = 0, diffFunc = 0, value1, value2;
            Func<double, double, double, double> currFunc = Functions.GetSolutionFunction(problemNumber);
            //calculate the error as given in the lab
            //max abs difference between solution and computation over max value of solution
            for (int i = 0; i < tValues.Length; i++)
            {
                value2 = currFunc(tValues[i], phi, epsilon);
                value1 = Math.Abs(value2 - computedSolution[i].Y);
                diffFunc = (diffFunc > value1) ? diffFunc : value1;
                maxFunc = (maxFunc > Math.Abs(value2)) ? maxFunc : Math.Abs(value2);
            }
            error = diffFunc / maxFunc * 100;
        }

        //validate the input for epsilon
        private void GetEpsilon()
        {
            bool parseSuccess = double.TryParse(EpsilonBox.Text, out epsilon);
            if (!parseSuccess || epsilon <= 0 || epsilon > 1 || (problemNumber == 5 && epsilon <= 1 / Math.PI))
            {
                EpsilonBox.ForeColor = Color.Red;
                if (problemNumber != 5)
                {
                    MessageBox.Show("Please enter: 0 < epsilon <= 1!", "Epsilon");
                }
                else
                {
                    MessageBox.Show("Please enter: 1 / PI (0.32) < epsilon <= 1!", "Epsilon");
                }
                epsilon = -1;
            }
            else
            {
                EpsilonBox.ForeColor = Color.Black;
            }
        }

        //validate the input for lambda
        private void GetLambda()
        {
            bool parseSuccess = double.TryParse(LambdaBox.Text, out lambda);
            if (!parseSuccess || lambda <= 0 || lambda > 1)
            {
                LambdaBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter: 0 < lambda <= 1!", "Lambda");
                lambda = -1;
            }
            else
            {
                LambdaBox.ForeColor = Color.Black;
            }
        }

        //validate the input for sigma
        private void GetSigma()
        {
            bool parseSuccess = double.TryParse(LambdaBox.Text, out lambda);
            if (!parseSuccess || lambda == 0)
            {
                LambdaBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter: sigma != 0!", "Sigma");
                lambda = -1;
            }
            else
            {
                LambdaBox.ForeColor = Color.Black;
            }
        }

        //validate the input for phi
        private void GetPhi()
        {
            bool parseSuccess = double.TryParse(PhiBox.Text, out phi);
            if (!parseSuccess || (problemNumber == 8 && phi <= 0) || (problemNumber == 12 && phi <= Math.E - 1))
            {
                PhiBox.ForeColor = Color.Red;
                if (problemNumber == 8)
                {
                    MessageBox.Show("Please enter a real number >0!", "Phi");
                }
                else if (problemNumber == 12)
                {
                    MessageBox.Show("Please enter a real number >e-1 (1.72)!", "Phi");
                }
                else
                {
                    MessageBox.Show("Please enter a real number!", "Phi");
                }
                phi = -1;
            }
            else
            {
                PhiBox.ForeColor = Color.Black;
            }
        }

        //validate the input for the number of steps
        private void GetNumberOfSteps()
        {
            bool parseSuccess = int.TryParse(NodeBox.Text, out numberOfSteps);
            numberOfSteps--;
            if (!parseSuccess || numberOfSteps < 2)
            {
                NodeBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter an integer > 2!", "Number of Nodes");
                numberOfSteps = -1;
            }
            else
            {
                NodeBox.ForeColor = Color.Black;
            }
        }

        //display "Lambda" or "Sigma" based on the selected method
        private void MethodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(MethodBox.SelectedIndex)
            {
                case 0:
                    LambdaBox.Enabled = false;
                    break;
                case 2:
                    LambdaLabel.Text = "Sigma";
                    LambdaBox.Enabled = true;
                    break;
                default:
                    LambdaLabel.Text = "Lambda";
                    LambdaBox.Enabled = true;
                    break;
            }
        }

        //find the minimum and maximum values for the computed solution
        private double[] FindMinMax(PointPairList ComputedFunction)
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

        //ressize the graph pane if the window is resized
        private void Form1_Resize_1(object sender, EventArgs e)
        {
            GraphPane.Location = new Point(13, 99);
            GraphPane.IsShowPointValues = true;
            GraphPane.Size = new Size(ClientRectangle.Width - 27, ClientRectangle.Height - 112);
        }

        #region Enter Key pressed in ComboBox -> initiate Draw()
        private void CheckIfEnterIsPressed(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DrawButton.PerformClick();
            }
        }

        private void ProblemBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void MethodBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void NodeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void EpsilonBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void PhiBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void LambdaBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }
        #endregion
    }
}
