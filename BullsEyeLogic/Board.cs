using System;
namespace BullsEyeLogic
{
    public class Board
    {
        private const int k_NumOfColls = 2;
        private readonly string[,] m_BoardMatrix;

        public Board(int i_NumBoardLines, int i_WordLength)
        {
            m_BoardMatrix = new string[i_NumBoardLines, k_NumOfColls];
            initBoard(i_NumBoardLines, i_WordLength);
        }

        private void initBoard(int i_NumBoardLines, int i_WordLength)
        {
            for (int i = 0; i < i_NumBoardLines; i++)
            {
                for (int j = 0; j < k_NumOfColls; j++)
                {
                    m_BoardMatrix[i, j] = new string(' ', i_WordLength);
                }
            }
        }

        public string[,] BoardMatrix
        {
            get
            {
                return m_BoardMatrix;
            }
        }

        internal void InsertToBoardMatrix(string i_WordToAdd, int i_NumOfLine, int i_NumOfCol)
        {
            m_BoardMatrix[i_NumOfLine, i_NumOfCol] = i_WordToAdd;
        }
    }
}