using System;
using System.Windows.Forms;

namespace BullsEyeApp
{
    public partial class SettingsForm : Form
    {
        private int m_GuessesCounter = 4;

        public SettingsForm()
        {
            InitializeComponent();
        }

        public int NumOfGuesses
        {
            get { return m_GuessesCounter; }
        }

        private void buttonChancesCounter_Click(object sender, EventArgs e)
        {
            m_GuessesCounter = m_GuessesCounter < 10 ? m_GuessesCounter + 1 : 4;
            numberOfChancesButton.Text = string.Format("Number of guesses: {0}", m_GuessesCounter);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
