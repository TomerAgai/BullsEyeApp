namespace BullsEyeLogic
{
    public class Board
    {
        private const int k_NumOfColls = 2;
        private readonly string[,] r_BoardMatrix;

        public Board(int i_NumBoardRows, int i_WordLength)
        {
            r_BoardMatrix = new string[i_NumBoardRows, k_NumOfColls];
            initBoard(i_NumBoardRows, i_WordLength);
        }

        private void initBoard(int i_NumBoardRows, int i_WordLength)
        {
            for (int i = 0; i < i_NumBoardRows; i++)
            {
                for (int j = 0; j < k_NumOfColls; j++)
                {
                    r_BoardMatrix[i, j] = new string(' ', i_WordLength);
                }
            }
        }

        public string[,] BoardMatrix
        {
            get { return r_BoardMatrix; }
        }

        internal void InsertToBoardMatrix(string i_WordToAdd, int i_NumOfRow, int i_NumOfCol)
        {
            r_BoardMatrix[i_NumOfRow, i_NumOfCol] = i_WordToAdd;
        }
    }
}