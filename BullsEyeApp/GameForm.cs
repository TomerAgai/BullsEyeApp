using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BullsEyeLogic;

namespace BullsEyeApp
{
    public partial class GameForm : Form
    {
        private SettingsForm m_SettingForm;
        private readonly Button[,] r_GuessButtonsBoard;
        private readonly Button[] r_ArrowButtons;
        private readonly Button[,] r_ResultButtonsBoard;
        private readonly List<Color> r_SelectedColorsInCurrentRow;
        private readonly List<Button> r_ComputerChoiceButtonsList;
        private readonly Game r_Game;
        private int m_GuessesNumber;
        private Button m_LastClickedButton;
        private const int k_GuessLength = 4;
        private const int k_ButtonSize = 50;
        private const int k_Margin = 10;
        private const int k_StartHeight = 100;

        public GameForm()
        {
            m_SettingForm = new SettingsForm();
            m_SettingForm.ShowDialog();
            m_GuessesNumber = m_SettingForm.NumOfGuesses;
            r_GuessButtonsBoard = new Button[m_GuessesNumber, k_GuessLength];
            r_ArrowButtons = new Button[m_GuessesNumber];
            r_ResultButtonsBoard = new Button[m_GuessesNumber, k_GuessLength];
            r_Game = new Game(m_GuessesNumber, k_GuessLength);
            r_Game.CreateRandComputerWord();
            InitializeComponent();
            r_ComputerChoiceButtonsList = new List<Button>
            {
                button1,
                button2,
                button3,
                button4
            };
            InitializeDynamicControls();
            r_SelectedColorsInCurrentRow = new List<Color>();
        }

        private Button createButton(int i_Width, int i_Height, int i_XLocation, int i_YLocation, Color i_BackColor, string i_Text = "", bool i_Enabled = false)
        {
            Button button = new Button
            {
                Size = new Size(i_Width, i_Height),
                Location = new Point(i_XLocation, i_YLocation),
                BackColor = i_BackColor,
                Enabled = i_Enabled,
                Text = i_Text,
            };

            return button;
        }

        private void initializeGuessButtonsBoard()
        {
            int xButtonLocation, yButtonLocation;

            for (int row = 0; row < m_GuessesNumber; row++)
            {
                for (int col = 0; col < k_GuessLength; col++)
                {
                    xButtonLocation = k_Margin + col * (k_ButtonSize + k_Margin);
                    yButtonLocation = k_StartHeight + row * (k_ButtonSize + k_Margin);
                    r_GuessButtonsBoard[row, col] = createButton(k_ButtonSize, k_ButtonSize, xButtonLocation, yButtonLocation, Color.LightGray);
                    r_GuessButtonsBoard[row, col].Click += guessButton_Click;
                    this.Controls.Add(r_GuessButtonsBoard[row, col]);
                }
            }
        }

        private void initializeArrowButtons()
        {
            int xButtonLocation, yButtonLocation;

            for (int row = 0; row < m_GuessesNumber; row++)
            {
                xButtonLocation = k_Margin + 4 * (k_ButtonSize + k_Margin);
                yButtonLocation = k_StartHeight + row * (k_ButtonSize + k_Margin) + k_ButtonSize / 4;
                r_ArrowButtons[row] = createButton(k_ButtonSize, k_ButtonSize / 2, xButtonLocation, yButtonLocation, Color.LightGray, "→");
                r_ArrowButtons[row].Click += arrowButton_Click;
                this.Controls.Add(r_ArrowButtons[row]);
            }
        }

