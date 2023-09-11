using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BullsEyeApp
{
    public class GameForm : Form
    {
        private readonly Button[] r_TopButtons;
        private readonly Button[,] r_GameBoardButtons;
        private Button m_LastClickedButton;
        private readonly int r_NumOfGuesses;
        private const int k_NumOfGuessesInRow = 4;
        private const int k_ButtonSize = 50;
        private const int k_Margin = 10;

        public GameForm()
        {
            SettingsForm settingsForm = new SettingsForm();
            r_NumOfGuesses = settingsForm.NumberOfChances;
            settingsForm.ShowDialog();
            r_TopButtons = new Button[k_NumOfGuessesInRow];
            r_GameBoardButtons = new Button[r_NumOfGuesses, k_NumOfGuessesInRow];
            initControls();
        }

        private void initControls()
        {
            for (int i = 0; i < r_TopButtons.Length; i++)
            {
                r_TopButtons[i] = new Button
                {
                    BackColor = Color.Black,
                    Size = new Size(k_ButtonSize, k_ButtonSize),
                    Text = string.Empty,
                    Location = new Point(k_Margin + i * (k_ButtonSize + k_Margin), 150)
                };
                this.Controls.Add(r_TopButtons[i]);
            }

            for (int i = 0; i < r_NumOfGuesses; i++)
            {
                for (int j = 0; j < k_NumOfGuessesInRow; j++)
                {
                    r_GameBoardButtons[i, j] = new Button
                    {
                        Size = new Size(k_ButtonSize, k_ButtonSize),
                        Text = string.Empty,
                        Location = new Point(k_Margin + j * (k_ButtonSize + k_Margin), 200 + i * (k_ButtonSize + k_Margin))
                    };
                    r_GameBoardButtons[i, j].Click += boardButton_Click;
                    this.Controls.Add(r_GameBoardButtons[i, j]);
                }
            }
        }

        private void boardButton_Click(object sender, EventArgs e)
        {
            m_LastClickedButton = sender as Button;
            ColorsForm colorsForm = new ColorsForm();
            colorsForm.ColorSelected += onColorSelected;
            colorsForm.ShowDialog();
        }

        private void onColorSelected(Color i_SelectedColor)
        {
            m_LastClickedButton.BackColor = i_SelectedColor;
        }

        enum eColors
        {
            Purple = 'A',
            Red = 'B',
            Green = 'C',
            LightBlue = 'D',
            Blue = 'E',
            Yellow = 'F',
            Brown = 'G',
            White = 'H'
        }
    }
}
