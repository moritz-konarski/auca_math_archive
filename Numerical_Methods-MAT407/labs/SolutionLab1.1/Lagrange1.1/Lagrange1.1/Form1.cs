using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lagrange1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initializeGraph();          //set default axis and title
            initializeComboBoxes();     //set the default index of the boxes
        }

        //plot the chosen graph if the button is pressed
        private void DrawButton_Click(object sender, EventArgs e)
        {
            graphFunction();
        }

        //exit the program if exit button is pressed
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //check if the input is valid as soon as user leaves the box
        private void NodeBox_Leave(object sender, EventArgs e)
        {
            getNNodes();
        }

        //check if the input is valid as soon as user leaves the box
        private void ParameterBox_Leave(object sender, EventArgs e)
        {
            getEpsilon();
        }

        //if a new problem is selected, show its equation
        private void ProblemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ProblemBox.SelectedIndex)
            {
                case 0:
                    EquationBox.Image = (Image)Properties.Resources.func11;
                    break;
                case 1:
                    EquationBox.Image = (Image)Properties.Resources.func21;
                    break;
                case 2:
                    EquationBox.Image = (Image)Properties.Resources.func3;
                    break;
                case 3:
                    EquationBox.Image = (Image)Properties.Resources.func4;
                    break;
                case 4:
                    EquationBox.Image = (Image)Properties.Resources.func51;
                    break;
                case 5:
                    EquationBox.Image = (Image)Properties.Resources.func61;
                    break;
                case 6:
                    EquationBox.Image = (Image)Properties.Resources.func71;
                    break;
            }
        }

        //if user presses button to save screen
        private void SaveGraph_Click(object sender, EventArgs e)
        {
            saveGraph();
        }

        //if the window is resized, resize the graphing area
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            ZedGraphControl1.Location = new Point(13, 129);
            ZedGraphControl1.IsShowPointValues = true;
            ZedGraphControl1.Size = new Size(this.ClientRectangle.Width - 25, this.ClientRectangle.Height - 142);
        }

        //exports the data as .csv if the user wants
        private void ExportDataButton_Click(object sender, EventArgs e)
        {

            exportData();

        }
    }
}