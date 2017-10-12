using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGames
{
    public class BattleShips
    {
		// Start variables
        private const string player1 = "1";
        private const string player2 = "2";
		private string currentPlayer;
		private const int GRID_SIZE = 10;
		public int GridSize
		{
			get { return GRID_SIZE; }
		}

		// Properties
		public string CurrentPlayer
		{
			get { return currentPlayer; }
		}

		public char[,] P1GameBoard { get; set; }
        public char[,] P2GameBoard { get; set; }


        public BattleShips(GameMode mode) // Constructor method
		{
            currentPlayer = player1;
			
			P1GameBoard = new char[GRID_SIZE, GRID_SIZE]
			{
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
			};

            P2GameBoard = new char[GRID_SIZE, GRID_SIZE]
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', '!', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
            };
        }

        public string GetGameBoardView()
        {
            string resultat = "";
            Console.WriteLine("           Player Board                                    Opponents Board");

			for (int i = GRID_SIZE - 1; i >= 0; i--) // for hver række i vores grid, gør følgende: 
            {
                resultat = resultat + "\n *****************************************     *****************************************\n";
                resultat = resultat + " | ";
                for (int j = 0; j < GRID_SIZE; j++) // For hver plads i rækken (kolonnen), på gameboard P1, gør følgende:
                {
                    resultat = resultat + GetPlaceInBoard(j, i) + " | ";
                }

                resultat = resultat + "    | "; // Efter P1 gameboarded, start gameboard P2 med en opdeler: " | "
				
                for (int j = 0; j < GRID_SIZE; j++) // For hver plads i rækken (kolonnen), på gameboard P2, gør følgende:
				{
					resultat = resultat + GetPlaceInOpponentsBoard(j, i) + " | ";
                }
            }

            resultat = resultat + "\n *****************************************     *****************************************\n";

            return resultat;
        }

		// TODO: Refactor spaghetti code
		public bool PlaceBomb(int x, int y)
        {
			bool isValid = false;
			if(currentPlayer == player1)
			{
				char place = P2GameBoard[x, y];

				if(place == 'B')
				{
					P2GameBoard[x, y] = 'X';
					//TODO: If it was the last tile in ship, then change all tiles to #

					isValid = true;
				}
				else if(place == ' ')
				{
					P2GameBoard[x, y] = 'O';
					isValid = true;
				}
			}
			else
			{
				char place = P1GameBoard[x, y];

				if(place == 'B')
				{
					P1GameBoard[x, y] = 'X';
					//TODO: If it was the last tile in ship, then change all tiles to #

					isValid = true;
				}
				else if(place == ' ')
				{
					P1GameBoard[x, y] = 'O';
					isValid = true;
				}
			}

			return isValid;
		}

		public bool PlaceShip(int x, int y, char axis, Ship ship)
		{
			int shipLength = ship.Size;
			
			if(axis == 'H')
			{
				if((x >= 0 && x <= GRID_SIZE - shipLength) && (y >= 0 && y <= GRID_SIZE - 1))
				{
					for(int i = 0; i < shipLength; i++)
					{
						if(!(GetPlaceInBoard(x + i, y) == ' '))
						{
							return false;
						}
					}
				}
				else
				{
					return false;
				}
			}
			else if(axis == 'V')
			{
				if((x >= 0 && x <= GRID_SIZE - 1) && (y >= 0 && y <= GRID_SIZE - shipLength))
				{
					for(int i = 0; i < shipLength; i++)
					{
						if(!(GetPlaceInBoard(x, y + i) == ' '))
						{
							return false;
						}
					}
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

			// If we can place ship at coordinate, then change board to 'B'
			for(int i = 0; i < shipLength; i++)
			{
				if(axis == 'H')
				{
					PlaceShipInBoard(x + i, y);
				}
				else if(axis == 'V')
				{
					PlaceShipInBoard(x, y + i);
				}
			}

			return true; // return that we placed a ship
		}

		private void PlaceShipInBoard(int x, int y)
		{
			if(currentPlayer == player1)
			{
				P1GameBoard[x, y] = 'B';
			}
			else
			{
				P2GameBoard[x, y] = 'B';
			}
		}

		private char GetPlaceInBoard(int x, int y)
		{
			if(currentPlayer == player1)
			{
				return P1GameBoard[x, y];
			}
			else
			{
				return P2GameBoard[x, y];
			}
		}

		private char GetPlaceInOpponentsBoard(int x, int y)
		{
			char place = ' ';
			if(currentPlayer == player1)
			{
				place = P2GameBoard[x, y];
			}
			else
			{
				place = P1GameBoard[x, y];
			}

			if(place == 'B')
			{
				return ' ';
			}

			return place;
		}

		public string GetCurrentPlayer()         
        {
            return currentPlayer;
        }

        public void ChangePlayer()
        {
            if (currentPlayer == player1)
            {
                currentPlayer = player2;
            }
            else
            {
                currentPlayer = player1;
            }
        }

		public string NextPlayer()
		{
			if(currentPlayer == player1)
			{
				return player2;
			}
			else
			{
				return player1;
			}
		}

		public bool CheckWinCondition()
		{
			if(currentPlayer == player1)
			{
				foreach(char place in P2GameBoard)
				{
					if(place == 'B')
					{
						return false;
					}
				}
			}
			else
			{
				foreach(char place in P1GameBoard)
				{
					if(place == 'B')
					{
						return false;
					}
				}
			}

			return true;
		}


	}

}
