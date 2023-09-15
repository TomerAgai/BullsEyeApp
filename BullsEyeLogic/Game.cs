using System;

namespace BullsEyeLogic
{
    public class Game
    {
        private readonly Board r_Board;
        private readonly Feedback r_Feedback;
        private readonly int r_MaxNumOfGuesses;
        private readonly int r_WordLength;
        private int m_CurrNumOfGuesses;
        private string m_ComputerWord;

        public Game(int i_MaxNumOfGuesses, int i_WordLength)
        {
            r_Board = new Board(i_MaxNumOfGuesses, i_WordLength);
            r_Feedback = new Feedback();
            r_MaxNumOfGuesses = i_MaxNumOfGuesses;
            r_WordLength = i_WordLength;
            m_CurrNumOfGuesses = 0;
            m_ComputerWord = "";
        }

        public string ComputerWord
        {
            get { return m_ComputerWord; }
        }

        public int CurrentGuessNum
        {
            get { return m_CurrNumOfGuesses; }
        }

        public Board Board
        {
            get { return r_Board; }
        }

        public Feedback Feedback
        {
            get { return r_Feedback; }
        }

        public void IncreaseNumGuessByOne()
        {
            m_CurrNumOfGuesses++;
        }

        public void CreateRandComputerWord()
        {
            char randomChar;
            Random random = new Random();

            for (int i = 0; i < r_WordLength; i++)
            {
                do
                {
                    randomChar = (char)('A' + random.Next(8));
                }

                while (m_ComputerWord.Contains(randomChar.ToString()));
                m_ComputerWord = string.Format("{0}{1}", m_ComputerWord, randomChar);
            }
        }

        public void CalculateAndInsertGuessAndFeedbackToBoard(string i_UserInput)
        {
            r_Feedback.CalculateFeedback(i_UserInput, m_ComputerWord);
            r_Board.InsertToBoardMatrix(i_UserInput, m_CurrNumOfGuesses, 0);
            r_Board.InsertToBoardMatrix(r_Feedback.FeedbackForGuess, m_CurrNumOfGuesses, 1);
        }

        public bool IsWon()
        {
            bool isWon = false;

            if (r_Board.BoardMatrix[m_CurrNumOfGuesses, 0].Equals(m_ComputerWord))
            {
                isWon = true;
            }

            return isWon;
        }

        public bool IsOutOfGuesses()
        {
            return m_CurrNumOfGuesses + 1 >= r_MaxNumOfGuesses;
        }
    }
}