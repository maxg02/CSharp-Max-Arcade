using System;

namespace ArcadeGames
{
    class TicTacToe
    {
        static char[,] board = new char[3,3];

        enum GameModes
        {
            singlePlayer=1,
            multiPlayer=2
        }

        enum Players
        {
            X=1,
            O=2
        }

        static void DrawBoard()
        {
            Console.Clear();            
            for (int row = 2; row >= 0; row--)
            {
                Console.WriteLine($" {board[row, 0]} | {board[row, 1]} | {board[row, 2]} ");
                if (row > 0)
                {
                    Console.WriteLine($"-----------");
                }
            }
        }

        static bool MakeMove(Players player, int move)
        {
            int moveRow = (int)Math.Floor((float)(move - 1) / 3);
            int moveCol = move - ((moveRow * 3) + 1);

            if (board[moveRow, moveCol] != ' ')
            {
                return false;
            }

            board[moveRow, moveCol] = char.Parse(player.ToString());
            return true;
        }

        static bool CheckWin(Players player)
        {

            char playerChar = char.Parse(player.ToString());
            bool Win;

            //Check vertical win
            for (int col = 0; col < 3; col++)
            {
                Win = true;
                for (int row = 0; row < 3; row++)
                {
                    if (board[row, col] != playerChar)
                    {
                        Win = false;
                    }
                }
                if (Win) { return true; }
            }

            //Check horizontal win
            for (int row = 0; row < 3; row++)
            {
                Win = true;
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] != playerChar)
                    {
                        Win = false;
                    }
                }
                if (Win) { return true; }
            }

            //Check diagonal win /
            Win = true;
            for (int row = 0, col = 0; row < 3 && col < 3; row++, col++)
            {
                if (board[row, col] != playerChar)
                {
                    Win = false;
                }
            }
            if (Win) { return true; }

            //Check diagonal win \
            Win = true;
            for (int row = 0, col =  2; row < 3 && col >= 0; row++, col--)
            {
                if (board[row, col] != playerChar)
                {
                    Win = false;
                }
            }
            if (Win) { return true; }

            return false;
        }

        static bool RestartGame()
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
                        board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                Console.WriteLine("Enter a valid option number");
                Thread.Sleep(2000);
                DrawBoard();
            }
        }

        static bool GameLockedCheck()
        {
            bool gameLocked = true;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row,col] == ' ')
                    {
                        gameLocked = false;
                    }
                }
            }

            return gameLocked;
        }

        public static void StartGame(int gameMode)
        {
            Console.Clear();
            board = new char[3, 3] { { ' ', ' ', ' ' },
                                     { ' ', ' ', ' ' },
                                     { ' ', ' ', ' ' } };
            GameModes gameModeChoosed = (GameModes)gameMode;

            Players currentPlayer = Players.X;
            int moveChoosed;

            while (true)
            {
                DrawBoard();

                while (true)
                {
                    if (currentPlayer == Players.O && gameModeChoosed == GameModes.singlePlayer)
                    {
                        moveChoosed = new Random().Next(1, 10);
                    }
                    else
                    {
                        Console.WriteLine($"\nPlayer {(int)currentPlayer}, select an empty box (1 - 9): ");
                        
                        if (!int.TryParse(Console.ReadLine(), out moveChoosed) || moveChoosed < 1 || moveChoosed > 9)
                        {
                            Console.WriteLine("Enter a valid box number");
                            Thread.Sleep(2000);
                            DrawBoard();
                            continue;
                        }
                    }

                    if (MakeMove(currentPlayer, moveChoosed))
                    {
                        break;
                    }
                    else if (currentPlayer == Players.X || gameModeChoosed == GameModes.multiPlayer)
                    {
                        DrawBoard();
                        
                        Console.WriteLine("\nSelect an empty box");
                        Thread.Sleep(2000);
                        
                        DrawBoard();
                    }
                }

                if (CheckWin(currentPlayer))
                {
                    DrawBoard();

                    Console.WriteLine($"\nPlayer {(int)currentPlayer} wins!!");

                    if (RestartGame())
                    {
                        currentPlayer = Players.X;
                        continue;
                    }
                    else { break; }
                }

                if (GameLockedCheck())
                {
                    DrawBoard();
                    Console.WriteLine($"\nGame is locked, no moves available");

                    if (RestartGame())
                    {
                        currentPlayer = Players.X;
                        continue;
                    }
                    else { break; }
                }

                currentPlayer = currentPlayer == Players.X ? Players.O : Players.X;
            }
        }
    }
}
