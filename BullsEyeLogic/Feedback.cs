namespace BullsEyeLogic
{
    public class Feedback
    {
        private const char k_HalfBoolSign = 'X';
        private const char k_BoolSign = 'V';
        private string m_FeedbackForGuess;

        public Feedback()
        {
            m_FeedbackForGuess = "";
        }

        public char HalfBoolSign
        {
            get { return k_HalfBoolSign; }
        }

        public char BoolSign
        {
            get { return k_BoolSign; }
        }

        public string FeedbackForGuess
        {
            get { return m_FeedbackForGuess; }
        }

        internal void CalculateFeedback(string i_UserInputGuess, string i_ComputerWord)
        {
            m_FeedbackForGuess = "";
            for (int i = 0; i < i_UserInputGuess.Length; i++)
            {
                if (i_ComputerWord[i] == i_UserInputGuess[i])
                {
                    m_FeedbackForGuess = string.Format("{0}{1}", k_BoolSign, m_FeedbackForGuess);
                }
                else if (i_ComputerWord.Contains(i_UserInputGuess[i].ToString()))
                {
                    m_FeedbackForGuess = string.Format("{0}{1}", m_FeedbackForGuess, k_HalfBoolSign);
                }
            }

            string spaces = new string(' ', i_UserInputGuess.Length - m_FeedbackForGuess.Length);
            m_FeedbackForGuess = string.Format("{0}{1}", m_FeedbackForGuess, spaces);
        }
    }
}
