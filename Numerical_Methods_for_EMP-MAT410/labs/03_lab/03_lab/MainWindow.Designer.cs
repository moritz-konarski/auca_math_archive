namespace _03_lab
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.SchemeComboBox = new System.Windows.Forms.ComboBox();
            this.InputGroupBox = new System.Windows.Forms.GroupBox();
            this.GridNodeComboBox = new System.Windows.Forms.ComboBox();
            this.GridNodeLabel = new System.Windows.Forms.Label();
            this.SchemeLabel = new System.Windows.Forms.Label();
            this.SigmaLabel = new System.Windows.Forms.Label();
            this.SigmaComboBox = new System.Windows.Forms.ComboBox();
            this.Iterator = new System.Windows.Forms.Timer(this.components);
            this.XSliceGraphPane = new ZedGraph.ZedGraphControl();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.StepButton = new System.Windows.Forms.Button();
            this.CurrentIterationsTextLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.CurrentIterationsLabel = new System.Windows.Forms.Label();
            this.ErrorXTextLabel = new System.Windows.Forms.Label();
            this.ErrorXLabel = new System.Windows.Forms.Label();
            this.YSliceGraphPane = new ZedGraph.ZedGraphControl();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.IsFinishedLabel = new System.Windows.Forms.Label();
            this.IterationFinishedLabel = new System.Windows.Forms.Label();
            this.ErrorYTextLabel = new System.Windows.Forms.Label();
            this.ErrorYLabel = new System.Windows.Forms.Label();
            this.ControlGroupBox = new System.Windows.Forms.GroupBox();
            this.InputGroupBox.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
            this.ControlGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SchemeComboBox
            // 
            this.SchemeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SchemeComboBox.FormattingEnabled = true;
            this.SchemeComboBox.Items.AddRange(new object[] {
            resources.GetString("SchemeComboBox.Items"),
            resources.GetString("SchemeComboBox.Items1")});
            resources.ApplyResources(this.SchemeComboBox, "SchemeComboBox");
            this.SchemeComboBox.Name = "SchemeComboBox";
            // 
            // InputGroupBox
            // 
            this.InputGroupBox.Controls.Add(this.GridNodeComboBox);
            this.InputGroupBox.Controls.Add(this.GridNodeLabel);
            this.InputGroupBox.Controls.Add(this.SchemeComboBox);
            this.InputGroupBox.Controls.Add(this.SchemeLabel);
            this.InputGroupBox.Controls.Add(this.SigmaLabel);
            this.InputGroupBox.Controls.Add(this.SigmaComboBox);
            resources.ApplyResources(this.InputGroupBox, "InputGroupBox");
            this.InputGroupBox.Name = "InputGroupBox";
            this.InputGroupBox.TabStop = false;
            this.InputGroupBox.UseCompatibleTextRendering = true;
            // 
            // GridNodeComboBox
            // 
            this.GridNodeComboBox.FormattingEnabled = true;
            this.GridNodeComboBox.Items.AddRange(new object[] {
            resources.GetString("GridNodeComboBox.Items"),
            resources.GetString("GridNodeComboBox.Items1"),
            resources.GetString("GridNodeComboBox.Items2"),
            resources.GetString("GridNodeComboBox.Items3"),
            resources.GetString("GridNodeComboBox.Items4"),
            resources.GetString("GridNodeComboBox.Items5"),
            resources.GetString("GridNodeComboBox.Items6"),
            resources.GetString("GridNodeComboBox.Items7"),
            resources.GetString("GridNodeComboBox.Items8")});
            resources.ApplyResources(this.GridNodeComboBox, "GridNodeComboBox");
            this.GridNodeComboBox.Name = "GridNodeComboBox";
            // 
            // GridNodeLabel
            // 
            resources.ApplyResources(this.GridNodeLabel, "GridNodeLabel");
            this.GridNodeLabel.Name = "GridNodeLabel";
            // 
            // SchemeLabel
            // 
            resources.ApplyResources(this.SchemeLabel, "SchemeLabel");
            this.SchemeLabel.Name = "SchemeLabel";
            // 
            // SigmaLabel
            // 
            resources.ApplyResources(this.SigmaLabel, "SigmaLabel");
            this.SigmaLabel.Name = "SigmaLabel";
            // 
            // SigmaComboBox
            // 
            this.SigmaComboBox.FormattingEnabled = true;
            this.SigmaComboBox.Items.AddRange(new object[] {
            resources.GetString("SigmaComboBox.Items"),
            resources.GetString("SigmaComboBox.Items1"),
            resources.GetString("SigmaComboBox.Items2"),
            resources.GetString("SigmaComboBox.Items3"),
            resources.GetString("SigmaComboBox.Items4"),
            resources.GetString("SigmaComboBox.Items5"),
            resources.GetString("SigmaComboBox.Items6")});
            resources.ApplyResources(this.SigmaComboBox, "SigmaComboBox");
            this.SigmaComboBox.Name = "SigmaComboBox";
            // 
            // Iterator
            // 
            this.Iterator.Tick += new System.EventHandler(this.Iterator_Tick);
            // 
            // XSliceGraphPane
            // 
            resources.ApplyResources(this.XSliceGraphPane, "XSliceGraphPane");
            this.XSliceGraphPane.Name = "XSliceGraphPane";
            this.XSliceGraphPane.ScrollGrace = 0D;
            this.XSliceGraphPane.ScrollMaxX = 0D;
            this.XSliceGraphPane.ScrollMaxY = 0D;
            this.XSliceGraphPane.ScrollMaxY2 = 0D;
            this.XSliceGraphPane.ScrollMinX = 0D;
            this.XSliceGraphPane.ScrollMinY = 0D;
            this.XSliceGraphPane.ScrollMinY2 = 0D;
            // 
            // CalculateButton
            // 
            resources.ApplyResources(this.CalculateButton, "CalculateButton");
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // StepButton
            // 
            resources.ApplyResources(this.StepButton, "StepButton");
            this.StepButton.Name = "StepButton";
            this.StepButton.UseVisualStyleBackColor = true;
            this.StepButton.Click += new System.EventHandler(this.StepButton_Click);
            // 
            // CurrentIterationsTextLabel
            // 
            resources.ApplyResources(this.CurrentIterationsTextLabel, "CurrentIterationsTextLabel");
            this.CurrentIterationsTextLabel.Name = "CurrentIterationsTextLabel";
            // 
            // ResetButton
            // 
            resources.ApplyResources(this.ResetButton, "ResetButton");
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // CurrentIterationsLabel
            // 
            resources.ApplyResources(this.CurrentIterationsLabel, "CurrentIterationsLabel");
            this.CurrentIterationsLabel.Name = "CurrentIterationsLabel";
            // 
            // ErrorXTextLabel
            // 
            resources.ApplyResources(this.ErrorXTextLabel, "ErrorXTextLabel");
            this.ErrorXTextLabel.Name = "ErrorXTextLabel";
            // 
            // ErrorXLabel
            // 
            resources.ApplyResources(this.ErrorXLabel, "ErrorXLabel");
            this.ErrorXLabel.Name = "ErrorXLabel";
            // 
            // YSliceGraphPane
            // 
            resources.ApplyResources(this.YSliceGraphPane, "YSliceGraphPane");
            this.YSliceGraphPane.Name = "YSliceGraphPane";
            this.YSliceGraphPane.ScrollGrace = 0D;
            this.YSliceGraphPane.ScrollMaxX = 0D;
            this.YSliceGraphPane.ScrollMaxY = 0D;
            this.YSliceGraphPane.ScrollMaxY2 = 0D;
            this.YSliceGraphPane.ScrollMinX = 0D;
            this.YSliceGraphPane.ScrollMinY = 0D;
            this.YSliceGraphPane.ScrollMinY2 = 0D;
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.IsFinishedLabel);
            this.OutputGroupBox.Controls.Add(this.IterationFinishedLabel);
            this.OutputGroupBox.Controls.Add(this.ErrorYTextLabel);
            this.OutputGroupBox.Controls.Add(this.ErrorYLabel);
            this.OutputGroupBox.Controls.Add(this.CurrentIterationsTextLabel);
            this.OutputGroupBox.Controls.Add(this.CurrentIterationsLabel);
            this.OutputGroupBox.Controls.Add(this.ErrorXTextLabel);
            this.OutputGroupBox.Controls.Add(this.ErrorXLabel);
            resources.ApplyResources(this.OutputGroupBox, "OutputGroupBox");
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.TabStop = false;
            // 
            // IsFinishedLabel
            // 
            resources.ApplyResources(this.IsFinishedLabel, "IsFinishedLabel");
            this.IsFinishedLabel.Name = "IsFinishedLabel";
            // 
            // IterationFinishedLabel
            // 
            resources.ApplyResources(this.IterationFinishedLabel, "IterationFinishedLabel");
            this.IterationFinishedLabel.Name = "IterationFinishedLabel";
            // 
            // ErrorYTextLabel
            // 
            resources.ApplyResources(this.ErrorYTextLabel, "ErrorYTextLabel");
            this.ErrorYTextLabel.Name = "ErrorYTextLabel";
            // 
            // ErrorYLabel
            // 
            resources.ApplyResources(this.ErrorYLabel, "ErrorYLabel");
            this.ErrorYLabel.Name = "ErrorYLabel";
            // 
            // ControlGroupBox
            // 
            this.ControlGroupBox.Controls.Add(this.CalculateButton);
            this.ControlGroupBox.Controls.Add(this.StepButton);
            this.ControlGroupBox.Controls.Add(this.ResetButton);
            resources.ApplyResources(this.ControlGroupBox, "ControlGroupBox");
            this.ControlGroupBox.Name = "ControlGroupBox";
            this.ControlGroupBox.TabStop = false;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ControlGroupBox);
            this.Controls.Add(this.OutputGroupBox);
            this.Controls.Add(this.YSliceGraphPane);
            this.Controls.Add(this.InputGroupBox);
            this.Controls.Add(this.XSliceGraphPane);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.InputGroupBox.ResumeLayout(false);
            this.InputGroupBox.PerformLayout();
            this.OutputGroupBox.ResumeLayout(false);
            this.OutputGroupBox.PerformLayout();
            this.ControlGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.ComboBox SchemeComboBox;
        private System.Windows.Forms.Label SchemeLabel;
        private System.Windows.Forms.Label SigmaLabel;
        private System.Windows.Forms.ComboBox SigmaComboBox;
        private System.Windows.Forms.Timer Iterator;
        private ZedGraph.ZedGraphControl XSliceGraphPane;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Button StepButton;
        private System.Windows.Forms.Label CurrentIterationsTextLabel;
        public System.Windows.Forms.GroupBox InputGroupBox;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label CurrentIterationsLabel;
        private System.Windows.Forms.Label ErrorXTextLabel;
        private System.Windows.Forms.Label ErrorXLabel;
        private System.Windows.Forms.ComboBox GridNodeComboBox;
        private System.Windows.Forms.Label GridNodeLabel;
        private ZedGraph.ZedGraphControl YSliceGraphPane;
        private System.Windows.Forms.GroupBox OutputGroupBox;
        private System.Windows.Forms.GroupBox ControlGroupBox;
        private System.Windows.Forms.Label ErrorYTextLabel;
        private System.Windows.Forms.Label ErrorYLabel;
        private System.Windows.Forms.Label IterationFinishedLabel;
        private System.Windows.Forms.Label IsFinishedLabel;
    }
}

