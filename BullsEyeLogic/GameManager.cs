using System;


namespace Ex02
{
    public class GameManager
    {
        private const int k_WordLength = 4;
        private const char k_BottomLimitChar = 'A', k_TopLimitChar = 'H';
        private static Game s_Game;
        private static int s_MaxNumOfGuesses;

        internal static void initGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Bull's Eye!");
            s_MaxNumOfGuesses = GameUI.GetMaxNumOfGuesses();
            s_Game = new Game(s_MaxNumOfGuesses, k_WordLength);
            s_Game.CreateRandComputerWord();
            runGame();
        }
        private static void runGame()
        {
            string userInputWord;

            while (s_Game.CurrentGuessNum < s_MaxNumOfGuesses)
            {
                Console.Clear();
                GameUI.PrintBoard(s_Game, s_MaxNumOfGuesses);
                userInputWord = GameUI.GetUserInput(k_WordLength, k_BottomLimitChar, k_TopLimitChar);
                if (userInputWord.ToUpper() == "Q")
                {
                    Console.WriteLine("Good bye my friend, thanks for playing (:");
                    break;
                }

                s_Game.InsertResultToBoard
                    (userInputWord);
                if (s_Game.IsWon())
                {
                    wonGame();
                    break;
                }

                s_Game.IncreaseNumGuessByOne();
            }

            if (s_Game.CurrentGuessNum == s_MaxNumOfGuesses)
            {
                lostGame();
            }
        }

        private static void wonGame()
        {
            Console.Clear();
            GameUI.PrintBoard(s_Game, s_MaxNumOfGuesses);
            Console.WriteLine(string.Format("You guessed after {0} steps! ", s_Game.CurrentGuessNum + 1));
            restartOrFinish();
        }

        private static void lostGame()
        {
            Console.Clear();
            GameUI.PrintBoard(s_Game, s_MaxNumOfGuesses);
            Console.WriteLine(string.Format("You are out of guesses :( You Lost."));
            restartOrFinish();
        }

        private static void restartOrFinish()
        {
            string userAnswerToRestart;

            do
            {
                Console.WriteLine("Would you like to start a new game? <Y/N>");
                userAnswerToRestart = Console.ReadLine().ToUpper();
            }

            while (userAnswerToRestart != "Y" && userAnswerToRestart != "N");

            if (userAnswerToRestart == "N")
            {
                Console.WriteLine("Good bye my friend, thanks for playing (:");
            }
            else
            {
                initGame();
            }
        }
    }
}