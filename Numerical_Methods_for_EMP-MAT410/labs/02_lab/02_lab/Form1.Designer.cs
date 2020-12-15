namespace _02_lab
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.KLabel = new System.Windows.Forms.Label();
            this.SchemeComboBox = new System.Windows.Forms.ComboBox();
            this.ParameterGroupBox = new System.Windows.Forms.GroupBox();
            this.BetaComboBox = new System.Windows.Forms.ComboBox();
            this.BetaLabel = new System.Windows.Forms.Label();
            this.T2ComboBox = new System.Windows.Forms.ComboBox();
            this.T1ComboBox = new System.Windows.Forms.ComboBox();
            this.T2label = new System.Windows.Forms.Label();
            this.T1label = new System.Windows.Forms.Label();
            this.TimespanComboBox = new System.Windows.Forms.ComboBox();
            this.TimeNodeComboBox = new System.Windows.Forms.ComboBox();
            this.TimeNodeLabel = new System.Windows.Forms.Label();
            this.TimeSpanLabel = new System.Windows.Forms.Label();
            this.KComboBox = new System.Windows.Forms.ComboBox();
            this.SchemeLabel = new System.Windows.Forms.Label();
            this.ELabel = new System.Windows.Forms.Label();
            this.EComboBox = new System.Windows.Forms.ComboBox();
            this.SpaceNodeLabel = new System.Windows.Forms.Label();
            this.SpaceNodeComboBox = new System.Windows.Forms.ComboBox();
            this.CourantTextLabel = new System.Windows.Forms.Label();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.GraphPane = new ZedGraph.ZedGraphControl();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.StepButton = new System.Windows.Forms.Button();
            this.TimeTextLabel = new System.Windows.Forms.Label();
            this.GraphSelectionBox = new System.Windows.Forms.GroupBox();
            this.LocalMinMaxCheckBox = new System.Windows.Forms.CheckBox();
            this.NumericalSolutionCheckBox = new System.Windows.Forms.CheckBox();
            this.ExactSolutionCheckBox = new System.Windows.Forms.CheckBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.ErrorTextLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.CourantBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxErrLabel = new System.Windows.Forms.Label();
            this.ParameterGroupBox.SuspendLayout();
            this.GraphSelectionBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // KLabel
            // 
            this.KLabel.AutoSize = true;
            this.KLabel.Location = new System.Drawing.Point(9, 100);
            this.KLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.KLabel.Name = "KLabel";
            this.KLabel.Size = new System.Drawing.Size(102, 19);
            this.KLabel.TabIndex = 25;
            this.KLabel.Text = "Parameter k";
            // 
            // SchemeComboBox
            // 
            this.SchemeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SchemeComboBox.FormattingEnabled = true;
            this.SchemeComboBox.Items.AddRange(new object[] {
            "Explicit",
            "Crank-Nicolson",
            "Pure Implicit",
            "Stable Explicit"});
            this.SchemeComboBox.Location = new System.Drawing.Point(144, 28);
            this.SchemeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SchemeComboBox.Name = "SchemeComboBox";
            this.SchemeComboBox.Size = new System.Drawing.Size(184, 27);
            this.SchemeComboBox.TabIndex = 17;
            this.SchemeComboBox.Leave += new System.EventHandler(this.SchemeComboBox_Leave);
            // 
            // ParameterGroupBox
            // 
            this.ParameterGroupBox.Controls.Add(this.BetaComboBox);
            this.ParameterGroupBox.Controls.Add(this.BetaLabel);
            this.ParameterGroupBox.Controls.Add(this.T2ComboBox);
            this.ParameterGroupBox.Controls.Add(this.T1ComboBox);
            this.ParameterGroupBox.Controls.Add(this.T2label);
            this.ParameterGroupBox.Controls.Add(this.T1label);
            this.ParameterGroupBox.Controls.Add(this.TimespanComboBox);
            this.ParameterGroupBox.Controls.Add(this.TimeNodeComboBox);
            this.ParameterGroupBox.Controls.Add(this.TimeNodeLabel);
            this.ParameterGroupBox.Controls.Add(this.TimeSpanLabel);
            this.ParameterGroupBox.Controls.Add(this.KComboBox);
            this.ParameterGroupBox.Controls.Add(this.KLabel);
            this.ParameterGroupBox.Controls.Add(this.SchemeComboBox);
            this.ParameterGroupBox.Controls.Add(this.SchemeLabel);
            this.ParameterGroupBox.Controls.Add(this.ELabel);
            this.ParameterGroupBox.Controls.Add(this.EComboBox);
            this.ParameterGroupBox.Controls.Add(this.SpaceNodeLabel);
            this.ParameterGroupBox.Controls.Add(this.SpaceNodeComboBox);
            this.ParameterGroupBox.Location = new System.Drawing.Point(13, 13);
            this.ParameterGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ParameterGroupBox.Name = "ParameterGroupBox";
            this.ParameterGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ParameterGroupBox.Size = new System.Drawing.Size(340, 358);
            this.ParameterGroupBox.TabIndex = 51;
            this.ParameterGroupBox.TabStop = false;
            this.ParameterGroupBox.Text = "Function Parameters";
            this.ParameterGroupBox.UseCompatibleTextRendering = true;
            // 
            // BetaComboBox
            // 
            this.BetaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BetaComboBox.FormattingEnabled = true;
            this.BetaComboBox.Items.AddRange(new object[] {
            "Type 1",
            "Type 2",
            "Type 3",
            "Type 4"});
            this.BetaComboBox.Location = new System.Drawing.Point(144, 63);
            this.BetaComboBox.Name = "BetaComboBox";
            this.BetaComboBox.Size = new System.Drawing.Size(183, 27);
            this.BetaComboBox.TabIndex = 71;
            // 
            // BetaLabel
            // 
            this.BetaLabel.AutoSize = true;
            this.BetaLabel.Location = new System.Drawing.Point(9, 66);
            this.BetaLabel.Name = "BetaLabel";
            this.BetaLabel.Size = new System.Drawing.Size(44, 19);
            this.BetaLabel.TabIndex = 70;
            this.BetaLabel.Text = "Beta";
            // 
            // T2ComboBox
            // 
            this.T2ComboBox.FormattingEnabled = true;
            this.T2ComboBox.Items.AddRange(new object[] {
            "-2",
            "-1",
            "0",
            "1",
            "2"});
            this.T2ComboBox.Location = new System.Drawing.Point(144, 316);
            this.T2ComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.T2ComboBox.Name = "T2ComboBox";
            this.T2ComboBox.Size = new System.Drawing.Size(184, 27);
            this.T2ComboBox.TabIndex = 69;
            // 
            // T1ComboBox
            // 
            this.T1ComboBox.FormattingEnabled = true;
            this.T1ComboBox.Items.AddRange(new object[] {
            "-2",
            "-1",
            "0",
            "1",
            "2"});
            this.T1ComboBox.Location = new System.Drawing.Point(144, 279);
            this.T1ComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.T1ComboBox.Name = "T1ComboBox";
            this.T1ComboBox.Size = new System.Drawing.Size(184, 27);
            this.T1ComboBox.TabIndex = 68;
            // 
            // T2label
            // 
            this.T2label.AutoSize = true;
            this.T2label.Location = new System.Drawing.Point(9, 319);
            this.T2label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.T2label.Name = "T2label";
            this.T2label.Size = new System.Drawing.Size(129, 19);
            this.T2label.TabIndex = 67;
            this.T2label.Text = "Temperature T2";
            // 
            // T1label
            // 
            this.T1label.AutoSize = true;
            this.T1label.Location = new System.Drawing.Point(9, 282);
            this.T1label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.T1label.Name = "T1label";
            this.T1label.Size = new System.Drawing.Size(129, 19);
            this.T1label.TabIndex = 66;
            this.T1label.Text = "Temperature T1";
            // 
            // TimespanComboBox
            // 
            this.TimespanComboBox.FormattingEnabled = true;
            this.TimespanComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "7"});
            this.TimespanComboBox.Location = new System.Drawing.Point(144, 242);
            this.TimespanComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TimespanComboBox.Name = "TimespanComboBox";
            this.TimespanComboBox.Size = new System.Drawing.Size(184, 27);
            this.TimespanComboBox.TabIndex = 65;
            this.TimespanComboBox.Leave += new System.EventHandler(this.TimespanComboBox_Leave);
            // 
            // TimeNodeComboBox
            // 
            this.TimeNodeComboBox.FormattingEnabled = true;
            this.TimeNodeComboBox.Items.AddRange(new object[] {
            "5",
            "9",
            "17",
            "33",
            "65",
            "129",
            "257",
            "513"});
            this.TimeNodeComboBox.Location = new System.Drawing.Point(144, 206);
            this.TimeNodeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TimeNodeComboBox.Name = "TimeNodeComboBox";
            this.TimeNodeComboBox.Size = new System.Drawing.Size(184, 27);
            this.TimeNodeComboBox.TabIndex = 64;
            this.TimeNodeComboBox.Leave += new System.EventHandler(this.TimeNodeComboBox_Leave);
            // 
            // TimeNodeLabel
            // 
            this.TimeNodeLabel.AutoSize = true;
            this.TimeNodeLabel.Location = new System.Drawing.Point(9, 209);
            this.TimeNodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeNodeLabel.Name = "TimeNodeLabel";
            this.TimeNodeLabel.Size = new System.Drawing.Size(116, 19);
            this.TimeNodeLabel.TabIndex = 63;
            this.TimeNodeLabel.Text = "Nodes in Time";
            // 
            // TimeSpanLabel
            // 
            this.TimeSpanLabel.AutoSize = true;
            this.TimeSpanLabel.Location = new System.Drawing.Point(9, 245);
            this.TimeSpanLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeSpanLabel.Name = "TimeSpanLabel";
            this.TimeSpanLabel.Size = new System.Drawing.Size(95, 19);
            this.TimeSpanLabel.TabIndex = 61;
            this.TimeSpanLabel.Text = "Timespan T";
            // 
            // KComboBox
            // 
            this.KComboBox.FormattingEnabled = true;
            this.KComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.KComboBox.Location = new System.Drawing.Point(144, 98);
            this.KComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.KComboBox.Name = "KComboBox";
            this.KComboBox.Size = new System.Drawing.Size(184, 27);
            this.KComboBox.TabIndex = 62;
            this.KComboBox.TabStop = false;
            this.KComboBox.Leave += new System.EventHandler(this.KComboBox_Leave);
            // 
            // SchemeLabel
            // 
            this.SchemeLabel.AutoSize = true;
            this.SchemeLabel.Location = new System.Drawing.Point(9, 30);
            this.SchemeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SchemeLabel.Name = "SchemeLabel";
            this.SchemeLabel.Size = new System.Drawing.Size(69, 19);
            this.SchemeLabel.TabIndex = 10;
            this.SchemeLabel.Text = "Scheme";
            // 
            // ELabel
            // 
            this.ELabel.AutoSize = true;
            this.ELabel.Location = new System.Drawing.Point(9, 137);
            this.ELabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ELabel.Name = "ELabel";
            this.ELabel.Size = new System.Drawing.Size(63, 19);
            this.ELabel.TabIndex = 11;
            this.ELabel.Text = "Epsilon";
            // 
            // EComboBox
            // 
            this.EComboBox.FormattingEnabled = true;
            this.EComboBox.Items.AddRange(new object[] {
            "1",
            "0.5",
            "0.125",
            "0.0625",
            "0.03125",
            "0.015625",
            "0.0078125",
            "0.00390625"});
            this.EComboBox.Location = new System.Drawing.Point(144, 134);
            this.EComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EComboBox.Name = "EComboBox";
            this.EComboBox.Size = new System.Drawing.Size(184, 27);
            this.EComboBox.TabIndex = 18;
            this.EComboBox.Leave += new System.EventHandler(this.EComboBox_Leave);
            // 
            // SpaceNodeLabel
            // 
            this.SpaceNodeLabel.AutoSize = true;
            this.SpaceNodeLabel.Location = new System.Drawing.Point(9, 173);
            this.SpaceNodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SpaceNodeLabel.Name = "SpaceNodeLabel";
            this.SpaceNodeLabel.Size = new System.Drawing.Size(123, 19);
            this.SpaceNodeLabel.TabIndex = 12;
            this.SpaceNodeLabel.Text = "Nodes in Space";
            // 
            // SpaceNodeComboBox
            // 
            this.SpaceNodeComboBox.FormattingEnabled = true;
            this.SpaceNodeComboBox.Items.AddRange(new object[] {
            "5",
            "9",
            "17",
            "33",
            "65",
            "129"});
            this.SpaceNodeComboBox.Location = new System.Drawing.Point(144, 170);
            this.SpaceNodeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SpaceNodeComboBox.Name = "SpaceNodeComboBox";
            this.SpaceNodeComboBox.Size = new System.Drawing.Size(184, 27);
            this.SpaceNodeComboBox.TabIndex = 19;
            this.SpaceNodeComboBox.Leave += new System.EventHandler(this.SpaceNodeComboBox_Leave);
            // 
            // CourantTextLabel
            // 
            this.CourantTextLabel.AutoSize = true;
            this.CourantTextLabel.Location = new System.Drawing.Point(20, 382);
            this.CourantTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CourantTextLabel.Name = "CourantTextLabel";
            this.CourantTextLabel.Size = new System.Drawing.Size(134, 19);
            this.CourantTextLabel.TabIndex = 29;
            this.CourantTextLabel.Text = "Courant Number";
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // GraphPane
            // 
            this.GraphPane.Location = new System.Drawing.Point(363, 17);
            this.GraphPane.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.GraphPane.Name = "GraphPane";
            this.GraphPane.ScrollGrace = 0D;
            this.GraphPane.ScrollMaxX = 0D;
            this.GraphPane.ScrollMaxY = 0D;
            this.GraphPane.ScrollMaxY2 = 0D;
            this.GraphPane.ScrollMinX = 0D;
            this.GraphPane.ScrollMinY = 0D;
            this.GraphPane.ScrollMinY2 = 0D;
            this.GraphPane.Size = new System.Drawing.Size(823, 721);
            this.GraphPane.TabIndex = 56;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(13, 634);
            this.CalculateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(340, 28);
            this.CalculateButton.TabIndex = 52;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButtonClick);
            // 
            // StepButton
            // 
            this.StepButton.Location = new System.Drawing.Point(13, 672);
            this.StepButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StepButton.Name = "StepButton";
            this.StepButton.Size = new System.Drawing.Size(340, 28);
            this.StepButton.TabIndex = 59;
            this.StepButton.Text = "Step";
            this.StepButton.UseVisualStyleBackColor = true;
            this.StepButton.Click += new System.EventHandler(this.StepButtonClick);
            // 
            // TimeTextLabel
            // 
            this.TimeTextLabel.AutoSize = true;
            this.TimeTextLabel.Location = new System.Drawing.Point(20, 410);
            this.TimeTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeTextLabel.Name = "TimeTextLabel";
            this.TimeTextLabel.Size = new System.Drawing.Size(46, 19);
            this.TimeTextLabel.TabIndex = 62;
            this.TimeTextLabel.Text = "Time";
            // 
            // GraphSelectionBox
            // 
            this.GraphSelectionBox.Controls.Add(this.LocalMinMaxCheckBox);
            this.GraphSelectionBox.Controls.Add(this.NumericalSolutionCheckBox);
            this.GraphSelectionBox.Controls.Add(this.ExactSolutionCheckBox);
            this.GraphSelectionBox.Location = new System.Drawing.Point(13, 500);
            this.GraphSelectionBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GraphSelectionBox.Name = "GraphSelectionBox";
            this.GraphSelectionBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GraphSelectionBox.Size = new System.Drawing.Size(340, 124);
            this.GraphSelectionBox.TabIndex = 63;
            this.GraphSelectionBox.TabStop = false;
            this.GraphSelectionBox.Text = "Graph Options";
            // 
            // LocalMinMaxCheckBox
            // 
            this.LocalMinMaxCheckBox.AutoSize = true;
            this.LocalMinMaxCheckBox.Location = new System.Drawing.Point(13, 91);
            this.LocalMinMaxCheckBox.Name = "LocalMinMaxCheckBox";
            this.LocalMinMaxCheckBox.Size = new System.Drawing.Size(218, 23);
            this.LocalMinMaxCheckBox.TabIndex = 2;
            this.LocalMinMaxCheckBox.Text = "Adjust Graph to Function";
            this.LocalMinMaxCheckBox.UseVisualStyleBackColor = true;
            this.LocalMinMaxCheckBox.CheckedChanged += new System.EventHandler(this.LocalMinMaxCheckBox_CheckedChanged);
            // 
            // NumericalSolutionCheckBox
            // 
            this.NumericalSolutionCheckBox.AutoSize = true;
            this.NumericalSolutionCheckBox.Checked = true;
            this.NumericalSolutionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NumericalSolutionCheckBox.Location = new System.Drawing.Point(13, 60);
            this.NumericalSolutionCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NumericalSolutionCheckBox.Name = "NumericalSolutionCheckBox";
            this.NumericalSolutionCheckBox.Size = new System.Drawing.Size(173, 23);
            this.NumericalSolutionCheckBox.TabIndex = 1;
            this.NumericalSolutionCheckBox.Text = "Numerical Solution";
            this.NumericalSolutionCheckBox.UseVisualStyleBackColor = true;
            this.NumericalSolutionCheckBox.CheckedChanged += new System.EventHandler(this.NumericalSolutionCheckBox_CheckedChanged);
            // 
            // ExactSolutionCheckBox
            // 
            this.ExactSolutionCheckBox.AutoSize = true;
            this.ExactSolutionCheckBox.Checked = true;
            this.ExactSolutionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ExactSolutionCheckBox.Location = new System.Drawing.Point(13, 28);
            this.ExactSolutionCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExactSolutionCheckBox.Name = "ExactSolutionCheckBox";
            this.ExactSolutionCheckBox.Size = new System.Drawing.Size(136, 23);
            this.ExactSolutionCheckBox.TabIndex = 0;
            this.ExactSolutionCheckBox.Text = "Exact Solution";
            this.ExactSolutionCheckBox.UseVisualStyleBackColor = true;
            this.ExactSolutionCheckBox.CheckedChanged += new System.EventHandler(this.ExactSolutionCheckBox_CheckedChanged);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(13, 710);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(340, 28);
            this.ResetButton.TabIndex = 64;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(153, 410);
            this.TimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(21, 19);
            this.TimeLabel.TabIndex = 69;
            this.TimeLabel.Text = "--";
            // 
            // ErrorTextLabel
            // 
            this.ErrorTextLabel.AutoSize = true;
            this.ErrorTextLabel.Location = new System.Drawing.Point(20, 438);
            this.ErrorTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ErrorTextLabel.Name = "ErrorTextLabel";
            this.ErrorTextLabel.Size = new System.Drawing.Size(48, 19);
            this.ErrorTextLabel.TabIndex = 70;
            this.ErrorTextLabel.Text = "Error";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(153, 438);
            this.ErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(21, 19);
            this.ErrorLabel.TabIndex = 71;
            this.ErrorLabel.Text = "--";
            // 
            // CourantBox
            // 
            this.CourantBox.Location = new System.Drawing.Point(157, 379);
            this.CourantBox.Name = "CourantBox";
            this.CourantBox.Size = new System.Drawing.Size(184, 25);
            this.CourantBox.TabIndex = 72;
            this.CourantBox.Leave += new System.EventHandler(this.CourantBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 74;
            this.label2.Text = "Max Error";
            // 
            // MaxErrLabel
            // 
            this.MaxErrLabel.AutoSize = true;
            this.MaxErrLabel.Location = new System.Drawing.Point(153, 467);
            this.MaxErrLabel.Name = "MaxErrLabel";
            this.MaxErrLabel.Size = new System.Drawing.Size(21, 19);
            this.MaxErrLabel.TabIndex = 75;
            this.MaxErrLabel.Text = "--";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 752);
            this.Controls.Add(this.MaxErrLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CourantBox);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.ErrorTextLabel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.GraphSelectionBox);
            this.Controls.Add(this.TimeTextLabel);
            this.Controls.Add(this.StepButton);
            this.Controls.Add(this.ParameterGroupBox);
            this.Controls.Add(this.CourantTextLabel);
            this.Controls.Add(this.GraphPane);
            this.Controls.Add(this.CalculateButton);
            this.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Differential Equation Solver For Problem 4";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ParameterGroupBox.ResumeLayout(false);
            this.ParameterGroupBox.PerformLayout();
            this.GraphSelectionBox.ResumeLayout(false);
            this.GraphSelectionBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label KLabel;
        private System.Windows.Forms.ComboBox SchemeComboBox;
        private System.Windows.Forms.Label SchemeLabel;
        private System.Windows.Forms.Label ELabel;
        private System.Windows.Forms.Label SpaceNodeLabel;
        private System.Windows.Forms.ComboBox SpaceNodeComboBox;
        private System.Windows.Forms.Timer AnimationTimer;
        private ZedGraph.ZedGraphControl GraphPane;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Label CourantTextLabel;
        private System.Windows.Forms.Button StepButton;
        private System.Windows.Forms.ComboBox KComboBox;
        private System.Windows.Forms.Label TimeNodeLabel;
        private System.Windows.Forms.Label TimeSpanLabel;
        private System.Windows.Forms.ComboBox TimeNodeComboBox;
        private System.Windows.Forms.Label TimeTextLabel;
        private System.Windows.Forms.GroupBox GraphSelectionBox;
        private System.Windows.Forms.CheckBox NumericalSolutionCheckBox;
        private System.Windows.Forms.CheckBox ExactSolutionCheckBox;
        private System.Windows.Forms.ComboBox EComboBox;
        public System.Windows.Forms.GroupBox ParameterGroupBox;
        private System.Windows.Forms.ComboBox TimespanComboBox;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.ComboBox T2ComboBox;
        private System.Windows.Forms.ComboBox T1ComboBox;
        private System.Windows.Forms.Label T2label;
        private System.Windows.Forms.Label T1label;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.CheckBox LocalMinMaxCheckBox;
        private System.Windows.Forms.Label ErrorTextLabel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.TextBox CourantBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MaxErrLabel;
        private System.Windows.Forms.ComboBox BetaComboBox;
        private System.Windows.Forms.Label BetaLabel;
    }
}

