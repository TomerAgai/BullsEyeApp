using System;
using System.Windows.Forms;
using System.Drawing;

namespace BullsEyeApp
{
    internal class ColorsForm : Form
    {
        public event Action<Color> ColorSelected;
        private readonly Button[] r_ColorButtons;
        private const int k_ButtonSize = 50;
        private const int k_Margin = 10;

        public ColorsForm()
        {
            r_ColorButtons = new Button[8];
            initControls();
        }

        private void arrangeButtonsInGrid(int columns, int rows)
        {
            for (int i = 0; i < r_ColorButtons.Length; i++)
            {
                r_ColorButtons[i].Location = new Point(
                    k_Margin + (i % columns) * (k_ButtonSize + k_Margin),
                    k_Margin + (i / columns) * (k_ButtonSize + k_Margin)
                );
            }
        }

        private void initControls()
        {
            Color[] colors = { Color.Purple, Color.Red, Color.Green, Color.LightBlue, Color.Blue, Color.Yellow, Color.Brown, Color.White };
            string[] colorNames = { "Purple", "Red", "Green", "LightBlue", "Blue", "Yellow", "Brown", "White" };

            for (int i = 0; i < r_ColorButtons.Length; i++)
            {
                r_ColorButtons[i] = new Button
                {
                    BackColor = colors[i],
                    Name = colorNames[i],
                    Size = new Size(k_ButtonSize, k_ButtonSize),
                    Text = ""
                };
                r_ColorButtons[i].Click += colorButton_Click;
                this.Controls.Add(r_ColorButtons[i]);
            }

            arrangeButtonsInGrid(4, 2);
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            ColorSelected?.Invoke(clickedButton.BackColor);
            this.Close();
        }

       
    }
}
