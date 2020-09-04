using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project2
{
    partial class NumericalIntegration
    {
        #region Data
        private object[] parameterRange1 = new object[] { "1", "2", "3", "4", "5"};
        private object[] parameterRange18 = new object[] { "0.5", "1", "1.5", "2", "2.5", "3", "3.5", "4", "4.5", "5" };
        private object[] thetaRange = new object[] { "0", "0.25", "0.5", "0.75", "1" };
        private object[] errorRange = new object[] { "0.5", "0.25", "0.125", "0.0625", "0.03125", "0.015625"};
        #endregion

        #region System Initialization
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

        #region Initialization
        // Initialize objects and UI.
        private void InitializeElements()
        {
            CenterToScreen();
            // Set graphing environment.
            Trapezoid.SetGraphPane(GraphWindow.GraphPane);
            graph = new Graph(GraphWindow, Color.LightBlue);
            // Set indices to 0;
            ProblemBox.SelectedIndex = 0;
            MethodBox.SelectedIndex = 0;
            ParameterBox.SelectedIndex = 0;
            NodesBox.SelectedIndex = 0;
            ThetaBox.SelectedIndex = 0;
            // Initialize Tooltips
            //NumberOfNodesToolTip.SetToolTip(NodeBox, "Select number of interpolation nodes");
        }
        #endregion

        #region Getters
        // Check and get the input of the number of nodes.
        private void GetNumberOfNodes()
        {
            bool parseSuccess = int.TryParse(NodesBox.Text, out numberOfNodes);
            if (!parseSuccess || numberOfNodes < 2)
            {
                NodesBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter an integer >1!", "Number of Nodes");
                numberOfNodes = -1;
            }
            else
            {
                NodesBox.ForeColor = Color.Black;
            }
        }

        // Check and get the input of theta.
        private void GetTheta()
        {
            bool parseSuccess = double.TryParse(ThetaBox.Text, out theta);
            if (!parseSuccess || theta > 1 || theta < 0)
            {
                ThetaBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter a rational number between 0 and 1!", "Number of Nodes");
                theta = -1;
            }
            else
            {
                ThetaBox.ForeColor = Color.Black;
            }
        }

        // Check and get the input of the parameter.
        private void GetParameter()
        {
            bool parseSuccess = double.TryParse(ParameterBox.Text, out parameter);
            if (!parseSuccess || parameter < 0)
            {
                ParameterBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter a rational number between 0 and 1!", "Number of Nodes");
                parameter = -1;
            }
            else
            {
                ParameterBox.ForeColor = Color.Black;
            }
        }
        #endregion

        #region UI Functions
        // Set limit and value labels.
        private void SetLabels()
        {
            // Adapt UI to input, enable and disable elements.
            SetUI();
            // Set the labels for lower and upper limits.
            double[] limits = Functions.GetLimits(problemNumber);
            LowerLimitLabel.Text = string.Format("Lower Limit = {0:F2}", limits[0]);
            UpperLimitLabel.Text = string.Format("Upper Limit = {0:F2}", limits[1]);
            // Display error or value depending on problem.
            if (problemNumber == 0)
            {
                ValueLabel.Text = string.Format("{0} = {1:E3}", resultName,
                    Math.Abs(Functions.ComputeValueP1(problemNumber, parameter) - Integration.Value));
            }
            else if (problemNumber < 17)
            {
                ValueLabel.Text = string.Format("{0} = {1:E3}", resultName,
                    Math.Abs(Functions.GetValue(problemNumber) - Integration.Value));
            }
            else
            {
                ValueLabel.Text = string.Format("{0} = {1:E3}", resultName, Integration.Value);
            }
        }

        // Draw the graph using the Draw class.
        private void DrawGraph()
        {
            // Clear the graph pane.
            graph.Clear();
            // Graph the test function.
            graph.GraphTestFunction(problemNumber);

            // Graph nodes depending on method of integration.
            switch (method)
            {
                case 0: // Variant 1.
                    graph.GraphNodesV1();
                    break;
                case 1:  // Variant 2.
                    graph.GraphNodesV2();
                    break;
                case 2: // Trapezia.
                    graph.GraphTrapezoidNodes();
                    break;
                case 3: // Simpson.
                    graph.GraphTrapezoidNodes();
                    graph.GraphSimpsonGraph();
                    break;
            }

            // Draw all trapezoidal shapes as illustration.
            if (method != 3)
            {
                foreach (Trapezoid t in Trapezoid.GetTrapezoids())
                {
                    t.Draw();
                }
            }

            // Refresh the graph pane.
            graph.Refresh();
        }

        // Adapt the UI to user input.
        private void SetUI()
        {
            // Disable comboBoxes according to the problem.
            ParameterBox.Enabled = (problemNumber == 0 || problemNumber == 17);
            ThetaBox.Enabled = (method < 2 || method == 4);
            // repurpose theta box and label for error input
            if (method == 4)
            {
                ThetaLabel.Text = "Max Error";
                ThetaBox.Items.Clear();
                ThetaBox.Items.AddRange(errorRange);
            }
            else
            {
                ThetaLabel.Text = "Theta";
                ThetaBox.Items.Clear();
                ThetaBox.Items.AddRange(thetaRange);
            }
            // Change label text to value or error based on problem.
            resultName = (problemNumber < 17) ? "Error" : "Value";
            if (problemNumber == 0)
            {
                ParameterBox.Items.Clear();
                ParameterBox.Items.AddRange(parameterRange1);
            }
            else if (problemNumber == 17)
            {
                ParameterBox.Items.Clear();
                ParameterBox.Items.AddRange(parameterRange18);
            }
        }
        #endregion

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GraphWindow = new ZedGraph.ZedGraphControl();
            this.ProblemBox = new System.Windows.Forms.ComboBox();
            this.ProblemLabel = new System.Windows.Forms.Label();
            this.LowerLimitLabel = new System.Windows.Forms.Label();
            this.UpperLimitLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.DrawButton = new System.Windows.Forms.Button();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.ParameterLabel = new System.Windows.Forms.Label();
            this.ParameterBox = new System.Windows.Forms.ComboBox();
            this.ThetaBox = new System.Windows.Forms.ComboBox();
            this.ThetaLabel = new System.Windows.Forms.Label();
            this.MethodLabel = new System.Windows.Forms.Label();
            this.MethodBox = new System.Windows.Forms.ComboBox();
            this.NodesBox = new System.Windows.Forms.ComboBox();
            this.NodesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GraphWindow
            // 
            this.GraphWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphWindow.Location = new System.Drawing.Point(15, 91);
            this.GraphWindow.Margin = new System.Windows.Forms.Padding(5);
            this.GraphWindow.Name = "GraphWindow";
            this.GraphWindow.ScrollGrace = 0D;
            this.GraphWindow.ScrollMaxX = 0D;
            this.GraphWindow.ScrollMaxY = 0D;
            this.GraphWindow.ScrollMaxY2 = 0D;
            this.GraphWindow.ScrollMinX = 0D;
            this.GraphWindow.ScrollMinY = 0D;
            this.GraphWindow.ScrollMinY2 = 0D;
            this.GraphWindow.Size = new System.Drawing.Size(930, 579);
            this.GraphWindow.TabIndex = 0;
            // 
            // ProblemBox
            // 
            this.ProblemBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProblemBox.FormattingEnabled = true;
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
            "Problem 14",
            "Problem 15",
            "Problem 16",
            "Problem 17",
            "Problem 18",
            "Problem 19",
            "Problem 20",
            "Problem 21",
            "Problem 22",
            "Problem 23",
            "Problem 24"});
            this.ProblemBox.Location = new System.Drawing.Point(15, 28);
            this.ProblemBox.Name = "ProblemBox";
            this.ProblemBox.Size = new System.Drawing.Size(150, 24);
            this.ProblemBox.TabIndex = 1;
            this.ProblemBox.SelectedIndexChanged += new System.EventHandler(this.ProblemBox_SelectedIndexChanged);
            this.ProblemBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProblemBox_KeyPress);
            // 
            // ProblemLabel
            // 
            this.ProblemLabel.AutoSize = true;
            this.ProblemLabel.Location = new System.Drawing.Point(12, 9);
            this.ProblemLabel.Name = "ProblemLabel";
            this.ProblemLabel.Size = new System.Drawing.Size(59, 16);
            this.ProblemLabel.TabIndex = 2;
            this.ProblemLabel.Text = "Problem";
            // 
            // LowerLimitLabel
            // 
            this.LowerLimitLabel.AutoSize = true;
            this.LowerLimitLabel.Location = new System.Drawing.Point(168, 62);
            this.LowerLimitLabel.Name = "LowerLimitLabel";
            this.LowerLimitLabel.Size = new System.Drawing.Size(74, 16);
            this.LowerLimitLabel.TabIndex = 6;
            this.LowerLimitLabel.Text = "Lower Limit";
            // 
            // UpperLimitLabel
            // 
            this.UpperLimitLabel.AutoSize = true;
            this.UpperLimitLabel.Location = new System.Drawing.Point(324, 62);
            this.UpperLimitLabel.Name = "UpperLimitLabel";
            this.UpperLimitLabel.Size = new System.Drawing.Size(76, 16);
            this.UpperLimitLabel.TabIndex = 8;
            this.UpperLimitLabel.Text = "Upper Limit";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(795, 28);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(150, 25);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(483, 58);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(462, 25);
            this.DrawButton.TabIndex = 11;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(12, 62);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(49, 16);
            this.ValueLabel.TabIndex = 12;
            this.ValueLabel.Text = "Value: ";
            // 
            // ParameterLabel
            // 
            this.ParameterLabel.AutoSize = true;
            this.ParameterLabel.Location = new System.Drawing.Point(480, 9);
            this.ParameterLabel.Name = "ParameterLabel";
            this.ParameterLabel.Size = new System.Drawing.Size(71, 16);
            this.ParameterLabel.TabIndex = 13;
            this.ParameterLabel.Text = "Parameter";
            // 
            // ParameterBox
            // 
            this.ParameterBox.FormattingEnabled = true;
            this.ParameterBox.Location = new System.Drawing.Point(483, 28);
            this.ParameterBox.Name = "ParameterBox";
            this.ParameterBox.Size = new System.Drawing.Size(150, 24);
            this.ParameterBox.TabIndex = 14;
            this.ParameterBox.SelectedIndexChanged += new System.EventHandler(this.ParameterBox_SelectedIndexChanged);
            this.ParameterBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ParameterBox_KeyPress);
            // 
            // ThetaBox
            // 
            this.ThetaBox.FormattingEnabled = true;
            this.ThetaBox.Items.AddRange(new object[] {
            "0",
            "0.25",
            "0.5",
            "0.75",
            "1"});
            this.ThetaBox.Location = new System.Drawing.Point(639, 28);
            this.ThetaBox.Name = "ThetaBox";
            this.ThetaBox.Size = new System.Drawing.Size(150, 24);
            this.ThetaBox.TabIndex = 16;
            this.ThetaBox.SelectedIndexChanged += new System.EventHandler(this.ThetaBox_SelectedIndexChanged);
            this.ThetaBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ThetaBox_KeyPress);
            // 
            // ThetaLabel
            // 
            this.ThetaLabel.AutoSize = true;
            this.ThetaLabel.Location = new System.Drawing.Point(636, 9);
            this.ThetaLabel.Name = "ThetaLabel";
            this.ThetaLabel.Size = new System.Drawing.Size(43, 16);
            this.ThetaLabel.TabIndex = 15;
            this.ThetaLabel.Text = "Theta";
            // 
            // MethodLabel
            // 
            this.MethodLabel.AutoSize = true;
            this.MethodLabel.Location = new System.Drawing.Point(168, 9);
            this.MethodLabel.Name = "MethodLabel";
            this.MethodLabel.Size = new System.Drawing.Size(53, 16);
            this.MethodLabel.TabIndex = 18;
            this.MethodLabel.Text = "Method";
            // 
            // MethodBox
            // 
            this.MethodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MethodBox.FormattingEnabled = true;
            this.MethodBox.Items.AddRange(new object[] {
            "Variant 1",
            "Variant 2",
            "Trapezia",
            "Simpson"});
            this.MethodBox.Location = new System.Drawing.Point(171, 28);
            this.MethodBox.Name = "MethodBox";
            this.MethodBox.Size = new System.Drawing.Size(150, 24);
            this.MethodBox.TabIndex = 19;
            this.MethodBox.SelectedIndexChanged += new System.EventHandler(this.MethodBox_SelectedIndexChanged);
            this.MethodBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MethodBox_KeyPress);
            // 
            // NodesBox
            // 
            this.NodesBox.FormattingEnabled = true;
            this.NodesBox.Items.AddRange(new object[] {
            "3",
            "5",
            "9",
            "17",
            "33",
            "65",
            "129"});
            this.NodesBox.Location = new System.Drawing.Point(327, 28);
            this.NodesBox.Name = "NodesBox";
            this.NodesBox.Size = new System.Drawing.Size(150, 24);
            this.NodesBox.TabIndex = 21;
            this.NodesBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NodesBox_KeyPress);
            // 
            // NodesLabel
            // 
            this.NodesLabel.AutoSize = true;
            this.NodesLabel.Location = new System.Drawing.Point(324, 9);
            this.NodesLabel.Name = "NodesLabel";
            this.NodesLabel.Size = new System.Drawing.Size(114, 16);
            this.NodesLabel.TabIndex = 20;
            this.NodesLabel.Text = "Number of Nodes";
            // 
            // NumericalIntegration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 684);
            this.Controls.Add(this.NodesBox);
            this.Controls.Add(this.NodesLabel);
            this.Controls.Add(this.MethodBox);
            this.Controls.Add(this.MethodLabel);
            this.Controls.Add(this.ThetaBox);
            this.Controls.Add(this.ThetaLabel);
            this.Controls.Add(this.ParameterBox);
            this.Controls.Add(this.ParameterLabel);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.UpperLimitLabel);
            this.Controls.Add(this.LowerLimitLabel);
            this.Controls.Add(this.ProblemLabel);
            this.Controls.Add(this.ProblemBox);
            this.Controls.Add(this.GraphWindow);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(975, 723);
            this.Name = "NumericalIntegration";
            this.Text = "Numerical Integration";
            this.Resize += new System.EventHandler(this.NumericalIntegration_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ZedGraph.ZedGraphControl GraphWindow;
        private System.Windows.Forms.ComboBox ProblemBox;
        private System.Windows.Forms.Label ProblemLabel;
        private System.Windows.Forms.Label LowerLimitLabel;
        private System.Windows.Forms.Label UpperLimitLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label ParameterLabel;
        private System.Windows.Forms.ComboBox ParameterBox;
        private System.Windows.Forms.ComboBox ThetaBox;
        private System.Windows.Forms.Label ThetaLabel;
        private System.Windows.Forms.Label MethodLabel;
        private System.Windows.Forms.ComboBox MethodBox;
        private System.Windows.Forms.ComboBox NodesBox;
        private System.Windows.Forms.Label NodesLabel;
        #endregion
    }
}

