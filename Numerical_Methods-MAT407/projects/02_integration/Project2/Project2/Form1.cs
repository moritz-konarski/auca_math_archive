using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project2
{
    public partial class NumericalIntegration : Form
    {
        #region Data
        private string resultName;
        private static int problemNumber;
        private static int method;
        private static int numberOfNodes;
        private static double parameter;
        private static double theta;
        private static Graph graph;
        #endregion 

        // Constructor.
        public NumericalIntegration()
        {
            InitializeComponent();
            // Set indices of comboBoxes etc.
            InitializeElements();
        }

        #region Buttons
        // If the draw button is clicked.
        private void DrawButton_Click(object sender, EventArgs e)
        {
            // Get input parameters
            GetParameter();
            GetTheta();
            GetNumberOfNodes();

            // If the parameters are acceptable.
            if (!(parameter == -1) && !(theta == -1) && !(numberOfNodes == -1))
            {
                // Compute the selected function.
                Functions.ComputeFunction(problemNumber, parameter);

                // Choose the method of integration.
                switch (method)
                {
                    // Variant 1.
                    case 0:
                        Nodes.ComputeNodesV1(problemNumber, numberOfNodes, theta, parameter);
                        Integration.ComputeV1(problemNumber, numberOfNodes);
                        Trapezoid.ComputeRectanglesV1(Functions.GetNodesUniform(), Functions.GetNodesV1());
                        break;
                    // Variant 2.
                    case 1:
                        Nodes.ComputeNodesV2(problemNumber, numberOfNodes, theta, parameter);
                        Integration.ComputeV2(problemNumber, numberOfNodes);
                        Trapezoid.ComputeRectanglesV2(Functions.GetNodesUniform(), Functions.GetNodesV2());
                        break;
                    // Trapezia.
                    case 2:
                        Nodes.ComputeNodesTrapezoid(problemNumber, numberOfNodes, parameter);
                        Integration.ComputeTrapezoids(problemNumber, numberOfNodes);
                        Trapezoid.ComputeTrapezoids(Functions.GetNodesUniform());
                        break;
                    // Simpson.
                    case 3:
                        Nodes.ComputeNodesSimpson(problemNumber, numberOfNodes, parameter);
                        Integration.ComputeSimpson(problemNumber, numberOfNodes);
                        Functions.ComputeSimpsonGraph(problemNumber, numberOfNodes, parameter);
                        break;
                }
                // Draw the graph of the function.
                DrawGraph();
                // Set labels to display information
                SetLabels();
            }
        }

        // If the exit button is clicked.
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region ComboBox indices changed
        // Check the input for validity and update the value.
        private void ProblemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            problemNumber = ProblemBox.SelectedIndex;
            SetUI();
        }

        private void ParameterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetParameter();
        }

        private void MethodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            method = MethodBox.SelectedIndex;
            SetUI();
        }

        private void ThetaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTheta();
        }
        #endregion

        #region Enter Key pressed in ComboBox -> initiate Draw()
        private void MethodBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void ProblemBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void ParameterBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void MeshBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void ThetaBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }

        private void NodesBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIfEnterIsPressed(e);
        }
        #endregion

        // Resize the graph window if the form is resized.
        private void NumericalIntegration_Resize(object sender, EventArgs e)
        {
            GraphWindow.Location = new Point(15, 91);
            GraphWindow.IsShowPointValues = true;
            GraphWindow.Size = new Size(ClientRectangle.Width - 29, ClientRectangle.Height - 106);
        }

        private void CheckIfEnterIsPressed(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DrawButton.PerformClick();
            }
        }
    }
}
