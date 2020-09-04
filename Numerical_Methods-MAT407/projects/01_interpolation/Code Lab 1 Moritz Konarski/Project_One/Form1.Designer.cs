using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ZedGraph;

namespace Project_One
{
    partial class Form1
    {

        #region SystemInit
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

        #region initFunctions
        // Set the indexes of the comboBoxes to 0 and create the graphPane object.
        private void InitializeUI()
        {
            // Initialize Graph.
            GraphPane myPane = graphWindow.GraphPane;
            // Initialize Boxes.
            MeshBox.SelectedIndex = 0;
            NodeBox.SelectedIndex = 0;
            ProblemBox.SelectedIndex = 0;
            EpsilonBox.SelectedIndex = 0;
            LagrangeRadioButton.Checked = true;
            // Set up the ToolTips.
            //ProblemToolTip.SetToolTip(ProblemBox, "Select test function");
            NumberOfNodesToolTip.SetToolTip(NodeBox, "Select number of interpolation nodes");
            EpsilonToolTip.SetToolTip(EpsilonBox, "Select parameter epsilon");
            MeshTypeToolTip.SetToolTip(MeshBox, "Select interpolation mesh");
            ProblemToolTip.SetToolTip(ProblemBox, "Select test problem");
            DrawButtonToolTip.SetToolTip(DrawButton, "Draw function and interpolation");
            ExitButtonToolTip.SetToolTip(ExitButton, "Exit program");
            SaveButtonToolTip.SetToolTip(SaveGraphButton, "Save screenshot of program");
            ErrorLabelToolTip.SetToolTip(ErrorLabel, "Largest error of the interpolation function");
            OptimizeButtonToolTip.SetToolTip(OptimizeButton, "Optimize interpolation for a given error");
            TimeLabelToolTip.SetToolTip(TimeLabel, "Time it took for the last computation");
            LagrangeRBToolTip.SetToolTip(LagrangeRadioButton, "Standard Lagrange interpolation");
            NevilleRBToolTip.SetToolTip(NevilleRadioButton, "Lagrange polynomial using Neville's Method");
        }
        #endregion

        #region IO
        // Save a screenshot on button press.
        void SaveImage()
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

        // Get the selected Problem number
        protected internal int GetProblemNumberInput()
        {
            return ProblemBox.SelectedIndex;
        }

        // Get the type of mesh.
        protected internal int GetMeshTypeInput()
        {
            return MeshBox.SelectedIndex;
        }

        // Get the value for epsilon.
        protected internal double GetEpsilonInput()
        {
            double epsilon = -1;
            bool parseSuccess = double.TryParse(EpsilonBox.Text, out epsilon);
            if (!parseSuccess && !(epsilon > 0))
            {
                EpsilonBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter a positive real number!", "Parameter Epsilon");
                epsilon = -1;
            }
            else
                EpsilonBox.ForeColor = Color.Black;
            return epsilon;
        }

        // Get the number of nodes.
        protected internal int GetNumberOfNodesInput()
        {
            int nNodes = -1;
            bool parseSuccess = int.TryParse(NodeBox.Text, out nNodes);
            if (!parseSuccess || nNodes < 2)
            {
                NodeBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter an integer >1!", "Number of Nodes");
                nNodes = -1;
            }
            else
            {
                NodeBox.ForeColor = Color.Black;
            }
            return nNodes;
        }

        // Get the method of interpolation
        protected internal int GetInterpolationMethod()
        {
            return (LagrangeRadioButton.Checked) ? 0 : 1;
        }
        #endregion

