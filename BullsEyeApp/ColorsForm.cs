using System;
using System.Drawing;
using System.Windows.Forms;

namespace BullsEyeApp
{
    public partial class ColorsForm : Form
    {
        public event Action<Color> ColorSelected;

        public ColorsForm()
        {
            InitializeComponent();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            ColorSelected?.Invoke(clickedButton.BackColor);
            this.Close();
        }
    }
}
