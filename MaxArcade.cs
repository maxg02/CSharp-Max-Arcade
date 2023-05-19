using System;
using ArcadeGames;

namespace MaxArcade
{
    enum Games
    {
        TicTacToe=1,
        Hangman=2,
        Guess=3
    }

    class MaxArcade
    {
               
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
  __  __   _   __  __    _   ___  ___   _   ___  ___ 
 |  \/  | /_\  \ \/ /   /_\ | _ \/ __| /_\ |   \| __|
 | |\/| |/ _ \  >  <   / _ \|   / (__ / _ \| |) | _| 
 |_|  |_/_/ \_\/_/\_\ /_/ \_\_|_\\___/_/ \_\___/|___|
                ");

                Console.WriteLine("Choose a game: \n");
                Console.WriteLine("1 - Tic Tac Toe");
                Console.WriteLine("2 - Hangman");
                Console.WriteLine("3 - Guess the number");
                Console.WriteLine("4 - Exit");

                if (int.TryParse(Console.ReadLine(), out int gameChoiceNumber) && gameChoiceNumber > 0 && gameChoiceNumber < 5)
                {
                    if (gameChoiceNumber == (int)Games.TicTacToe)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine(@"
     ____  ____  ___    ____   __    ___    ____  _____  ____ 
    (_  _)(_  _)/ __)  (_  _) /__\  / __)  (_  _)(  _  )( ___)
      )(   _)(_( (__     )(  /(__)\( (__     )(   )(_)(  )__) 
     (__) (____)\___)   (__)(__)(__)\___)   (__) (_____)(____)                                             
                            ");

                            Console.WriteLine("Choose a gamemode: \n");
                            Console.WriteLine("1 - Single player");
                            Console.WriteLine("2 - Multiplayer");
                            Console.WriteLine("3 - Exit");

                            if (int.TryParse(Console.ReadLine(), out int choiceNumber) && choiceNumber > 0 && choiceNumber < 4)
                            {
                                if (choiceNumber != 3)
                                {
                                    TicTacToe.StartGame(choiceNumber);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid option number.");
                                Thread.Sleep(2000);
                            }
                        }
                    }

                    else if (gameChoiceNumber == (int)Games.Hangman)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine(@"
 _  _   __   __ _   ___  _  _   __   __ _ 
/ )( \ / _\ (  ( \ / __)( \/ ) / _\ (  ( \
) __ (/    \/    /( (_ \/ \/ \/    \/    /
\_)(_/\_/\_/\_)__) \___/\_)(_/\_/\_/\_)__)               
                            ");
                            Console.WriteLine("Choose the difficulty: \n");
                            Console.WriteLine("1 - Easy");
                            Console.WriteLine("2 - Medium");
                            Console.WriteLine("3 - Hard");
                            Console.WriteLine("4 - Exit");

                            if (int.TryParse(Console.ReadLine(), out int choiceNumber) && choiceNumber > 0 && choiceNumber < 5)
                            {
                                if (choiceNumber != 4)
                                {
                                    HangMan.StartGame(choiceNumber);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid option number.");
                                Thread.Sleep(2000);
                            }
                        }
                    }

                    else if (gameChoiceNumber == (int)Games.Guess)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine(@"                                                           
 _____ _____ _____ _____ _____    _____ _____ _____    _____ _____ _____ _____ _____ _____ 
|   __|  |  |   __|   __|   __|  |_   _|  |  |   __|  |   | |  |  |     | __  |   __| __  |
|  |  |  |  |   __|__   |__   |    | | |     |   __|  | | | |  |  | | | | __ -|   __|    -|
|_____|_____|_____|_____|_____|    |_| |__|__|_____|  |_|___|_____|_|_|_|_____|_____|__|__|
                            ");
                            Console.WriteLine("Choose the difficulty: \n");
                            Console.WriteLine("1 - Easy (1-15)");
                            Console.WriteLine("2 - Medium (1-30)");
                            Console.WriteLine("3 - Hard (1-45)");
                            Console.WriteLine("4 - Exit");

                            if (int.TryParse(Console.ReadLine(), out int choiceNumber) && choiceNumber > 0 && choiceNumber < 5)
                            {
                                if (choiceNumber != 4)
                                {
                                    GuessTheNumber.StartGame(choiceNumber);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid option number.");
                                Thread.Sleep(2000);
                            }
                        }
                    }

                    else if (gameChoiceNumber == 4)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid option number.");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
