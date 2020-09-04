using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_One
{
    public partial class Form1 : Form
    {
        #region Data
        private static Graphing graph;
        #endregion

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            InitializeUI();
            graph = new Graphing(graphWindow);
        }

        // Plot the graph on button press.
        private void DrawButton_Click(object sender, EventArgs e)
        {
            // Make the label used for optimization invisible
            OptimizationErrorLabel.Visible = false;

            // Compute the function, nodes, interpolation and error.
            ComputeFunctions();

            // Display the max error
            SetLabels();

            // Display the max Error
            GraphFunctions(graph);
        }

        // Exit the program on button press.
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Check input of the node box.
        private void NodeBox_Leave(object sender, EventArgs e)
        {
            GetNumberOfNodesInput();
        }

        // Check input of the parameter box.
        private void ParameterBox_Leave(object sender, EventArgs e)
        {
            GetEpsilonInput();
        }

        // Save a screenshot on button press.
        private void SaveGraph_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        // If the window is resized, resize the graph area.
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            graphWindow.Location = new Point(16, 118);
            graphWindow.IsShowPointValues = true;
            graphWindow.Size = new Size(this.ClientRectangle.Width - 33, this.ClientRectangle.Height - 142);
        }

        // If the user clicks the optimization button
        private void OptimizeButton_Click(object sender, EventArgs e)
        {
            // Open the popup for optimization
            var optimization = new Optimization();
            optimization.ShowDialog(this);
            // If the user did not click "cancel"
            if (Data.ShouldOptimize())
            {
                // set the values the user entered on the form
                MeshBox.SelectedIndex = Data.GetTypeOfMesh();
                OptimizationErrorLabel.Text = string.Format("optimization |Error| < {0:E3}", Data.GetGivenError());
                OptimizationErrorLabel.Visible = true;

                // Compute the optimization for a given error.
                ComputeOptimization();

                // Set the nodeBox to the final number of nodes
                NodeBox.Text = Convert.ToString(Data.GetNumberOfNodes());

                // Display the max error of the actual optimization
                SetLabels();

                // Draw the graph of the functions
                GraphFunctions(graph);
            }
        }
    }
}
