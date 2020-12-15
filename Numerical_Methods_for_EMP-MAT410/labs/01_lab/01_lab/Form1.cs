using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using System.IO;
using System.Text;

namespace _01_lab
{
    public partial class Form1 : Form
    {

        #region Data
        private int numberOfSteps;
        private int problemNumber;
        private float phi0;
        private float phi1;
        private float epsilon;
        private double error;
        private readonly Graph graph;
        #endregion

        public Form1()
        {
            InitializeComponent();
            graph = new Graph(GraphPane);
            ProblemBox.SelectedIndex = 0;
            MethodBox.SelectedIndex = 0;
            NodeBox.SelectedIndex = 0;
            Phi0Box.SelectedIndex = 1;
            Phi1Box.SelectedIndex = 3;
            EpsilonBox.SelectedIndex = 5;
            ErrorLabel.Text = "Relative Error: --";
        }

        private void CheckIfEnterIsPressed(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DrawButton.PerformClick();
            }
        }

        private void Form1_Resize_1(object sender, EventArgs e)
        {
            GraphPane.Location = new Point(13, 99);
            GraphPane.IsShowPointValues = true;
            GraphPane.Size = new Size(ClientRectangle.Width - 27, ClientRectangle.Height - 112);
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

        private void GetNumberOfSteps()
        {
            bool parseSuccess = int.TryParse(NodeBox.Text, out numberOfSteps);
            if (!parseSuccess || numberOfSteps < 2)
            {
                NodeBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter an integer > 1!", "Number of Nodes");
                numberOfSteps = -1;
            }
            else
            {
                NodeBox.ForeColor = Color.Black;
            }
        }

        private void GetPhi0()
        {
            bool parseSuccess = float.TryParse(Phi0Box.Text, out phi0);
            if (!parseSuccess)
            {
                Phi0Box.ForeColor = Color.Red;
                MessageBox.Show("Please enter a real number!", "Phi 0");
                phi0 = -1;
            }
            else
            {
                Phi0Box.ForeColor = Color.Black;
            }
        }

        private void GetPhi1()
        {
            bool parseSuccess = float.TryParse(Phi1Box.Text, out phi1);
            if (!parseSuccess)
            {
                Phi1Box.ForeColor = Color.Red;
                MessageBox.Show("Please enter a real number!", "Phi 1");
                phi1 = -1;
            }
            else
            {
                Phi1Box.ForeColor = Color.Black;
            }
        }
        private void GetEpsilon()
        {
            bool parseSuccess = float.TryParse(EpsilonBox.Text, out epsilon);
            if (!parseSuccess || epsilon <= 0)
            {
                EpsilonBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter a real number: 0 < epsilon!", "Epsilon");
                epsilon = -1;
            }
            else
            {
                EpsilonBox.ForeColor = Color.Black;
            }
        }

        private void CalculateError()
        {
            PointPairList computedSolution = FiniteDifference.GetResult();
            double
                maximumFunction = 0,
                maximumDifference = 0,
                difference,
                functionValue;
            Func<float, double> currFunc = Functions.GetSolutionFunction(problemNumber);
            float[] steps = FiniteDifference.GetSteps();
            // calculate the error as given in the lab
            // max abs difference between solution and computation over max value of solution
            for (int i = 0; i < steps.Length; i++)
            {
                functionValue = currFunc(steps[i]);
                difference = Math.Abs(functionValue - computedSolution[i].Y);
                maximumDifference = (maximumDifference > difference) ? maximumDifference : difference;
                maximumFunction = (maximumFunction > Math.Abs(functionValue)) ? maximumFunction : Math.Abs(functionValue);
            }
            error = maximumDifference / maximumFunction * 100;
        }

        private void LambdaBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void PhiBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void EpsilonBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void NodeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void MethodBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void ProblemBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private static void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            // variables for parameter cycling
            //bool error = false;
            //bool eps = false;

            //if (error && saveToDatCheckBox.Checked)
            //{
            //    int[] numbers_of_nodes = { 3, 5, 17, 33, 65, 129, 257, 513, 1000, 10000 };
            //    double[] errors = new double[numbers_of_nodes.Length];
            //    for (int ind = 0; ind < numbers_of_nodes.Length; ++ind)
            //    {
            //        //get the problem parameters
            //        problemNumber = ProblemBox.SelectedIndex;
            //        //GetEpsilon();
            //        epsilon = 0.05f;
            //        //GetNumberOfSteps();
            //        numberOfSteps = numbers_of_nodes[ind];
            //        GetPhi0();
            //        GetPhi1();
            //        bool isRobin = ProblemBox.SelectedIndex == 1 || ProblemBox.SelectedIndex == 3;
            //        if (epsilon != -1 && phi1 != -1 && numberOfSteps != -1 && phi0 != -1)
            //        {
            //            Functions.SetParameters(problemNumber, phi0, phi1, epsilon);
            //            Functions.ComputeSolution();

            //            FiniteDifference.SetParameters(problemNumber, numberOfSteps);
            //            switch (MethodBox.SelectedIndex)
            //            {
            //                case 0:
            //                    FiniteDifference.ComputeFiniteDifference(FiniteDifference.Scheme.CentralDifference);
            //                    break;
            //                case 1:
            //                    FiniteDifference.ComputeFiniteDifference(FiniteDifference.Scheme.Ilin);
            //                    break;
            //            }

            //            MonotoneLabel.Text = FiniteDifference.IsMonotone() ? "Monotone: True" : "Monotone: False";
            //            CalculateError();
            //            errors[ind] = this.error;
            //        }
            //    }

            //    // for the analytic solution
            //    var csv = new StringBuilder();

            //    // make the header
            //    var first = "n";
            //    var second = "err";
            //    var newLine = $"{first}    {second}";
            //    csv.AppendLine(newLine);

            //    for (int i = 0; i < numbers_of_nodes.Length; ++i)
            //    {
            //        first = numbers_of_nodes[i].ToString();
            //        second = errors[i].ToString();
            //        newLine = $"{first}    {second}";
            //        csv.AppendLine(newLine);
            //    }

            //    String filename = $"{ProblemBox.SelectedItem}_{MethodBox.SelectedItem}_steps_e-{epsilon}_p1-{phi0}_p2-{phi1}_errors.dat";
            //    File.WriteAllText(filename, csv.ToString());
            //}
            //else if (eps && saveToDatCheckBox.Checked)
            //{
            //    float[] epsilons = { 1, 0.5f, 0.25f, 0.1f, 0.05f, 0.01f, 0.005f, 0.001f, 0.0001f };
            //    double[] errors = new double[epsilons.Length];
            //    for (int ind = 0; ind < epsilons.Length; ++ind)
            //    {
            //        //get the problem parameters
            //        problemNumber = ProblemBox.SelectedIndex;
            //        //GetEpsilon();
            //        epsilon = epsilons[ind];
            //        //GetNumberOfSteps();
            //        numberOfSteps = 33;
            //        GetPhi0();
            //        GetPhi1();
            //        bool isRobin = ProblemBox.SelectedIndex == 1 || ProblemBox.SelectedIndex == 3;
            //        if (epsilon != -1 && phi1 != -1 && numberOfSteps != -1 && phi0 != -1)
            //        {
            //            Functions.SetParameters(problemNumber, phi0, phi1, epsilon);
            //            Functions.ComputeSolution();

            //            FiniteDifference.SetParameters(problemNumber, numberOfSteps);
            //            switch (MethodBox.SelectedIndex)
            //            {
            //                case 0:
            //                    FiniteDifference.ComputeFiniteDifference(FiniteDifference.Scheme.CentralDifference);
            //                    break;
            //                case 1:
            //                    FiniteDifference.ComputeFiniteDifference(FiniteDifference.Scheme.Ilin);
            //                    break;
            //            }

            //            MonotoneLabel.Text = FiniteDifference.IsMonotone() ? "Monotone: True" : "Monotone: False";
            //            CalculateError();
            //            errors[ind] = this.error;
            //        }
            //    }

            //    // for the analytic solution
            //    var csv = new StringBuilder();

            //    // make the header
            //    var first = "eps";
            //    var second = "err";
            //    var third = "monotone";
            //    var newLine = $"{first}    {second}    {third}";
            //    csv.AppendLine(newLine);

            //    for (int i = 0; i < epsilons.Length; ++i)
            //    {
            //        first = epsilons[i].ToString();
            //        second = errors[i].ToString();
            //        third = FiniteDifference.IsMonotone().ToString();
            //        newLine = $"{first}    {second}    {third}";
            //        csv.AppendLine(newLine);
            //    }

            //    String filename = $"{ProblemBox.SelectedItem}_{MethodBox.SelectedItem}_33_eps_p1-{phi0}_p2-{phi1}_errors.dat";
            //    File.WriteAllText(filename, csv.ToString());
            //}
            //else
            //{
            //get the problem parameters
            problemNumber = ProblemBox.SelectedIndex;
            //if (problemNumber == 2)
            //{
            //    ++problemNumber;
            //}
            GetEpsilon();
            GetNumberOfSteps();
            GetPhi0();
            GetPhi1();
            bool isRobin = ProblemBox.SelectedIndex == 1 || ProblemBox.SelectedIndex == 3;
            if (epsilon != -1 && phi1 != -1 && numberOfSteps != -1 && phi0 != -1)
            {
                Functions.SetParameters(problemNumber, phi0, phi1, epsilon);
                Functions.ComputeSolution();

                FiniteDifference.SetParameters(problemNumber, numberOfSteps);
                switch (MethodBox.SelectedIndex)
                {
                    case 0:
                        FiniteDifference.ComputeFiniteDifference(FiniteDifference.Scheme.CentralDifference);
                        break;
                    case 1:
                        FiniteDifference.ComputeFiniteDifference(FiniteDifference.Scheme.Ilin);
                        break;
                }

                MonotoneLabel.Text = FiniteDifference.IsMonotone() ? "Monotone: True" : "Monotone: False";
                stabilityLabel.Text = FiniteDifference.IsStable() ? "Stable: True" : "Stable: False";

                Draw();

                //if (saveToDatCheckBox.Checked)
                //{
                //    WriteGraphsToFile();
                //}
                //}
            }
        }

