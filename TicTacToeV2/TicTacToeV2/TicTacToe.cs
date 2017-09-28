using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2
{
    public class TicTacToe
    {
        private char playerX = 'X';
        private char playerO = 'O';
        private char currentPlayer;
        public char CurrentPlayer       
        {
            get
            {
                return currentPlayer;
            }
        }

        public char[,] GameBoard { get; set; }
        public TicTacToe()
        {
            currentPlayer = playerX;

            GameBoard = new char[3, 3]
            {
                {' ', ' ', ' '},
                {' ', ' ', ' '},
                {' ', ' ', ' '}
            };
        }
        public string GetGameBoardView()
        {
            string resultat = "";
            resultat = resultat + "Y\n";
            resultat = resultat + "  *******************\n";
            resultat = resultat + "  *     *     *     *\n";
            resultat = resultat + "3 *  " + GameBoard[0, 2] + "  *  " + GameBoard[1, 2] + "  *  " + GameBoard[2, 2] + "  *\n";
            resultat = resultat + "  *     *     *     *\n";
            resultat = resultat + "  *******************\n";
            resultat = resultat + "  *     *     *     *\n";
            resultat = resultat + "2 *  " + GameBoard[0, 1] + "  *  " + GameBoard[1, 1] + "  *  " + GameBoard[2, 1] + "  *\n";
            resultat = resultat + "  *     *     *     *\n";
            resultat = resultat + "  *******************\n";
            resultat = resultat + "  *     *     *     *\n";
            resultat = resultat + "1 *  " + GameBoard[0, 0] + "  *  " + GameBoard[1, 0] + "  *  " + GameBoard[2, 0] + "  *\n";
            resultat = resultat + "  *     *     *     *\n";
            resultat = resultat + "  *******************\n";
            resultat = resultat + "     1     2     3    X\n";

            return resultat;
        }



        public bool PlacePiece(string userInput)
        {
            string[] inputs = userInput.Split(',');
            int x = 0;
            int y = 0;

            // Check if move is valid
            if (inputs.Length == 2)
            {
                string inputX = inputs[0];
                string inputY = inputs[1];

                if (inputX.Length == 1 && (inputX == "1" || inputX == "2" || inputX == "3"))
                {
                    x = Convert.ToInt32(inputX) - 1;
                }
                else
                {
                    return false;
                }

                if (inputY.Length == 1 && (inputY == "1" || inputY == "2" || inputY == "3"))
                {
                    y = Convert.ToInt32(inputY) - 1;
                }
                else
                {
                    return false;
                }

                if (GameBoard[x, y] == ' ')
                {
                    GameBoard[x, y] = currentPlayer;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            // Check for winning move
            bool winnerFound = CheckWin(x, y);
            ChangePlayer();

            return winnerFound;
        }

        private void ChangePlayer()
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

        private bool CheckWin(int x, int y)
        {
            if (CheckWinRow(x) || CheckWinColumn(y))
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
        private bool CheckWinDigDown()
        {
            if (GameBoard[2, 0] == currentPlayer && GameBoard[1, 1] == currentPlayer && GameBoard[0, 2] == currentPlayer)
            {
                return true;
            }
            return false;
        }
        private bool CheckWinDigUp()
        {
            if (GameBoard[0, 0] == currentPlayer && GameBoard[1, 1] == currentPlayer && GameBoard[2, 2] == currentPlayer)
            {
                return true;
            }
            return false;
        }
        private bool CheckWinRow(int x)
        {
            bool winner = true;
            for (int i = 0; i < 3; i++)
            {
                if (GameBoard[x, i] != currentPlayer)
                {
                    winner = false;
                    break;
                }
            }
            return winner;
        }
        private bool CheckWinColumn(int y)
        {
            bool winner = true;
            for (int i = 0; i < 3; i++)
            {
                if (GameBoard[i, y] != currentPlayer)
                {
                    winner = false;
                    break;
                }
            }
            return winner;
        }
    }
}
