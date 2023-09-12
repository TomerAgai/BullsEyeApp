using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void ColorsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
