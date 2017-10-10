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

			P1GameBoard = new char[10, 10]
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

            P2GameBoard = new char[10, 10]
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
            int i = 0;


            Console.WriteLine("           Player Board                                    Opponents Board");
            for (i = 0; i < 10; i++)
            {
                resultat = resultat + "\n *****************************************     *****************************************\n";
                resultat = resultat + " | ";
                for (int j = 0; j < 10; j++)
                {
                    resultat = resultat + P1GameBoard[j, i] + " | ";
                }

                resultat = resultat + "    | ";

                for (int j = 0; j < 10; j++)
                {
                    resultat = resultat + P2GameBoard[j, i] + " | ";
                }
            }

            resultat = resultat + "\n *****************************************     *****************************************\n";

            return resultat;
        }

        public bool IsHit(char [] validCoordinates)
        {
            int j = Convert.ToInt32(validCoordinates[0]) - 1;
            int i = Convert.ToInt32(validCoordinates[1]) - 1;

            if (P2GameBoard[j, i] == 'B')
            {
                P2GameBoard[j, i] = 'X';
                return true;

            }
            else if (P2GameBoard[j, i] == ' ')
            {
                P2GameBoard[j, i] = 'O';
                return true;
            }

            return false;

			
		}
        public string GetCurrentPlayer()         
        {

            return currentPlayer;
        }
        private void ChangePlayer()
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
	}

}
