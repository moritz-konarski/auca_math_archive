namespace Diff_Equ
{
    partial class Form1
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DrawButton = new System.Windows.Forms.Button();
            this.GraphPane = new ZedGraph.ZedGraphControl();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ProblemBox = new System.Windows.Forms.ComboBox();
            this.ProblemLabel = new System.Windows.Forms.Label();
            this.MethodBox = new System.Windows.Forms.ComboBox();
            this.MethodLabel = new System.Windows.Forms.Label();
            this.NodeBox = new System.Windows.Forms.ComboBox();
            this.NodeLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.EpsilonLabel = new System.Windows.Forms.Label();
            this.EpsilonBox = new System.Windows.Forms.ComboBox();
            this.PhiLabel = new System.Windows.Forms.Label();
            this.PhiBox = new System.Windows.Forms.ComboBox();
            this.LambdaLabel = new System.Windows.Forms.Label();
            this.LambdaBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(13, 65);
            this.DrawButton.Margin = new System.Windows.Forms.Padding(4);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(328, 26);
            this.DrawButton.TabIndex = 0;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // GraphPane
            // 
            this.GraphPane.Location = new System.Drawing.Point(13, 99);
            this.GraphPane.Margin = new System.Windows.Forms.Padding(4);
            this.GraphPane.Name = "GraphPane";
            this.GraphPane.ScrollGrace = 0D;
            this.GraphPane.ScrollMaxX = 0D;
            this.GraphPane.ScrollMaxY = 0D;
            this.GraphPane.ScrollMaxY2 = 0D;
            this.GraphPane.ScrollMinX = 0D;
            this.GraphPane.ScrollMinY = 0D;
            this.GraphPane.ScrollMinY2 = 0D;
            this.GraphPane.Size = new System.Drawing.Size(1000, 596);
            this.GraphPane.TabIndex = 1;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(685, 65);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(328, 26);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ProblemBox
            // 
            this.ProblemBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProblemBox.FormattingEnabled = true;
            this.ProblemBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "12.2",
            "13.1",
            "13.2",
            "14"});
            this.ProblemBox.Location = new System.Drawing.Point(13, 31);
            this.ProblemBox.Margin = new System.Windows.Forms.Padding(4);
            this.ProblemBox.Name = "ProblemBox";
            this.ProblemBox.Size = new System.Drawing.Size(160, 26);
            this.ProblemBox.TabIndex = 3;
            this.ProblemBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProblemBox_KeyPress_1);
            // 
            // ProblemLabel
            // 
            this.ProblemLabel.AutoSize = true;
            this.ProblemLabel.Location = new System.Drawing.Point(13, 9);
            this.ProblemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProblemLabel.Name = "ProblemLabel";
            this.ProblemLabel.Size = new System.Drawing.Size(64, 18);
            this.ProblemLabel.TabIndex = 4;
            this.ProblemLabel.Text = "Problem";
            // 
            // MethodBox
            // 
            this.MethodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MethodBox.FormattingEnabled = true;
            this.MethodBox.Items.AddRange(new object[] {
            "First Order",
            "Second Order",
            "Third Order"});
            this.MethodBox.Location = new System.Drawing.Point(181, 31);
            this.MethodBox.Margin = new System.Windows.Forms.Padding(4);
            this.MethodBox.Name = "MethodBox";
            this.MethodBox.Size = new System.Drawing.Size(160, 26);
            this.MethodBox.TabIndex = 5;
            this.MethodBox.SelectedIndexChanged += new System.EventHandler(this.MethodBox_SelectedIndexChanged);
            this.MethodBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MethodBox_KeyPress);
            // 
            // MethodLabel
            // 
            this.MethodLabel.AutoSize = true;
            this.MethodLabel.Location = new System.Drawing.Point(178, 9);
            this.MethodLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MethodLabel.Name = "MethodLabel";
            this.MethodLabel.Size = new System.Drawing.Size(58, 18);
            this.MethodLabel.TabIndex = 6;
            this.MethodLabel.Text = "Method";
            // 
            // NodeBox
            // 
            this.NodeBox.FormattingEnabled = true;
            this.NodeBox.Items.AddRange(new object[] {
            "3",
            "5",
            "9",
            "17",
            "33",
            "65",
            "129",
            "257"});
            this.NodeBox.Location = new System.Drawing.Point(349, 31);
            this.NodeBox.Margin = new System.Windows.Forms.Padding(4);
            this.NodeBox.Name = "NodeBox";
            this.NodeBox.Size = new System.Drawing.Size(160, 26);
            this.NodeBox.TabIndex = 8;
            this.NodeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NodeBox_KeyPress);
            // 
            // NodeLabel
            // 
            this.NodeLabel.AutoSize = true;
            this.NodeLabel.Location = new System.Drawing.Point(346, 9);
            this.NodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NodeLabel.Name = "NodeLabel";
            this.NodeLabel.Size = new System.Drawing.Size(126, 18);
            this.NodeLabel.TabIndex = 9;
            this.NodeLabel.Text = "Number of Nodes";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(348, 69);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(102, 18);
            this.ErrorLabel.TabIndex = 10;
            this.ErrorLabel.Text = "Relative Error:";
            // 
            // EpsilonLabel
            // 
            this.EpsilonLabel.AutoSize = true;
            this.EpsilonLabel.Location = new System.Drawing.Point(514, 9);
            this.EpsilonLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EpsilonLabel.Name = "EpsilonLabel";
            this.EpsilonLabel.Size = new System.Drawing.Size(57, 18);
            this.EpsilonLabel.TabIndex = 12;
            this.EpsilonLabel.Text = "Epsilon";
            // 
            // EpsilonBox
            // 
            this.EpsilonBox.FormattingEnabled = true;
            this.EpsilonBox.Items.AddRange(new object[] {
            "0.25",
            "0.5",
            "0.75",
            "1"});
            this.EpsilonBox.Location = new System.Drawing.Point(517, 31);
            this.EpsilonBox.Margin = new System.Windows.Forms.Padding(4);
            this.EpsilonBox.Name = "EpsilonBox";
            this.EpsilonBox.Size = new System.Drawing.Size(160, 26);
            this.EpsilonBox.TabIndex = 11;
            this.EpsilonBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EpsilonBox_KeyPress);
            // 
            // PhiLabel
            // 
            this.PhiLabel.AutoSize = true;
            this.PhiLabel.Location = new System.Drawing.Point(682, 9);
            this.PhiLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PhiLabel.Name = "PhiLabel";
            this.PhiLabel.Size = new System.Drawing.Size(29, 18);
            this.PhiLabel.TabIndex = 14;
            this.PhiLabel.Text = "Phi";
            // 
            // PhiBox
            // 
            this.PhiBox.FormattingEnabled = true;
            this.PhiBox.Items.AddRange(new object[] {
            "0",
            "0.5",
            "1",
            "1.5",
            "2"});
            this.PhiBox.Location = new System.Drawing.Point(685, 31);
            this.PhiBox.Margin = new System.Windows.Forms.Padding(4);
            this.PhiBox.Name = "PhiBox";
            this.PhiBox.Size = new System.Drawing.Size(160, 26);
            this.PhiBox.TabIndex = 13;
            this.PhiBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PhiBox_KeyPress);
            // 
            // LambdaLabel
            // 
            this.LambdaLabel.AutoSize = true;
            this.LambdaLabel.Location = new System.Drawing.Point(850, 9);
            this.LambdaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LambdaLabel.Name = "LambdaLabel";
            this.LambdaLabel.Size = new System.Drawing.Size(61, 18);
            this.LambdaLabel.TabIndex = 16;
            this.LambdaLabel.Text = "Lambda";
            // 
            // LambdaBox
            // 
            this.LambdaBox.FormattingEnabled = true;
            this.LambdaBox.Items.AddRange(new object[] {
            "0.25",
            "0.5",
            "0.75",
            "1"});
            this.LambdaBox.Location = new System.Drawing.Point(853, 31);
            this.LambdaBox.Margin = new System.Windows.Forms.Padding(4);
            this.LambdaBox.Name = "LambdaBox";
            this.LambdaBox.Size = new System.Drawing.Size(160, 26);
            this.LambdaBox.TabIndex = 15;
            this.LambdaBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LambdaBox_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 708);
            this.Controls.Add(this.LambdaLabel);
            this.Controls.Add(this.LambdaBox);
            this.Controls.Add(this.PhiLabel);
            this.Controls.Add(this.PhiBox);
            this.Controls.Add(this.EpsilonLabel);
            this.Controls.Add(this.EpsilonBox);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.NodeLabel);
            this.Controls.Add(this.NodeBox);
            this.Controls.Add(this.MethodLabel);
            this.Controls.Add(this.MethodBox);
            this.Controls.Add(this.ProblemLabel);
            this.Controls.Add(this.ProblemBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.GraphPane);
            this.Controls.Add(this.DrawButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1042, 747);
            this.Name = "Form1";
            this.Text = "Differential Equations";
            this.Resize += new System.EventHandler(this.Form1_Resize_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DrawButton;
        private ZedGraph.ZedGraphControl GraphPane;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ComboBox ProblemBox;
        private System.Windows.Forms.Label ProblemLabel;
        private System.Windows.Forms.ComboBox MethodBox;
        private System.Windows.Forms.Label MethodLabel;
        private System.Windows.Forms.ComboBox NodeBox;
        private System.Windows.Forms.Label NodeLabel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label EpsilonLabel;
        private System.Windows.Forms.ComboBox EpsilonBox;
        private System.Windows.Forms.Label PhiLabel;
        private System.Windows.Forms.ComboBox PhiBox;
        private System.Windows.Forms.Label LambdaLabel;
        private System.Windows.Forms.ComboBox LambdaBox;
    }
}