        private void Draw()
        {
            //draw the graph
            graph.Clear();
            graph.SetTitle(ProblemBox.Text, numberOfSteps);
            graph.SetAxis(FindMinMax(Functions.GetSolutionPointPairList()));
            graph.AddCurve("Solution", Functions.GetSolutionPointPairList(), true, 2.5f, Color.Red, SymbolType.None);
            graph.AddCurve("Computation", FiniteDifference.GetResult(), true, 2.5f, Color.Blue, SymbolType.Diamond);
            CalculateError();
            //output the error value
            ErrorLabel.Text = string.Format("Relative Error: {0:F8} %", error);
            graph.Refresh();
        }

        // save the coordinates of the calculated points to a file for graphing
        //private void WriteGraphsToFile()
        //{
        //    // for the analytic solution
        //    var csv = new StringBuilder();

        //    // make the header
        //    var first = "x";
        //    var second = "u(x)";
        //    var newLine = $"{first}    {second}";
        //    csv.AppendLine(newLine);

        //    Functions.ComputeSolution(200);
        //    PointPairList list = Functions.GetSolutionPointPairList();
        //    long len = list.Count;

        //    for (int i = 0; i < len; ++i)
        //    {
        //        first = list[i].X.ToString();
        //        second = list[i].Y.ToString();
        //        newLine = $"{first}    {second}";
        //        csv.AppendLine(newLine);
        //    }

        //    String filename = $"{ProblemBox.SelectedItem}_{MethodBox.SelectedItem}_{numberOfSteps}_e-{epsilon}_p1-{phi0}_p2-{phi1}_analytic.dat";
        //    File.WriteAllText(filename, csv.ToString());

        //    // for the computed solution
        //    csv = new StringBuilder();

        //    // make the header
        //    first = "x_i";
        //    second = "u(x_i)";
        //    newLine = $"{first}    {second}";
        //    csv.AppendLine(newLine);

        //    list = FiniteDifference.GetResult();
        //    len = list.Count;

        //    for (int i = 0; i < len; ++i)
        //    {
        //        first = list[i].X.ToString();
        //        second = list[i].Y.ToString();
        //        newLine = $"{first}    {second}";
        //        csv.AppendLine(newLine);
        //    }

        //    filename = $"{ProblemBox.SelectedItem}_{MethodBox.SelectedItem}_{numberOfSteps}_e-{epsilon}_p1-{phi0}_p2-{phi1}_numerical.dat";
        //    File.WriteAllText(filename, csv.ToString());
        //}

        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