        private void initializeResultButtonsBoard()
        {
            int xButtonLocation, yButtonLocation;

            for (int row = 0; row < m_GuessesNumber; row++)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        xButtonLocation = r_ArrowButtons[row].Location.X + k_ButtonSize + ((j + 1) * k_ButtonSize / 2);
                        yButtonLocation = k_StartHeight + row * (k_ButtonSize + k_Margin) + (i * k_ButtonSize / 2);
                        r_ResultButtonsBoard[row, i * 2 + j] = createButton(k_ButtonSize / 2, k_ButtonSize / 2, xButtonLocation, yButtonLocation, Color.LightGray);
                        this.Controls.Add(r_ResultButtonsBoard[row, i * 2 + j]);
                    }
                }
            }
        }

        private void InitializeDynamicControls()
        {
            int rightmostPoint, bottommostPoint, additionalMargin = 10;

            initializeGuessButtonsBoard();
            initializeArrowButtons();
            initializeResultButtonsBoard();
            enableBoardRowGuessButtons();
            rightmostPoint = r_ResultButtonsBoard[m_GuessesNumber - 1, k_GuessLength - 1].Right;
            bottommostPoint = r_ResultButtonsBoard[m_GuessesNumber - 1, k_GuessLength - 1].Bottom;
            this.ClientSize = new Size(rightmostPoint + additionalMargin, bottommostPoint + additionalMargin);
        }

        private void guessButton_Click(object sender, EventArgs e)
        {
            m_LastClickedButton = sender as Button;
            ColorsForm colorForm = new ColorsForm();

            printList(r_SelectedColorsInCurrentRow);
            printList(r_SelectedColorsInCurrentRow);
            colorForm.ColorSelected += paintGuessButton;
            colorForm.ShowDialog();
        }

        private void printList(List<Color> l)
        {
            foreach (Color i in l)
            {
                Console.Write(i.ToString());
            }
            Console.WriteLine();
        }

        private void paintGuessButton(Color i_SelectedColor)
        {
            if (!r_SelectedColorsInCurrentRow.Contains(i_SelectedColor))
            {
                r_SelectedColorsInCurrentRow.Remove(m_LastClickedButton.BackColor);
                r_SelectedColorsInCurrentRow.Add(i_SelectedColor);
                m_LastClickedButton.BackColor = i_SelectedColor;
                if (isAllColorsSelectedInCurrentRow())
                {
                    r_ArrowButtons[r_Game.CurrentGuessNum].Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Color already selected in this row, please choose a different color.", "Color Already Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool isAllColorsSelectedInCurrentRow()
        {
            return r_SelectedColorsInCurrentRow.Count == k_GuessLength;
        }

        private void enableBoardRowGuessButtons()
        {
            for(int i = 0; i < k_GuessLength; i++)
            {
                r_GuessButtonsBoard[r_Game.CurrentGuessNum, i].Enabled = true;
            }
        }

        private void disableBoardRowGuessButtons()
        {
            for (int i = 0; i < k_GuessLength; i++)
            {
                r_GuessButtonsBoard[r_Game.CurrentGuessNum - 1, i].Enabled = false;
            }

        }

        private void paintCurrentResultButtons()
        {
            int resultIndicatorCounter = 0;
            string logicMatirxLineResultString = r_Game.Board.BoardMatrix[r_Game.CurrentGuessNum, 1];

            for (int i = 0; i < logicMatirxLineResultString.Length; i++)
            {
                if (logicMatirxLineResultString[i] == r_Game.Bool)
                {
                    r_ResultButtonsBoard[r_Game.CurrentGuessNum, resultIndicatorCounter].BackColor = Color.Black;
                    resultIndicatorCounter++;
                }
                else if (logicMatirxLineResultString[i] == r_Game.HalfBool)
                {
                    r_ResultButtonsBoard[r_Game.CurrentGuessNum, resultIndicatorCounter].BackColor = Color.Yellow;
                    resultIndicatorCounter++;
                }
            }
        }

        private string convertUserGuessedColorsToString()
        {
            StringBuilder userGuessedString = new StringBuilder();

            for (int i = 0; i < k_GuessLength; i++)
            {
                userGuessedString.Append(ColorUtilities.converColorToEnum(r_GuessButtonsBoard[r_Game.CurrentGuessNum, i].BackColor));
            }

            return userGuessedString.ToString();
        }

        private void arrowButton_Click(object sender, EventArgs e)
        {
            string userGuessedString = convertUserGuessedColorsToString();
            
            (sender as Button).Enabled = false;
            r_Game.InsertResultToBoard(userGuessedString);
            paintCurrentResultButtons();
            if (r_Game.IsWon())
            {
                finishGame("Congrats! You won");
            }
            else if (r_Game.IsOutOfGuesses())
            {
                finishGame("You lost ): You are out of guesses.");
            }
            else
            {
                r_Game.IncreaseNumGuessByOne();
                enableBoardRowGuessButtons();
                disableBoardRowGuessButtons();
                r_SelectedColorsInCurrentRow.Clear();
            }  
        }

        private void showComputerChoice()
        {
            string computerChoice = r_Game.ComputerWord;

            for (int i = 0; i < computerChoice.Length; i++)
            {
                r_ComputerChoiceButtonsList[i].BackColor = ColorUtilities.convertEnumToColor(computerChoice[i]);
            }
        }

        private void finishGame(string i_EndMessageToUser)
        {
            showComputerChoice();
            MessageBox.Show(i_EndMessageToUser, "Game finished", MessageBoxButtons.OK, MessageBoxIcon.None);
            r_Game.IncreaseNumGuessByOne();
            disableBoardRowGuessButtons();
        }
    }
}