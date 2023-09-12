using System;
namespace BullsEyeLogic
{
    public class Game
    {
        private Board m_Board;
        private int m_CurrNumOfGuesses;
        private readonly int r_MaxNumOfGuesses;
        private string m_ComputerWord;
        private readonly int r_WordLength;
        private const char k_HalfBool = 'X';
        private const char k_Bool = 'V';

        public Game(int i_MaxNumOfGuesses, int i_WordLength)
        {
            m_Board = new Board(i_MaxNumOfGuesses, i_WordLength);
            m_CurrNumOfGuesses = 0;
            r_MaxNumOfGuesses = i_MaxNumOfGuesses;
            r_WordLength = i_WordLength;
            m_ComputerWord = "";
        }
        
        public char HalfBool
        {
            get { return k_HalfBool; }
        }

        public char Bool
        {
            get { return k_Bool; }
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
            get { return m_Board; }
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

        public void InsertResultToBoard(string i_UserInput)
        {
            string matchToComputer = "", computerWord = m_ComputerWord;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (computerWord[i] == i_UserInput[i])
                {
                    matchToComputer = string.Format("{0}{1}", k_Bool,matchToComputer);
                }
                else if (computerWord.Contains(i_UserInput[i].ToString()))
                {
                    matchToComputer = string.Format("{0}{1}", matchToComputer, k_HalfBool);
                }
            }

            string spaces = new string(' ', i_UserInput.Length - matchToComputer.Length);
            matchToComputer = string.Format("{0}{1}", matchToComputer, spaces);
            m_Board.InsertToBoardMatrix(i_UserInput, m_CurrNumOfGuesses, 0);
            m_Board.InsertToBoardMatrix(matchToComputer, m_CurrNumOfGuesses, 1);
        }

        public bool IsWon()
        {
            bool isWon = false;

            if (m_Board.BoardMatrix[m_CurrNumOfGuesses, 0].Equals(m_ComputerWord))
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