        #region Functions
        // Optimization with lagrange and normal nodes
        private void LagrangeWithNormalNodes(double minError, int minNumberOfNodes, int upperLimit)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // Start at three nodes
            int numberOfNodes = 3;
            Functions.ComputeFunction();
            // While the error is too large and the number of nodes is correct
            while (Data.GetGivenError() < Data.GetMaxError() && Data.GetNumberOfNodes() < upperLimit)
            {
                Data.SetNumberOfNodes(numberOfNodes);
                Nodes.ComputeNormalNodes();
                Functions.ComputeNodes();
                Interpolation.ComputeLagrange();
                Interpolation.ComputeError();
                // keep track of the lowest error and the corresponding number of nodes
                if (minError > Data.GetMaxError())
                {
                    minError = Data.GetMaxError();
                    minNumberOfNodes = numberOfNodes;
                }
                numberOfNodes++;
            }
            // If the error threshold was not reached and the last error was not the smallest
            if (minError < Data.GetMaxError())
            {
                // Use the smalles error to find the best interpolation
                numberOfNodes = minNumberOfNodes;
                Data.SetNumberOfNodes(numberOfNodes);
                Nodes.ComputeNormalNodes();
                Functions.ComputeNodes();
                Interpolation.ComputeLagrange();
                Interpolation.ComputeError();
            }
            YBounds.ComputeYLimits();
            watch.Stop();
            Data.SetComputationTime(watch.ElapsedMilliseconds);
        }

