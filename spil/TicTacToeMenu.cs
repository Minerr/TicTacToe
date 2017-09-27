using System;

namespace spil
{
    public class TicTacToeMenu
    {
        TicTacToe TicTacToe {get; set; }

        private char playerX = 'X';
        private char playerO = 'O';
        private char currentPlayer;

        public TicTacToeMenu()
        {
            currentPlayer = playerX;
        }

        public void Show()
        {
            bool running = true;            
            string choice = "";
            do
            {
                ShowMenu();
                choice = GetUserChoise();
                switch (choice)
                {
                    case "1": CreateNewGame(); break;
                    case "2": SetPiece(); break;
                    case "3": DoActionFor3(); break;
                    case "0": running = false; break;
                    default : ShowMenuSelectionErroe(); break;
                }
            } while (running);
        }

        public void ShowMenu()
        {
            Console.Clear();
            if (TicTacToe != null)
            {
                Console.WriteLine(TicTacToe.GetGameBoardView());
            }
            Console.WriteLine("tic tac toe");
            Console.WriteLine();
            Console.WriteLine("1. Opret nyt spil");
            Console.WriteLine("2. Set en brik");
            Console.WriteLine("3. Flyt en brik");
            Console.WriteLine();
            Console.WriteLine("0. exit");
        }

        public string GetUserChoise()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }

        public void ShowMenuSelectionErroe()
        {
            Console.WriteLine("Ugyldigt valg.");
            Console.ReadLine();
        }

        public void ChangePlayer()
        {

            if (currentPlayer == playerX)
            {
                currentPlayer = playerO;
            }
            else
            {
                currentPlayer = playerX;
            }
        }
        public bool CheckWin(int x, int y)
        {
            if(CheckWinRow(x) || CheckWinColumn(y))
            {
                return true;
            }
            if ((x == 0 && y == 2) || (x == 2 && y == 0))
            {
                return CheckWinDigDown();
            }
            if ((x == 0 && y == 0) || (x == 2 && y == 2))
            {
                return CheckWinDigUp();
            }
            if (x == 1 && y == 1)
            {
                return CheckWinDigDown() || CheckWinDigUp();
            }
            return false;
        }
        public bool CheckWinDigDown()
        {
            if (TicTacToe.GameBoard[2, 0] == currentPlayer && TicTacToe.GameBoard[1, 1] == currentPlayer && TicTacToe.GameBoard[0,2] == currentPlayer)
            {
                return true;
            }
            return false;
        }
        public bool CheckWinDigUp()
        {
            if (TicTacToe.GameBoard[0, 0] == currentPlayer && TicTacToe.GameBoard[1, 1] == currentPlayer && TicTacToe.GameBoard[2, 2] == currentPlayer)
            {
                return true;
            }
            return false;
        }
        public bool CheckWinRow(int x)
        {
            bool winner = true;
            for (int i = 0; i < 3; i++)
            {
                if (TicTacToe.GameBoard[x, i] != currentPlayer)
                {
                    winner = false;
                    break;
                }
            }
            return winner;
        }
        public bool CheckWinColumn(int y)
        {
            bool winner = true;
            for (int i = 0; i < 3; i++)
            {
                if (TicTacToe.GameBoard[i, y] != currentPlayer)
                {
                    winner = false;
                    break;
                }
            }
            return winner;
        }

        public void CreateNewGame()
        {
            TicTacToe = new TicTacToe();

        }
        public void SetPiece()
        {
            Console.WriteLine("Skrive koordinat til Gameboard, skriv koordinater adskilt med komma.");
            string input = Console.ReadLine();
            string[] inputs = input.Split(',');

            int x = Convert.ToInt32(inputs[0])-1;
            int y = Convert.ToInt32(inputs[1])-1;
            char z = currentPlayer;

            TicTacToe.GameBoard[x, y] = z;
            if (CheckWin(x, y))
            {
                Console.WriteLine("Player " + currentPlayer + " is the winner!");
                Console.ReadKey();
                CreateNewGame();
            }
            else
            {
                ChangePlayer();
            }
        }
        public void DoActionFor3()
        {
            Console.WriteLine("skriv koden til at få spillerens input til at flytte en brik");
            Console.ReadLine();
        }
    }
}