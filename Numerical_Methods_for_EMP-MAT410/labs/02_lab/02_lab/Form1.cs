using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace _02_lab
{
    public partial class Form1 : Form
    {
        #region Private Data Fields
        private readonly Graph graph;
        private int N, M, tIndex = 0, parameterK;
        private static int analyticSpaceSteps = 1000, beta_type;
        private static double analyticH = 1.0 / (analyticSpaceSteps - 1.0);
        private static double epsilon, tmax, h, tau, K;
        private static double T1, T2, theta, error, max_error;
        private static double[] xValues, yValues, previousYValues, tValues, analyticXValues;
        private static bool graphNumericalSolution = true, graphExactSolution = true, adjustGraph = false, isMonotenous;
        private PointPairList exactSolution, numericalSolution;
        private static readonly double p = 0.3275911;
        private static readonly double a1 = 0.254829592;
        private static readonly double a2 = -0.284496736;
        private static readonly double a3 = 1.421413741;
        private static readonly double a4 = -1.453152027;
        private static readonly double a5 = 1.061405429;
        private static double a, b, c, a0, b0, c0;
        private static double[] f, alpha, beta;
        private static StringBuilder csv;
        private static readonly bool logError = false;
        #endregion

        public Form1()
        {
            InitializeComponent();
            graph = new Graph(GraphPane);
            SchemeComboBox.SelectedIndex = 0;
            KComboBox.SelectedIndex = 0;
            EComboBox.SelectedIndex = 0;
            SpaceNodeComboBox.SelectedIndex = 0;
            TimeNodeComboBox.SelectedIndex = 0;
            TimespanComboBox.SelectedIndex = 0;
            T1ComboBox.SelectedIndex = 0;
            T2ComboBox.SelectedIndex = 4;
            BetaComboBox.SelectedIndex = 0;
            exactSolution = new PointPairList();
            numericalSolution = new PointPairList();
            GetParameters();
        }

        private void SchemeComboBox_Leave(object sender, EventArgs e)
        {
            GetParameters();
        }

        private void EComboBox_Leave(object sender, EventArgs e)
        {
            GetParameters();
        }

        private void SpaceNodeComboBox_Leave(object sender, EventArgs e)
        {
            GetParameters();
        }

        private void TimeNodeComboBox_Leave(object sender, EventArgs e)
        {
            GetParameters();
        }

        private void TimespanComboBox_Leave(object sender, EventArgs e)
        {
            GetParameters();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            AnimationTimer.Stop();
            tIndex = 0;
            SetTimeLabel();
            graph.Clear();
            graph.Refresh();
            ErrorLabel.Text = "0 %";
        }

        private void NumericalSolutionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            graphNumericalSolution = NumericalSolutionCheckBox.Checked;
        }

        private void LocalMinMaxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            adjustGraph = LocalMinMaxCheckBox.Checked;
        }

        private void CourantBox_Leave(object sender, EventArgs e)
        {
            epsilon = Convert.ToDouble(EComboBox.Text);
            tmax = Convert.ToDouble(TimespanComboBox.Text);
            N = Convert.ToInt32(SpaceNodeComboBox.Text);
            h = 1.0 / (N - 1.0);
            K = Convert.ToDouble(CourantBox.Text);
            tau = K * h * h / epsilon;
            M = (int)(tmax / tau) + 1;
            TimeNodeComboBox.Text = M.ToString();
            tau = tmax / (M - 1.0);
            K = (epsilon * tau) / (h * h);
            CourantBox.Text = K.ToString();
        }

        private void ExactSolutionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            graphExactSolution = ExactSolutionCheckBox.Checked;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            GraphPane.Location = new Point(363, 16);
            GraphPane.IsShowPointValues = true;
            GraphPane.Size = new Size(ClientRectangle.Width - 376, ClientRectangle.Height - 30);
        }

        private void GetParameters()
        {
            epsilon = Convert.ToDouble(EComboBox.Text);
            tmax = Convert.ToDouble(TimespanComboBox.Text);
            N = Convert.ToInt32(SpaceNodeComboBox.Text);
            M = Convert.ToInt32(TimeNodeComboBox.Text);
            parameterK = Convert.ToInt32(KComboBox.Text);
            T1 = Convert.ToDouble(T1ComboBox.Text);
            T2 = Convert.ToDouble(T2ComboBox.Text);
            max_error = 0;

            h = 1.0 / (N - 1.0);
            tau = tmax / (M - 1.0);

            K = (epsilon * tau) / (h * h);

            SetCourantLabel();

            analyticXValues = new double[analyticSpaceSteps];
            xValues = new double[N];
            yValues = new double[N];
            tValues = new double[M];

            for (int i = 0; i < analyticSpaceSteps; ++i)
            {
                analyticXValues[i] = i * analyticH;
            }

            for (int i = 0; i < N; ++i)
            {
                xValues[i] = i * h;
            }

            for (int i = 0; i < M; ++i)
            {
                tValues[i] = i * tau;
            }

            switch (SchemeComboBox.SelectedIndex)
            {
                case 0:
                    theta = 0;
                    break;
                case 1:
                    theta = 0.5;
                    break;
                case 2:
                    theta = 1;
                    break;
                case 3:
                    theta = 0;
                    break;
            }
            if (SchemeComboBox.SelectedIndex == 3)
            {
                beta_type = BetaComboBox.SelectedIndex;
            }
            else
            {
                beta_type = -1;
            }
            isMonotenous = Math.Max(0, 1 - 1 / (2 * K)) <= theta;
            if (!isMonotenous && SchemeComboBox.SelectedIndex != 3)
            {
                CourantBox.ForeColor = Color.Red;
                CourantTextLabel.ForeColor = Color.Red;
            }
            else
            {
                CourantBox.ForeColor = Color.Black;
                CourantTextLabel.ForeColor = Color.Black;
            }
            a = theta * K;
            b = 1 + 2 * theta * K;
            c = theta * K;
            a0 = (1 - theta) * K;
            b0 = 1 - 2 * (1 - theta) * K;
            c0 = (1 - theta) * K;
            f = new double[N];
            alpha = new double[N];
            beta = new double[N];
        }

        private void KComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                parameterK = Convert.ToInt32(KComboBox.Text);
                EComboBox.Text = Math.Pow(2, -parameterK).ToString();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void InitializeErrorLog()
        {
            if (logError)
            {
                csv = new StringBuilder();
                csv.AppendLine($"t    error");
            }
        }

        private void LogError()
        {
            if (logError)
            {
                csv.AppendLine($"{tValues[tIndex]}    {error}");
            }
        }

        private void CloseLogger()
        {
            if (logError)
            {
                string filename = $"{SchemeComboBox.Text}_s{N}_t{M}_e{epsilon}_{T1}_{T2}_{K}_errors.dat";
                File.WriteAllText(filename, csv.ToString());
            }
        }

        private static double ErfFunction(double x)
        {
            if (x > 0)
            {
                double s = 1 / (1 + p * x);
                return 1 - (a1 * s + a2 * Math.Pow(s, 2) + a3 * Math.Pow(s, 3) + a4 * Math.Pow(s, 4) + a5 * Math.Pow(s, 5)) * Math.Exp(-Math.Pow(x, 2));
            }
            else
            {
                double s = 1 / (1 - p * x);
                return -(1 - (a1 * s + a2 * Math.Pow(s, 2) + a3 * Math.Pow(s, 3) + a4 * Math.Pow(s, 4) + a5 * Math.Pow(s, 5)) * Math.Exp(-Math.Pow(-x, 2)));
            }
        }

        private double AnalyticFunction(double x)
        {
            //double gam = Math.Sqrt(parameterK * Math.PI / (2 * epsilon));
            //double v1 = (Math.Cos(gam * x) * Math.Cosh(gam * (2.0 - x)) - Math.Cosh(gam * x) * Math.Cos(gam * (2.0 - x))) / (Math.Cosh(2.0 * gam) - Math.Cos(2.0 * gam));
            //double v2 = (Math.Sin(gam * x) * Math.Sinh(gam * (2.0 - x)) - Math.Sinh(gam * x) * Math.Sin(gam * (2.0 - x))) / (Math.Cosh(2.0 * gam) - Math.Cos(2.0 * gam));
            //return v1 * Math.Sin(Math.PI * parameterK * tValues[tIndex]) - v2 * Math.Cos(Math.PI * parameterK * tValues[tIndex]);
            if (tIndex == 0)
            {
                if (x < 0.5)
                {
                    return T1;
                }
                else if (x == 0.5)
                {
                    return (T1 + T2) / 2;
                }
                else
                {
                    return T2;
                }
            }
            else
            {
                return (T2 + T1) / 2 + (T2 - T1) / 2 * ErfFunction((2 * x - 1) / (4 * Math.Sqrt(epsilon * tValues[tIndex])));
            }
        }

        private double Psi0()
        {
            //return AnalyticFunction(0);
            return (T2 + T1) / 2 + (T2 - T1) / 2 * ErfFunction(-1 / (4 * Math.Sqrt(epsilon * tValues[tIndex])));
        }

        private double Psi1()
        {
            //return AnalyticFunction(1);
            return (T2 + T1) / 2 + (T2 - T1) / 2 * ErfFunction(1 / (4 * Math.Sqrt(epsilon * tValues[tIndex])));
        }

        private double Phi(double x)
        {
            //int temp = tIndex;
            //tIndex = 0;
            //double res = AnalyticFunction(x);
            //tIndex = temp;
            //return res;
            if (x < 0.5)
            {
                return T1;
            }
            else if (x == 0.5)
            {
                return (T1 + T2) / 2;
            }
            else
            {
                return T2;
            }
        }

        private void CalculateAnalyticalSolution()
        {
            exactSolution.Clear();
            foreach (double x in analyticXValues)
            {
                exactSolution.Add(x, AnalyticFunction(x));
            }
        }

        private double ZSum(double z, int exponent)
        {
            double r = 0;
            for (int i = 0; i < exponent; ++i)
            {
                r += Math.Pow(z, i);
            }
            return r;
        }

        private double B(double z)
        {
            if (beta_type == -1)
            {
                return 1;
            }
            else
            {
                switch (beta_type)
                {
                    case 0:
                        if (z <= 1)
                        {
                            return 1.0;
                        }
                        else
                        {
                            return 1.0 / z;
                        }
                    case 1:
                        if (z <= 2)
                        {
                            return 1 - z / 4.0;
                        }
                        else
                        {
                            return 1.0 / z;
                        }
                    case 2:
                        return (1.0 - Math.Exp(-z)) / z;
                    case 3:
                        int k = 5;
                        return ZSum(z, k - 1) / ZSum(z, k);
                    default:
                        return 0;
                }
            }
        }

        private void CalculateNumericalSolution()
        {
            numericalSolution.Clear();

            if (tIndex == 0)
            {
                int index = 0;
                foreach (double x in xValues)
                {
                    yValues[index++] = Phi(x);
                }
            }
            else
            {
                f[N - 1] = Psi1();
                f[0] = Psi0();

                for (int i = 1; i < N - 1; ++i)
                {
                    f[i] = B(2 * K) * (a0 * previousYValues[i - 1] + b0 * previousYValues[i] + c0 * previousYValues[i + 1]);
                }
                alpha[0] = 0;
                beta[0] = Psi0();
                for (int i = 1; i < N; ++i)
                {
                    alpha[i] = c / (b - alpha[i - 1] * a);
                    beta[i] = (f[i] + beta[i - 1] * a) / (b - alpha[i - 1] * a);
                }
                yValues[N - 1] = Psi1();
                for (int i = N - 2; i >= 0; --i)
                {
                    yValues[i] = alpha[i] * yValues[i + 1] + beta[i];
                }
            }

            previousYValues = (double[])(yValues.Clone());

            for (int i = 0; i < N; ++i)
            {
                numericalSolution.Add(xValues[i], yValues[i]);
            }
        }

        private void GraphFunctions()
        {
            graph.Clear();
            if (graphNumericalSolution)
            {
                graph.AddCurve("Numerical Solution", numericalSolution, true, 2.5f, Color.Blue, SymbolType.Diamond);
            }
            if (graphExactSolution)
            {
                graph.AddCurve("Excact Solution", exactSolution, true, 2.5f, Color.Red, SymbolType.None);
                if (adjustGraph)
                {
                    graph.SetAxis(FindMinMax(exactSolution));
                }
                else
                {
                    if (tIndex == 0)
                    {
                        graph.SetAxis(FindMinMax(exactSolution));
                    }
                }
            }
            graph.SetTitle(SchemeComboBox.Text, N, M, tValues[tIndex], tmax);
            graph.Refresh();
        }

        private void CalculateError()
        {
            double
                maximumFunction = 0,
                maximumDifference = 0,
                difference,
                functionValue;
            for (int i = 0; i < xValues.Length; ++i)
            {
                functionValue = AnalyticFunction(xValues[i]);
                difference = Math.Abs(functionValue - yValues[i]);
                maximumDifference = (maximumDifference > difference) ? maximumDifference : difference;
                maximumFunction = (maximumFunction > Math.Abs(functionValue)) ? maximumFunction : Math.Abs(functionValue);
            }
            error = maximumDifference / maximumFunction * 100;
            SetErrorLabel(error);
            max_error = max_error < error ? error : max_error;
            SetMaxErrorLabel(max_error);
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

        private void CalculateButtonClick(object sender, EventArgs e)
        {
            AnimationTimer.Stop();
            tIndex = 0;

            InitializeErrorLog();

            GetParameters();

            CalculateNumericalSolution();

            CalculateAnalyticalSolution();

            GraphFunctions();

            CalculateError();

            LogError();

            StepTimer();

            AnimationTimer.Start();
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void SetCourantLabel()
        {
            if (Double.IsNaN(K))
            {
                CourantBox.Text = "--";
            }
            else
            {
                CourantBox.Text = string.Format("{0:f5}", K);
            }
        }

        private void SetTimeLabel()
        {
            TimeLabel.Text = string.Format("{0:f5}", tValues[tIndex]);
        }

        private void SetErrorLabel(double error)
        {
            if (Double.IsNaN(error))
            {
                ErrorLabel.Text = "--";
            }
            else
            {
                ErrorLabel.Text = string.Format("{0:f5} %", error);
            }
        }

        private void SetMaxErrorLabel(double error)
        {
            if (Double.IsNaN(error))
            {
                ErrorLabel.Text = "--";
            }
            else
            {
                MaxErrLabel.Text = string.Format("{0:f5} %", error);
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            CalculateNumericalSolution();

            CalculateAnalyticalSolution();

            GraphFunctions();

            CalculateError();

            LogError();

            StepTimer();
        }

        private void StepButtonClick(object sender, EventArgs e)
        {
            GetParameters();

            AnimationTimer.Stop();

            CalculateNumericalSolution();

            CalculateAnalyticalSolution();

            GraphFunctions();

            CalculateError();

            StepTimer();
        }

        private void StepTimer()
        {
            SetTimeLabel();

            ++tIndex;

            if (tIndex >= M)
            {
                AnimationTimer.Stop();
                CloseLogger();
                tIndex = 0;
            }
        }
    }
}