        // Optimization with lagrange and chebyshev nodes
        private void LagrangeWithChebyshevNodes(double minError, int minNumberOfNodes, int upperLimit)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int numberOfNodes = 3;
            Functions.ComputeFunction();
            // While the error is too large and the number of nodes is correct
            while (Data.GetGivenError() < Data.GetMaxError() && Data.GetNumberOfNodes() < upperLimit)
            {
                Data.SetNumberOfNodes(numberOfNodes);
                Nodes.ComputeChebyshevNodes();
                Functions.ComputeNodes();
                Interpolation.ComputeLagrange();
                Interpolation.ComputeError();
                // keep track of the lowest error and the corresponding number of nodes
                if (minError > Data.GetMaxError())
                {
                    minError = Data.GetMaxError();
                    minNumberOfNodes = numberOfNodes;
                }
                numberOfNodes++;
            }
            // If the error threshold was not reached and the last error was not the smallest
            if (minError < Data.GetMaxError())
            {
                // Use the smalles error to find the best interpolation
                numberOfNodes = minNumberOfNodes;
                Data.SetNumberOfNodes(numberOfNodes);
                Nodes.ComputeChebyshevNodes();
                Functions.ComputeNodes();
                Interpolation.ComputeLagrange();
                Interpolation.ComputeError();
            }
            YBounds.ComputeYLimits();
            watch.Stop();
            Data.SetComputationTime(watch.ElapsedMilliseconds);
        }

        // Optimization with neville and nomal nodes
        private void NevilleWithNormalNodes(double minError, int minNumberOfNodes, int upperLimit)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // Start at three nodes
            int numberOfNodes = 3;
            Functions.ComputeFunction();
            // While the error is too large and the number of nodes is correct
            while (Data.GetGivenError() < Data.GetMaxError() && Data.GetNumberOfNodes() < upperLimit)
            {
                Data.SetNumberOfNodes(numberOfNodes);
                Nodes.ComputeNormalNodes();
                Functions.ComputeNodes();
                Interpolation.ComputeNeville();
                Interpolation.ComputeError();
                // keep track of the lowest error and the corresponding number of nodes
                if (minError > Data.GetMaxError())
                {
                    minError = Data.GetMaxError();
                    minNumberOfNodes = numberOfNodes;
                }
                numberOfNodes++;
            }
            // If the error threshold was not reached and the last error was not the smallest
            if (minError < Data.GetMaxError())
            {
                // Use the smalles error to find the best interpolation
                numberOfNodes = minNumberOfNodes;
                Data.SetNumberOfNodes(numberOfNodes);
                Nodes.ComputeNormalNodes();
                Functions.ComputeNodes();
                Interpolation.ComputeNeville();
                Interpolation.ComputeError();
            }
            YBounds.ComputeYLimits();
            watch.Stop();
            Data.SetComputationTime(watch.ElapsedMilliseconds);
        }

        // Optimization with neville and chebyshev nodes
        private void NevilleWithChebyshevNodes(double minError, int minNumberOfNodes, int upperLimit)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int numberOfNodes = 3;
            Functions.ComputeFunction();
            // While the error is too large and the number of nodes is correct
            while (Data.GetGivenError() < Data.GetMaxError() && Data.GetNumberOfNodes() < upperLimit)
            {
                Data.SetNumberOfNodes(numberOfNodes);
                Nodes.ComputeChebyshevNodes();
                Functions.ComputeNodes();
                Interpolation.ComputeNeville();
                Interpolation.ComputeError();
                // keep track of the lowest error and the corresponding number of nodes
                if (minError > Data.GetMaxError())
                {
                    minError = Data.GetMaxError();
                    minNumberOfNodes = numberOfNodes;
                }
                numberOfNodes++;
            }
            // If the error threshold was not reached and the last error was not the smallest
            if (minError < Data.GetMaxError())
            {
                // Use the smalles error to find the best interpolation
                numberOfNodes = minNumberOfNodes;
                Data.SetNumberOfNodes(numberOfNodes);
                Nodes.ComputeChebyshevNodes();
                Functions.ComputeNodes();
                Interpolation.ComputeNeville();
                Interpolation.ComputeError();
            }
            YBounds.ComputeYLimits();
            watch.Stop();
            Data.SetComputationTime(watch.ElapsedMilliseconds);
        }

        // Graph the function.
        internal static void GraphFunctions(Graphing graph)
        {
            // Clear the graph pane
            graph.Clear();
            graph.GraphTestFunction(Color.Blue, 2F, SymbolType.None);
            graph.GraphNodePoints(Color.Red, 2F, SymbolType.Diamond);
            graph.GraphInterpolation(Color.Red, 2.5F, SymbolType.None);
            graph.GraphError(Color.Black, 1F, SymbolType.None);
            // Set the y axis to appropriate levels
            graph.SetAxis();
            graph.Refresh();
        }

        // Compute the function, nodes, interpolation and error.
        internal void ComputeFunctions()
        {
            // Get the input to calculate the function
            Data.SetEpsilon(GetEpsilonInput());
            Data.SetProblemNumber(GetProblemNumberInput());
            Data.SetNumberOfNodes(GetNumberOfNodesInput());
            Data.SetTypeOfMesh(GetMeshTypeInput());

            // Selecte the correct nodes by user selection
            switch (Data.GetTypeOfMesh())
            {
                case 0:
                    Nodes.ComputeNormalNodes();
                    break;
                case 1:
                    Nodes.ComputeChebyshevNodes();
                    break;
            }

            Functions.ComputeFunction();
            Functions.ComputeNodes();

            switch (GetInterpolationMethod())
            {
                case 0:
                    Interpolation.ComputeLagrange();
                    break;
                case 1:
                    Interpolation.ComputeNeville();
                    break;
            }
            
            Interpolation.ComputeError();

            YBounds.ComputeYLimits();
        }

        // Optimize the interpolation based on the users input
        internal void ComputeOptimization()
        {
            // Set the limit for the number of nodes to test
            const int upperLimit = 127;
            // Get the input values needed for the calculation
            Data.SetProblemNumber(GetProblemNumberInput());
            Data.SetEpsilon(GetEpsilonInput());
            Data.SetMaxError(10);

            // some instance variables
            double minError = 100;
            int minNumberOfNodes = 0;
            // Choosing the right mesh type
            switch (GetInterpolationMethod())
            {
                // Standard Method
                case 0:
                    switch (Data.GetTypeOfMesh())
                    {
                        // Normal mesh
                        case 0:
                            LagrangeWithNormalNodes(minError, minNumberOfNodes, upperLimit);
                            break;
                        // Chebyshev mesh
                        case 1:
                            LagrangeWithChebyshevNodes(minError, minNumberOfNodes, upperLimit);
                            break;
                    }
                    break;
                // Neville's Method
                case 1:
                    switch (Data.GetTypeOfMesh())
                    {
                        // Normal mesh
                        case 0:
                            NevilleWithNormalNodes(minError, minNumberOfNodes, upperLimit);
                            break;
                        // Chebyshev mesh
                        case 1:
                            NevilleWithChebyshevNodes(minError, minNumberOfNodes, upperLimit);
                            break;
                    }
                    break;
            }
            
        }

        // Display the max Error
        internal void SetLabels()
        {
            ErrorLabel.Text = string.Format("max |Error| = {0:E3}", Data.GetMaxError());

            TimeLabel.Text = string.Format("Time: {0} ms", Data.GetComputationTime());
        }
        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected internal void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.NumberOfNodesLabel = new System.Windows.Forms.Label();
            this.ParameterLabel = new System.Windows.Forms.Label();
            this.ProblemLabel = new System.Windows.Forms.Label();
            this.MeshLabel = new System.Windows.Forms.Label();
            this.NodeBox = new System.Windows.Forms.ComboBox();
            this.EpsilonBox = new System.Windows.Forms.ComboBox();
            this.MeshBox = new System.Windows.Forms.ComboBox();
            this.DrawButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.graphWindow = new ZedGraph.ZedGraphControl();
            this.SaveGraphButton = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.ProblemToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NumberOfNodesToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.EpsilonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MeshTypeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.DrawButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ExitButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SaveButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ExportDataButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ErrorLabelToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SelectProblemToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.OptimizeButton = new System.Windows.Forms.Button();
            this.OptimizationErrorLabel = new System.Windows.Forms.Label();
            this.ProblemBox = new System.Windows.Forms.ComboBox();
            this.LagrangeRadioButton = new System.Windows.Forms.RadioButton();
            this.NevilleRadioButton = new System.Windows.Forms.RadioButton();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.OptimizeButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.LagrangeRBToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NevilleRBToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TimeLabelToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // NumberOfNodesLabel
            // 
            this.NumberOfNodesLabel.AutoSize = true;
            this.NumberOfNodesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfNodesLabel.Location = new System.Drawing.Point(333, 6);
            this.NumberOfNodesLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.NumberOfNodesLabel.Name = "NumberOfNodesLabel";
            this.NumberOfNodesLabel.Size = new System.Drawing.Size(119, 17);
            this.NumberOfNodesLabel.TabIndex = 0;
            this.NumberOfNodesLabel.Text = "Number of Nodes";
            // 
            // ParameterLabel
            // 
            this.ParameterLabel.AutoSize = true;
            this.ParameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterLabel.Location = new System.Drawing.Point(173, 7);
            this.ParameterLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ParameterLabel.Name = "ParameterLabel";
            this.ParameterLabel.Size = new System.Drawing.Size(124, 17);
            this.ParameterLabel.TabIndex = 1;
            this.ParameterLabel.Text = "Parameter Epsilon";
            // 
            // ProblemLabel
            // 
            this.ProblemLabel.AutoSize = true;
            this.ProblemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProblemLabel.Location = new System.Drawing.Point(14, 9);
            this.ProblemLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ProblemLabel.Name = "ProblemLabel";
            this.ProblemLabel.Size = new System.Drawing.Size(60, 17);
            this.ProblemLabel.TabIndex = 2;
            this.ProblemLabel.Text = "Problem";
            // 
            // MeshLabel
            // 
            this.MeshLabel.AutoSize = true;
            this.MeshLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeshLabel.Location = new System.Drawing.Point(493, 8);
            this.MeshLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.MeshLabel.Name = "MeshLabel";
            this.MeshLabel.Size = new System.Drawing.Size(78, 17);
            this.MeshLabel.TabIndex = 3;
            this.MeshLabel.Text = "Mesh Type";
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
            this.NodeBox.Location = new System.Drawing.Point(336, 28);
            this.NodeBox.Margin = new System.Windows.Forms.Padding(5);
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
            this.EpsilonBox.Location = new System.Drawing.Point(176, 29);
            this.EpsilonBox.Margin = new System.Windows.Forms.Padding(5);
            this.EpsilonBox.Name = "EpsilonBox";
            this.EpsilonBox.Size = new System.Drawing.Size(150, 25);
            this.EpsilonBox.TabIndex = 5;
            this.EpsilonBox.Leave += new System.EventHandler(this.ParameterBox_Leave);
            // 
            // MeshBox
            // 
            this.MeshBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MeshBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeshBox.FormattingEnabled = true;
            this.MeshBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MeshBox.ItemHeight = 17;
            this.MeshBox.Items.AddRange(new object[] {
            "Normal Mesh",
            "Chebyschev Mesh"});
            this.MeshBox.Location = new System.Drawing.Point(496, 30);
            this.MeshBox.Margin = new System.Windows.Forms.Padding(5);
            this.MeshBox.Name = "MeshBox";
            this.MeshBox.Size = new System.Drawing.Size(150, 25);
            this.MeshBox.TabIndex = 7;
            // 
            // DrawButton
            // 
            this.DrawButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawButton.Location = new System.Drawing.Point(17, 64);
            this.DrawButton.Margin = new System.Windows.Forms.Padding(5);
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
            this.ExitButton.Location = new System.Drawing.Point(496, 63);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(5);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(150, 25);
            this.ExitButton.TabIndex = 9;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // graphWindow
            // 
            this.graphWindow.Location = new System.Drawing.Point(16, 118);
            this.graphWindow.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.graphWindow.MinimumSize = new System.Drawing.Size(921, 522);
            this.graphWindow.Name = "graphWindow";
            this.graphWindow.ScrollGrace = 0D;
            this.graphWindow.ScrollMaxX = 0D;
            this.graphWindow.ScrollMaxY = 0D;
            this.graphWindow.ScrollMaxY2 = 0D;
            this.graphWindow.ScrollMinX = 0D;
            this.graphWindow.ScrollMinY = 0D;
            this.graphWindow.ScrollMinY2 = 0D;
            this.graphWindow.Size = new System.Drawing.Size(921, 522);
            this.graphWindow.TabIndex = 10;
            // 
            // SaveGraphButton
            // 
            this.SaveGraphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveGraphButton.Location = new System.Drawing.Point(336, 64);
            this.SaveGraphButton.Margin = new System.Windows.Forms.Padding(5);
            this.SaveGraphButton.Name = "SaveGraphButton";
            this.SaveGraphButton.Size = new System.Drawing.Size(150, 25);
            this.SaveGraphButton.TabIndex = 12;
            this.SaveGraphButton.Text = "Save Gaph";
            this.SaveGraphButton.UseVisualStyleBackColor = true;
            this.SaveGraphButton.Click += new System.EventHandler(this.SaveGraph_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.Location = new System.Drawing.Point(14, 94);
            this.ErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(88, 18);
            this.ErrorLabel.TabIndex = 14;
            this.ErrorLabel.Text = "max |Error|:";
            // 
            // OptimizeButton
            // 
            this.OptimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptimizeButton.Location = new System.Drawing.Point(176, 64);
            this.OptimizeButton.Margin = new System.Windows.Forms.Padding(5);
            this.OptimizeButton.Name = "OptimizeButton";
            this.OptimizeButton.Size = new System.Drawing.Size(150, 25);
            this.OptimizeButton.TabIndex = 18;
            this.OptimizeButton.Text = "Optimize";
            this.OptimizeButton.UseVisualStyleBackColor = true;
            this.OptimizeButton.Click += new System.EventHandler(this.OptimizeButton_Click);
            // 
            // OptimizationErrorLabel
            // 
            this.OptimizationErrorLabel.AutoSize = true;
            this.OptimizationErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptimizationErrorLabel.Location = new System.Drawing.Point(333, 94);
            this.OptimizationErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OptimizationErrorLabel.Name = "OptimizationErrorLabel";
            this.OptimizationErrorLabel.Size = new System.Drawing.Size(149, 18);
            this.OptimizationErrorLabel.TabIndex = 19;
            this.OptimizationErrorLabel.Text = "optimization |Error| <";
            this.OptimizationErrorLabel.Visible = false;
            // 
            // ProblemBox
            // 
            this.ProblemBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProblemBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProblemBox.FormattingEnabled = true;
            this.ProblemBox.ImeMode = System.Windows.Forms.ImeMode.On;
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
            this.ProblemBox.Location = new System.Drawing.Point(17, 31);
            this.ProblemBox.Margin = new System.Windows.Forms.Padding(5);
            this.ProblemBox.Name = "ProblemBox";
            this.ProblemBox.Size = new System.Drawing.Size(150, 25);
            this.ProblemBox.TabIndex = 20;
            // 
            // LagrangeRadioButton
            // 
            this.LagrangeRadioButton.AutoSize = true;
            this.LagrangeRadioButton.Location = new System.Drawing.Point(654, 32);
            this.LagrangeRadioButton.Name = "LagrangeRadioButton";
            this.LagrangeRadioButton.Size = new System.Drawing.Size(218, 20);
            this.LagrangeRadioButton.TabIndex = 21;
            this.LagrangeRadioButton.TabStop = true;
            this.LagrangeRadioButton.Text = "Standard Lagrange Interpolation";
            this.LagrangeRadioButton.UseVisualStyleBackColor = true;
            // 
            // NevilleRadioButton
            // 
            this.NevilleRadioButton.AutoSize = true;
            this.NevilleRadioButton.Location = new System.Drawing.Point(654, 66);
            this.NevilleRadioButton.Name = "NevilleRadioButton";
            this.NevilleRadioButton.Size = new System.Drawing.Size(275, 20);
            this.NevilleRadioButton.TabIndex = 22;
            this.NevilleRadioButton.TabStop = true;
            this.NevilleRadioButton.Text = "Lagrange Polynomial by Neville\'s Method";
            this.NevilleRadioButton.UseVisualStyleBackColor = true;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(651, 96);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(45, 16);
            this.TimeLabel.TabIndex = 23;
            this.TimeLabel.Text = "Time: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 655);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.NevilleRadioButton);
            this.Controls.Add(this.LagrangeRadioButton);
            this.Controls.Add(this.ProblemBox);
            this.Controls.Add(this.OptimizationErrorLabel);
            this.Controls.Add(this.OptimizeButton);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.SaveGraphButton);
            this.Controls.Add(this.graphWindow);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.MeshBox);
            this.Controls.Add(this.EpsilonBox);
            this.Controls.Add(this.NodeBox);
            this.Controls.Add(this.MeshLabel);
            this.Controls.Add(this.ProblemLabel);
            this.Controls.Add(this.ParameterLabel);
            this.Controls.Add(this.NumberOfNodesLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Interpolation";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region initForms
        private System.Windows.Forms.Label NumberOfNodesLabel;
        private System.Windows.Forms.Label ParameterLabel;
        private System.Windows.Forms.Label ProblemLabel;
        private System.Windows.Forms.Label MeshLabel;
        private System.Windows.Forms.ComboBox NodeBox;
        private System.Windows.Forms.ComboBox EpsilonBox;
        private System.Windows.Forms.ComboBox MeshBox;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Button ExitButton;
        private ZedGraph.ZedGraphControl graphWindow;
        private Button SaveGraphButton;
        private System.Windows.Forms.Label ErrorLabel;
        private ToolTip ProblemToolTip;
        private ToolTip NumberOfNodesToolTip;
        private ToolTip EpsilonToolTip;
        private ToolTip MeshTypeToolTip;
        private ToolTip DrawButtonToolTip;
        private ToolTip ExitButtonToolTip;
        private ToolTip SaveButtonToolTip;
        private ToolTip ExportDataButtonToolTip;
        private ToolTip ErrorLabelToolTip;
        private ToolTip SelectProblemToolTip;
        private Button OptimizeButton;
        private System.Windows.Forms.Label OptimizationErrorLabel;
        private ComboBox ProblemBox;
        private RadioButton LagrangeRadioButton;
        private RadioButton NevilleRadioButton;
        private System.Windows.Forms.Label TimeLabel;
        #endregion

        private ToolTip OptimizeButtonToolTip;
        private ToolTip LagrangeRBToolTip;
        private ToolTip NevilleRBToolTip;
        private ToolTip TimeLabelToolTip;
    }
}
