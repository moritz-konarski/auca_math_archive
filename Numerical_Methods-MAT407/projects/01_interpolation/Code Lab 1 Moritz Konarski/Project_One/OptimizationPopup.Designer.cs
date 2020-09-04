using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_One
{
    // This class is responsible for the optimization popup that the user sees and iteracts with
    partial class Optimization
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

        #region IO
        // Initialize the io of the popup
        private void InitializeUI()
        {
            MeshBox.SelectedIndex = 0;
            MaxErrorBox.Text = Convert.ToString(Data.GetGivenError());
            // Set up the ToolTips.
            CancelButtonToolTip.SetToolTip(CancelButton, "Cancel the operation");
            OptimizeButtonToolTip.SetToolTip(OptimizeButton, "Optimize with these parameters");
            MaxErrorToolTip.SetToolTip(MaxErrorBox, "Enter the max error of the interpolation");
            InterpolationMeshToolTip.SetToolTip(MeshBox, "Choose the type of mesh for the interpolation");
        }
        #endregion

        #region Getters
        // Get the type of mesh for the interpolation
        protected internal int GetMeshTypeInput()
        {
            return MeshBox.SelectedIndex;
        }

        // Get the max error for the optimization
        protected internal double GetMaxErrorInput()
        {
            double maxError = -1;
            bool parseSuccess = double.TryParse(MaxErrorBox.Text, out maxError);
            if (!parseSuccess || !(maxError > 0))
            {
                MaxErrorBox.ForeColor = Color.Red;
                MessageBox.Show("Please enter a positive real number!", "Max Error");
                maxError = -1;
            }
            else
                MaxErrorBox.ForeColor = Color.Black;
            return maxError;
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
            this.MeshLabel = new System.Windows.Forms.Label();
            this.MaxErrorLabel = new System.Windows.Forms.Label();
            this.MaxErrorBox = new System.Windows.Forms.TextBox();
            this.MeshBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OptimizeButton = new System.Windows.Forms.Button();
            this.MaxErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.InterpolationMeshToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CancelButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.OptimizeButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // MeshLabel
            // 
            this.MeshLabel.AutoSize = true;
            this.MeshLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeshLabel.Location = new System.Drawing.Point(168, 9);
            this.MeshLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MeshLabel.Name = "MeshLabel";
            this.MeshLabel.Size = new System.Drawing.Size(117, 16);
            this.MeshLabel.TabIndex = 0;
            this.MeshLabel.Text = "Interpolation Mesh";
            // 
            // MaxErrorLabel
            // 
            this.MaxErrorLabel.AutoSize = true;
            this.MaxErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxErrorLabel.Location = new System.Drawing.Point(13, 9);
            this.MaxErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxErrorLabel.Name = "MaxErrorLabel";
            this.MaxErrorLabel.Size = new System.Drawing.Size(141, 16);
            this.MaxErrorLabel.TabIndex = 1;
            this.MaxErrorLabel.Text = "Max Interpolation Error";
            // 
            // MaxErrorBox
            // 
            this.MaxErrorBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxErrorBox.Location = new System.Drawing.Point(13, 29);
            this.MaxErrorBox.Margin = new System.Windows.Forms.Padding(4);
            this.MaxErrorBox.Name = "MaxErrorBox";
            this.MaxErrorBox.Size = new System.Drawing.Size(150, 22);
            this.MaxErrorBox.TabIndex = 2;
            // 
            // MeshBox
            // 
            this.MeshBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MeshBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeshBox.FormattingEnabled = true;
            this.MeshBox.Items.AddRange(new object[] {
            "Normal Mesh",
            "Chebyschev Mesh"});
            this.MeshBox.Location = new System.Drawing.Point(171, 29);
            this.MeshBox.Margin = new System.Windows.Forms.Padding(4);
            this.MeshBox.Name = "MeshBox";
            this.MeshBox.Size = new System.Drawing.Size(150, 24);
            this.MeshBox.TabIndex = 3;
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(13, 59);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(150, 25);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OptimizeButton
            // 
            this.OptimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptimizeButton.Location = new System.Drawing.Point(171, 59);
            this.OptimizeButton.Margin = new System.Windows.Forms.Padding(4);
            this.OptimizeButton.Name = "OptimizeButton";
            this.OptimizeButton.Size = new System.Drawing.Size(150, 25);
            this.OptimizeButton.TabIndex = 5;
            this.OptimizeButton.Text = "Optimize";
            this.OptimizeButton.UseVisualStyleBackColor = true;
            this.OptimizeButton.Click += new System.EventHandler(this.OptimizeButton_Click);
            // 
            // Optimization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 99);
            this.Controls.Add(this.OptimizeButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.MeshBox);
            this.Controls.Add(this.MaxErrorBox);
            this.Controls.Add(this.MaxErrorLabel);
            this.Controls.Add(this.MeshLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(354, 138);
            this.MinimumSize = new System.Drawing.Size(354, 138);
            this.Name = "Optimization";
            this.Text = "Optimization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label MeshLabel;
        private System.Windows.Forms.Label MaxErrorLabel;
        private System.Windows.Forms.TextBox MaxErrorBox;
        private System.Windows.Forms.ComboBox MeshBox;
        new private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OptimizeButton;
        private System.Windows.Forms.ToolTip MaxErrorToolTip;
        private System.Windows.Forms.ToolTip InterpolationMeshToolTip;
        private System.Windows.Forms.ToolTip CancelButtonToolTip;
        private System.Windows.Forms.ToolTip OptimizeButtonToolTip;
        #endregion

    }
}