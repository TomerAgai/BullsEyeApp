using System;

namespace Ex02
{
    public class GameUI
    {
        internal static void PrintBoard(Game i_Game, int i_MaxNumOfGuesses)
        {
            string partialBoardToPrint, computerWord = "####";

            if (i_Game.CurrentGuessNum == i_MaxNumOfGuesses || i_Game.IsWon())
            {
                computerWord = i_Game.ComputerWord;
            }

            string[,] boardMatrix = i_Game.Board.BoardMatrix;
            partialBoardToPrint = string.Format(@"Current board status:

|Pins:    |Result:  |
|=========|=========|
| {0} |         |
|=========|=========|", string.Join(" ", computerWord.ToCharArray()));
            Console.WriteLine(partialBoardToPrint);
            for (int i = 0; i < boardMatrix.GetLength(0); i++)
            {
                partialBoardToPrint = string.Format(@"| {0} | {1} |
|=========|=========|", string.Join(" ", boardMatrix[i, 0].ToCharArray()), string.Join(" ", boardMatrix[i, 1].ToCharArray()));
                Console.WriteLine(partialBoardToPrint);
            }

            Console.WriteLine();
        }

        internal static int GetMaxNumOfGuesses()
        {
            string maxNumOfGuessesString;

            while (true)
            {
                Console.WriteLine("Insert the maximal number of guesses. (4-10).");
                maxNumOfGuessesString = Console.ReadLine();
                if (int.TryParse(maxNumOfGuessesString, out int maxNumOfGuesses) && maxNumOfGuesses >= 4 && maxNumOfGuesses <= 10)
                {
                    return maxNumOfGuesses;
                }

                Console.WriteLine("Invalid input");
            }
        }

        private static bool isValidInput(string i_UserInput, char i_BottomLimitChar, char i_TopLimitChar, ref string o_ValidationMessage, int i_WordLength)
        {
            bool isValid = false;

            if (i_UserInput.ToUpper() == "Q")
            {
                isValid = true;
            }
            else if (i_UserInput.Length != i_WordLength)
            {
                o_ValidationMessage = string.Format("Input must be {0} letters long", i_WordLength);
            }
            else
            {
                isValid = true;
                foreach (char c in i_UserInput)
                {
                    if (!char.IsLetter(c))
                    {
                        isValid = false;
                        o_ValidationMessage = "Input must be in letters";
                        break;
                    }

                    if (c < i_BottomLimitChar || c > i_TopLimitChar)
                    {
                        isValid = false;
                        o_ValidationMessage = "Input letters are out of bound";
                        break;
                    }
                }
            }

            return isValid;
        }

        internal static string GetUserInput(int i_WordLength, char i_BottomLimitChar, char i_TopLimitChar)
        {
            string userInput, validationMessage = "c#rocks(invalid Input)";

            while (true)
            {
                Console.WriteLine("Please type your next guess, a word with {0} letters from range {1} - {2}, Or 'Q' to quit", i_WordLength, i_BottomLimitChar, i_TopLimitChar);
                userInput = Console.ReadLine();
                if (isValidInput(userInput, i_BottomLimitChar, i_TopLimitChar, ref validationMessage, i_WordLength))
                {
                    return userInput;
                }

                Console.WriteLine(validationMessage);
            }
        }
    }
}