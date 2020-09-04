using System;
using System.Windows.Forms;

namespace Project_One
{
    // This class is responsible for the optimization popup that the user sees and iteracts with
    public partial class Optimization : Form
    {
        // Constructor.
        public Optimization()
        {
            InitializeComponent();
            CenterToScreen();
            InitializeUI();
        }

        // If the cancel button is clicked
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Data.SetShouldOptimize(false);
            ActiveForm.Close();
        }

        // If the optimization button is clicked.
        private void OptimizeButton_Click(object sender, EventArgs e)
        {
            double givenError;
            // Check if the error is valid
            if ((givenError = GetMaxErrorInput()) != -1)
            {
                // pass the data to the data class
                Data.SetGivenError(GetMaxErrorInput());
                Data.SetTypeOfMesh(GetMeshTypeInput());
                Data.SetShouldOptimize(true);
                // Close the popup
                ActiveForm.Close();
            }
        }
    }
}
