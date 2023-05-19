using System;

namespace ArcadeGames
{
    class GuessTheNumber
    {
        static int attemptsLeft = new();
        static int playingNumber = new();

        static void DrawGame()
        {
            Console.Clear();
            Console.WriteLine(@"                                                           
 _____ _____ _____ _____ _____    _____ _____ _____    _____ _____ _____ _____ _____ _____ 
|   __|  |  |   __|   __|   __|  |_   _|  |  |   __|  |   | |  |  |     | __  |   __| __  |
|  |  |  |  |   __|__   |__   |    | | |     |   __|  | | | |  |  | | | | __ -|   __|    -|
|_____|_____|_____|_____|_____|    |_| |__|__|_____|  |_|___|_____|_|_|_|_____|_____|__|__|
                ");

            Console.Write("Attempts left: ");
            for (int i = 0; i < attemptsLeft; i++)
            {
                Console.Write('*');
            }
            Console.Write("\nGuess the number: ");
        }
        
        static bool RestartGame(int difficultyNumber, bool win = false)
        {
            while (true)
            {
                Console.WriteLine("\nDo you want to play again?\n");
                Console.WriteLine("1 - Restart game");
                Console.WriteLine("2 - Back to main menu");

                if (int.TryParse(Console.ReadLine(), out int optionChoosed) && optionChoosed < 3 && optionChoosed > 0)
                {
                    if (optionChoosed == 1)
                    {
                        attemptsLeft = 5;
                        playingNumber = new Random().Next(1, 15 * difficultyNumber);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                Console.WriteLine("Enter a valid option number.");
                Thread.Sleep(2000);

                DrawGame();
                if (win)
                {
                    Console.WriteLine($"\nYou won, the number is {playingNumber}");
                }
                else
                {
                    Console.WriteLine($"\nYou ran out of attempts, the number is {playingNumber}");
                }
            }
        }

        public static void StartGame(int difficultyNumber)
        {
            attemptsLeft = 5;
            playingNumber = new Random().Next(1, 15 * difficultyNumber);

            while (true)
            {
                DrawGame();
                
                if(!int.TryParse(Console.ReadLine(), out int numberChoosed))
                {
                    Console.WriteLine("Enter a valid number.");
                    Thread.Sleep(1500);
                    continue;
                }

                if (numberChoosed > playingNumber)
                {
                    Console.WriteLine("That number is too high");
                    attemptsLeft--;
                    Thread.Sleep(1200);
                }
                else if (numberChoosed < playingNumber)
                {
                    Console.WriteLine("That number is too low");
                    attemptsLeft--;
                    Thread.Sleep(1200);
                }
                else if (numberChoosed == playingNumber)
                {
                    Console.WriteLine($"You won, the number is {playingNumber}");
                    if (!RestartGame(difficultyNumber, win: true))
                    {
                        break;
                    }
                }

                if (attemptsLeft == 0)
                {
                    Console.WriteLine($"You ran out of attempts, the number is {playingNumber}");
                    if (!RestartGame(difficultyNumber))
                    {
                        break;
                    }
                }
            }
        }
    }
}
