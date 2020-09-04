using ZedGraph;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace Lagrange1._1
{

    /*
     * Finsished:
     * -graph error - done
     * -make graph saveable as picture file - done
     * 
     * 
     * TODO:
     * -implement safety for problem 11 for the epsilon values
     * -checkboxes for the individual graphs
     * -nevilles method
     * -make a function that tells you the optimal combination nodes and mesh to get to a certain error
     * -return the results in a file
     * -interpolation of the function - somewhat done
     */


    partial class Form1
    {

        #region SystemSetup
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region InitFunctions
        //#############################################################################################################
        // some init functions 
        //#############################################################################################################
        //the initial graph display
        private void initializeGraph()
        {
            GraphPane myPane = ZedGraphControl1.GraphPane;
            myPane.Title.Text = "Lagrange Interpolation";
            myPane.XAxis.Title.Text = "X Axis";
            myPane.YAxis.Title.Text = "Y Axis";
        }

        //initialize the comboboxes with the given idexes
        private void initializeComboBoxes()
        {
            MeshBox.SelectedIndex = 0;
            NodeBox.SelectedIndex = 0;
            ProblemBox.SelectedIndex = 0;
            EpsilonBox.SelectedIndex = 0;
            errorLabel.Text = "max |Error|:";
        }
        #endregion

        #region ProblemFunctions
        //#############################################################################################################
        // functons based on the problems given 
        //#############################################################################################################
        //problem 1
        public double func1(double x, double epsilon)
        {
            return (1 - Math.Exp(-x / epsilon)) / (1 - Math.Exp(-1 / epsilon));
        }

        //problem 2
        public double func2(double x, double epsilon)
        {
            return 1 - (((Math.Exp(-x / Math.Sqrt(epsilon)) + Math.Exp((x - 1) / Math.Sqrt(epsilon))) / (1 + (Math.Exp(-1 / Math.Sqrt(epsilon))))));
        }

        //problem 3
        public double func3(double x, double epsilon)
        {
            return (((Math.Exp(-(1 - x) / epsilon) - Math.Exp( - 1 / epsilon)) / (1 - (Math.Exp(-1 / epsilon)))));
        }

        //problem 4
        public double func4(double x, double epsilon)
        {
            return (Math.Log(1 + (x / epsilon)) / Math.Log(1 + (1 / epsilon)));
        }

        //problem 5
        public double func5(double x, double epsilon)
        {
            return Math.Cos((Math.PI * x) / epsilon);
        }

        //problem 6
        public double func6(double x, double epsilon)
        {
            return x * Math.Sin((Math.PI * x) / epsilon);
        }

        //problem 7
        public double func7(double x, double epsilon)
        {
            return (epsilon / (epsilon + Math.Pow((2 * x - 1), 2)));
        }

        //problem 8
        public double func8(double x, double epsilon)
        {
            if (x == 0)
                return 0;
            else
                return Math.Exp(-((1 - x)/(epsilon * x)));
        }

        //problem 9
        public double func9(double x, double epsilon)
        {
            if (x == 0)
                return 0;
            else
                return x * Math.Log(1 / x);
        }

        //problem 10
        public double func10(double x, double epsilon)
        {
            if (x <= 0.5)
                return (-2.0 / 3) * (Math.Exp((2 * x - 1) / epsilon) - 1) / (Math.Exp((2 * x - 1) / epsilon) + 1);
            else
                return (-2.0 / 3) * (1 - Math.Exp((1 - 2 * x) / epsilon)) / (1 + Math.Exp((1 - 2 * x) / epsilon));
        }

        //problem 11
        public double func11(double x, double epsilon)
        {
            if (x < 0.5 - epsilon)
                return 0.5;
            else if (x <= 0.5 + epsilon)
                return (1 - 2 * x) / (4 * epsilon);
            else
                return -0.5;
        }

        //problem 12
        public double func12(double x, double epsilon)
        {
            if (x < epsilon / 2)
                return 2 * x / epsilon;
            else if (x < 1 - epsilon / 2)
                return 1;
            else
                return 2*(1-x) / epsilon;
        }

        //problem 13
        public double func13(double x, double epsilon)
        {
            if (x <= (1 - epsilon) / 2)
                return 0;
            else if (x <= 0.5)
                return (2 * x - 1) / epsilon;
            else if (x <= (1 + epsilon) / 2)
                return (1 - 2 * x) / epsilon;
            else
                return 0;
        }

        //problem 14
        //TODO find some interesting function
        public double func14(double x, double epsilon)
        {
            return 1;
        }
        #endregion

        #region LagrangeInterpolation
        //#############################################################################################################
        // functions that read input from the comboboxes of Form1
        //#############################################################################################################
        //TODO: check the degree of polynomial to see if it is n-1 - it is not, i have n nodes, so the polynomial should be of degree n-1
        //      plot the error as f(x)-p(x) in a small window - done in normal window
        public PointPairList lagrangeInterpolation(PointPairList nodeList)
        {
            PointPairList result = new PointPairList();
            int N = nodeList.Count;
            double partResult = 0;
            double step = 0.001;

            for (double x = 0; x <= 1; x += step){

                partResult = 0;
                for (int k = 0; k < N; k++)
                {
                    double term = nodeList[k].Y;
                    for (int i = 0; i < N; i++)
                    {
                        if (k != i)
                            term *= (x - nodeList[i].X) / (nodeList[k].X - nodeList[i].X);
                        // Compute individual terms of w(x), the product function
                    }
                    // Add current term to result, the sum function
                    partResult += term;
                }
                result.Add(x, partResult);
            }
            return result;
        }

        public PointPairList LagrangeError(PointPairList original, PointPairList lagrange)
        {
            PointPairList error = new PointPairList();
            for (int i = 0; i < lagrange.Count; i++)
            {
                error.Add(lagrange[i].X, (original[i].Y - lagrange[i].Y));
            }
            return error;
        }

        public void maxError(PointPairList error)
        {
            double max = 0, compare;
            foreach (PointPair point in error)
            {
                compare = Math.Abs(point.Y);
                max = (compare > max) ? compare : max;
            }
            errorLabel.Text = String.Format("max |Error|: {0:E3}", max);
        }

        #endregion

        #region InteractionFunctions
        //#############################################################################################################
        // functions that read input from the comboboxes of Form1
        //#############################################################################################################
        //get number of nodes or greet points
        public int getNNodes()
        {
            int nNodes = -1;
            bool parseSuccess = int.TryParse(NodeBox.Text, out nNodes);
            if (!parseSuccess || nNodes < 2)
            {
                NodeBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter an integer >1!", "Number of Nodes");
            }
            else
            {
                NodeBox.ForeColor = Color.Black;
            }
            return nNodes;
        }

        //get the size of epsilon
        public double getEpsilon()
        {
            double epsilon = -1;
            bool parseSuccess = double.TryParse(EpsilonBox.Text, out epsilon);
            if (!parseSuccess && !(epsilon > 0))
            {
                EpsilonBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter a positive real number!", "Parameter Epsilon");
            }
            else
                EpsilonBox.ForeColor = Color.Black;
            return epsilon;
        }

        //get the type of mesh
        public int getMeshType()
        {
            if (MeshBox.SelectedIndex == 0)
                return 0;
            else
                return 1;
        }

        //get the problem text/title
        public string getProblemText()
        {
            return ProblemBox.Text;
        }

        //get the problem number
        public int getProblemNumber()
        {
            return ProblemBox.SelectedIndex;
        }

        //saving a screenshot fo the graph to some directory
        public void saveGraph()
        {
            //By Arsen Mkrtchyan on StackOverflow, 22.07.2009
            //https://stackoverflow.com/questions/1163761/capture-screenshot-of-active-window
            Rectangle bounds = this.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }

                //By Multiple Contributors on MSDN, 30.03.2017
                //https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-save-files-using-the-savefiledialog-component
                var folderBrowserDialog1 = new FolderBrowserDialog();
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog1.Title = "Save the image of the graph";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.  
                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            bitmap.Save(fs, ImageFormat.Jpeg);
                            break;
                        case 2:
                            bitmap.Save(fs, ImageFormat.Bmp);
                            break;
                    }
                    fs.Close();
                }
            }
        }

        public void exportData()
        {
            //By Multiple Contributors on MSDN, 30.03.2017
            //https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-save-files-using-the-savefiledialog-component
            var folderBrowserDialog1 = new FolderBrowserDialog();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV File|*.csv";
            saveFileDialog1.Title = "Save the data of the graph";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();                
                //string csv = String.Join(",", originalFunction.Select(x => x.ToString()).ToArray());
                fs.Close();
            }
        }

        #endregion

        #region PointFunctions
        //#############################################################################################################
        // the functions that return the pointlists for nodes and functions
        //#############################################################################################################
        public double[] cherbyshevMesh (int nNodes)
        {
            List<double> Nodes = new List<double>();
            for (int n = 1; n <= nNodes; n++)
            {
                Nodes.Add(0.5 + 0.5 * Math.Cos((2.0 * n - 1) / (2.0 * nNodes) * Math.PI));
            }
            Nodes.Sort();
            return Nodes.ToArray();
        }

        public double[] normalMesh(int nNodes)
        {
            List<double> nodeList = new List<double>();
            double nodeStep = 1.0 / (nNodes - 1);
            for (double x = 0; x <= 1; x += nodeStep)
            {
                nodeList.Add(x);
            }
            
            return nodeList.ToArray();
        }
        #endregion

        #region PlotFunction
        //#############################################################################################################
        // the function to draw both the original function and the interpolation function
        //#############################################################################################################
        //constants for the graphing

        public void graphFunction()
        {
            //constants
            double loopStart = 0.0;
            double loopEnd = 1.0;
            double loopStep = 0.001;
            //retrieving user input + variables
            int nodes = getNNodes();
            int problemNumber = getProblemNumber();
            int MeshType = (MeshBox.SelectedIndex);
            string title = getProblemText();
            double epsilon = getEpsilon();
            double nodeStep = 1 / (nodes - 1);

            //setting up graphing area
            PointPairList originalFunction = new PointPairList();
            PointPairList interpolation = new PointPairList();
            PointPairList nodeList = new PointPairList();
            double[] xNodes = new double[nodes];
            GraphPane graphPane = ZedGraphControl1.GraphPane;
            graphPane.Title.Text = title;
            graphPane.CurveList.Clear();
            graphPane.XAxis.Title.Text = "X Axis";
            graphPane.YAxis.Title.Text = "Y Axis";
            graphPane.XAxis.Scale.MajorStep = .1;
            graphPane.YAxis.Scale.MajorStep = .1;
            graphPane.XAxis.Scale.Min = -0.25;
            graphPane.XAxis.Scale.Max = 1.25;

            if (MeshType == 0)
            {
                xNodes = normalMesh(nodes);
            }
            else if (MeshType == 1)
            {
                xNodes = cherbyshevMesh(nodes);
            }

            //calculate the data points for the original function
            switch (problemNumber)
            {
                //problem 1
                case 0:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func1(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func1(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -0.25;
                    graphPane.YAxis.Scale.Max = 1.25;
                    break;
                //problem 2
                case 1:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func2(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func2(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -0.5;
                    graphPane.YAxis.Scale.Max = 1.25;
                    break;
                //problem 3
                case 2:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func3(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func3(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -0.5;
                    graphPane.YAxis.Scale.Max = 1.25;
                    break;
                //problem 4
                case 3:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func4(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func4(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -0.25;
                    graphPane.YAxis.Scale.Max = 1.25;
                    break;
                //problem 5
                case 4:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func5(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func5(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -1.25;
                    graphPane.YAxis.Scale.Max = 1.25;
                    break;
                //problem 6
                case 5:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func6(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func6(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -1.25;
                    graphPane.YAxis.Scale.Max = 1.25;
                    break;
                //problem 7
                case 6:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func7(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func7(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -0.25;
                    graphPane.YAxis.Scale.Max = 1.25;
                    break;
                //problem 8
                case 7:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func8(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func8(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -0.25;
                    graphPane.YAxis.Scale.Max = 1.25;
                    break;
                //problem 9
                case 8:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func9(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func9(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -0.25;
                    graphPane.YAxis.Scale.Max = 1.25;
                    break;
                //problem 10
                case 9:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func10(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func10(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -0.8;
                    graphPane.YAxis.Scale.Max = 0.8;
                    break;
                //problem 11
                case 10:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func11(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func11(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -0.75;
                    graphPane.YAxis.Scale.Max = 0.75;
                    break;
                //problem 12
                case 11:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func12(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func12(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -0.25;
                    graphPane.YAxis.Scale.Max = 1.25;
                    break;
                //problem 13
                case 12:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func13(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func13(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -1.25;
                    graphPane.YAxis.Scale.Max = 0.25;
                    break;
                //problem 14
                case 13:
                    //calculating the original function
                    for (double x = loopStart; x <= loopEnd; x += loopStep)
                    {
                        originalFunction.Add(x, func1(x, epsilon));
                    }
                    //caluculaing the greet points
                    foreach (double x in xNodes)
                    {
                        nodeList.Add(x, func14(x, epsilon));
                    }
                    //setting appropriate axes
                    graphPane.YAxis.Scale.Min = -0.25;
                    graphPane.YAxis.Scale.Max = 1.25;
                    break;
            }

            interpolation = lagrangeInterpolation(nodeList);

            PointPairList error = LagrangeError(originalFunction, interpolation);

            //Graph the function
            LineItem originalLine = graphPane.AddCurve("Test Function", originalFunction, Color.Blue, SymbolType.None);
            originalLine.Line.IsVisible = true;
            originalLine.Line.Fill.Color = Color.Blue;
            originalLine.Symbol.Fill.Type = FillType.Solid;
            originalLine.Line.Width = 1.5f;

            //lagrange
            LineItem interpoline = graphPane.AddCurve("Interpolation", interpolation, Color.Red, SymbolType.None);
            interpoline.Line.IsVisible = true;
            interpoline.Line.Fill.Color = Color.Red;
            interpoline.Symbol.Fill.Type = FillType.Solid;
            interpoline.Line.Width = 2;

            //error
            LineItem errorLine = graphPane.AddCurve("Error", error, Color.Black, SymbolType.None);
            errorLine.Line.IsVisible = true;
            errorLine.Line.Fill.Color = Color.Black;
            errorLine.Symbol.Fill.Type = FillType.Solid;
            errorLine.Line.Width = 1;

            maxError(error);

            //Graph the greet points
            LineItem nodeLine = graphPane.AddCurve("Nodes", nodeList, Color.Red, SymbolType.Diamond);
            nodeLine.Line.IsVisible = false;
            nodeLine.Symbol.Fill.Color = Color.Red;
            nodeLine.Symbol.Fill.Type = FillType.Solid;
            nodeLine.Symbol.Size = 5;

            //refresh the graph pane
            ZedGraphControl1.Refresh();
        }
        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NodeBox = new System.Windows.Forms.ComboBox();
            this.EpsilonBox = new System.Windows.Forms.ComboBox();
            this.ProblemBox = new System.Windows.Forms.ComboBox();
            this.MeshBox = new System.Windows.Forms.ComboBox();
            this.DrawButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ZedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.SaveGraphButton = new System.Windows.Forms.Button();
            this.EquationBox = new System.Windows.Forms.PictureBox();
            this.exportDataButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EquationBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(528, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Nodes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(683, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Parameter Epsilon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Problem";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(841, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mesh Type";
            // 
            // NodeBox
            // 
            this.NodeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NodeBox.FormattingEnabled = true;
            this.NodeBox.ItemHeight = 17;
            this.NodeBox.Items.AddRange(new object[] {
            "3",
            "9",
            "17",
            "33",
            "65",
            "125",
            "257",
            "513"});
            this.NodeBox.Location = new System.Drawing.Point(528, 30);
            this.NodeBox.Margin = new System.Windows.Forms.Padding(4);
            this.NodeBox.Name = "NodeBox";
            this.NodeBox.Size = new System.Drawing.Size(150, 25);
            this.NodeBox.TabIndex = 4;
            this.NodeBox.Leave += new System.EventHandler(this.NodeBox_Leave);
            // 
            // EpsilonBox
            // 
            this.EpsilonBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EpsilonBox.FormattingEnabled = true;
            this.EpsilonBox.ItemHeight = 17;
            this.EpsilonBox.Items.AddRange(new object[] {
            "1",
            "0.5",
            "0.25",
            "0.125",
            "0.0625",
            "0.03125",
            "0.015625",
            "0.0078125",
            "0.00390625",
            "0.001953125"});
            this.EpsilonBox.Location = new System.Drawing.Point(686, 30);
            this.EpsilonBox.Margin = new System.Windows.Forms.Padding(4);
            this.EpsilonBox.Name = "EpsilonBox";
            this.EpsilonBox.Size = new System.Drawing.Size(150, 25);
            this.EpsilonBox.TabIndex = 5;
            this.EpsilonBox.Leave += new System.EventHandler(this.ParameterBox_Leave);
            // 
            // ProblemBox
            // 
            this.ProblemBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProblemBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProblemBox.FormattingEnabled = true;
            this.ProblemBox.ItemHeight = 17;
            this.ProblemBox.Items.AddRange(new object[] {
            "Problem 1",
            "Problem 2",
            "Problem 3",
            "Problem 4",
            "Problem 5",
            "Problem 6",
            "Problem 7",
            "Problem 8",
            "Problem 9",
            "Problem 10",
            "Problem 11",
            "Problem 12",
            "Problem 13",
            "Problem 14"});
            this.ProblemBox.Location = new System.Drawing.Point(13, 30);
            this.ProblemBox.Margin = new System.Windows.Forms.Padding(4);
            this.ProblemBox.Name = "ProblemBox";
            this.ProblemBox.Size = new System.Drawing.Size(119, 25);
            this.ProblemBox.TabIndex = 6;
            this.ProblemBox.SelectedIndexChanged += new System.EventHandler(this.ProblemBox_SelectedIndexChanged);
            // 
            // MeshBox
            // 
            this.MeshBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MeshBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeshBox.FormattingEnabled = true;
            this.MeshBox.ItemHeight = 17;
            this.MeshBox.Items.AddRange(new object[] {
            "Normal Mesh",
            "Chebyschev Mesh"});
            this.MeshBox.Location = new System.Drawing.Point(844, 30);
            this.MeshBox.Margin = new System.Windows.Forms.Padding(4);
            this.MeshBox.Name = "MeshBox";
            this.MeshBox.Size = new System.Drawing.Size(150, 25);
            this.MeshBox.TabIndex = 7;
            // 
            // DrawButton
            // 
            this.DrawButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawButton.Location = new System.Drawing.Point(528, 62);
            this.DrawButton.Margin = new System.Windows.Forms.Padding(4);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(150, 25);
            this.DrawButton.TabIndex = 8;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(844, 63);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(150, 25);
            this.ExitButton.TabIndex = 9;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ZedGraphControl1
            // 
            this.ZedGraphControl1.Location = new System.Drawing.Point(13, 128);
            this.ZedGraphControl1.Margin = new System.Windows.Forms.Padding(5);
            this.ZedGraphControl1.Name = "ZedGraphControl1";
            this.ZedGraphControl1.ScrollGrace = 0D;
            this.ZedGraphControl1.ScrollMaxX = 0D;
            this.ZedGraphControl1.ScrollMaxY = 0D;
            this.ZedGraphControl1.ScrollMaxY2 = 0D;
            this.ZedGraphControl1.ScrollMinX = 0D;
            this.ZedGraphControl1.ScrollMinY = 0D;
            this.ZedGraphControl1.ScrollMinY2 = 0D;
            this.ZedGraphControl1.Size = new System.Drawing.Size(981, 603);
            this.ZedGraphControl1.TabIndex = 10;
            // 
            // SaveGraphButton
            // 
            this.SaveGraphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveGraphButton.Location = new System.Drawing.Point(528, 94);
            this.SaveGraphButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveGraphButton.Name = "SaveGraphButton";
            this.SaveGraphButton.Size = new System.Drawing.Size(150, 25);
            this.SaveGraphButton.TabIndex = 12;
            this.SaveGraphButton.Text = "Save Gaph";
            this.SaveGraphButton.UseVisualStyleBackColor = true;
            this.SaveGraphButton.Click += new System.EventHandler(this.SaveGraph_Click);
            // 
            // EquationBox
            // 
            this.EquationBox.Image = global::Lagrange1._1.Properties.Resources.func61;
            this.EquationBox.Location = new System.Drawing.Point(140, 9);
            this.EquationBox.Margin = new System.Windows.Forms.Padding(4);
            this.EquationBox.Name = "EquationBox";
            this.EquationBox.Size = new System.Drawing.Size(380, 110);
            this.EquationBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EquationBox.TabIndex = 11;
            this.EquationBox.TabStop = false;
            // 
            // exportDataButton
            // 
            this.exportDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportDataButton.Location = new System.Drawing.Point(686, 63);
            this.exportDataButton.Margin = new System.Windows.Forms.Padding(4);
            this.exportDataButton.Name = "exportDataButton";
            this.exportDataButton.Size = new System.Drawing.Size(150, 25);
            this.exportDataButton.TabIndex = 13;
            this.exportDataButton.Text = "Export Data";
            this.exportDataButton.UseVisualStyleBackColor = true;
            this.exportDataButton.Click += new System.EventHandler(this.ExportDataButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.Location = new System.Drawing.Point(685, 96);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(72, 18);
            this.errorLabel.TabIndex = 14;
            this.errorLabel.Text = "max error";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 745);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.exportDataButton);
            this.Controls.Add(this.SaveGraphButton);
            this.Controls.Add(this.EquationBox);
            this.Controls.Add(this.ZedGraphControl1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.MeshBox);
            this.Controls.Add(this.ProblemBox);
            this.Controls.Add(this.EpsilonBox);
            this.Controls.Add(this.NodeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1013, 784);
            this.Name = "Form1";
            this.Text = "Lagrange Interpolation";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.EquationBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox NodeBox;
        private System.Windows.Forms.ComboBox EpsilonBox;
        private System.Windows.Forms.ComboBox ProblemBox;
        private System.Windows.Forms.ComboBox MeshBox;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Button ExitButton;
        private ZedGraph.ZedGraphControl ZedGraphControl1;
        private PictureBox EquationBox;
        private Button SaveGraphButton;
        private Button exportDataButton;
        private System.Windows.Forms.Label errorLabel;
    }
}

