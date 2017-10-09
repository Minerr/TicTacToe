using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2
{
	public class BattleShips
	{
		public char[,] GameBoard1 { get; set; }

        public char[,] Gameboard2 { get; set; }

        public BattleShips(GameMode mode)
		{
            GameBoard1 = new char[10, 10]
            {
                {'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x'},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x'},
            };

            Gameboard2 = new char[10, 10]
            {
                { 'x', ' ', 'o', 'o', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', 'o', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            };

        }

		public string GetGameBoardView()
		{
			string resultat = "";
            int i = 0;

            if ( i <= 9 || i < 10)
            {
                for (i = 0; i < 10; i++)
                {
                    resultat = resultat + "\n *****************************************     *****************************************\n";
                    resultat = resultat + " | ";
                    for (int j = 0; j < 10; j++)
                    {
                        resultat = resultat + GameBoard1[j, i] + " | ";
     
                    }
                    resultat = resultat + "    | ";

                    for (int j = 0; j < 10; j++)
                    {

                        resultat = resultat + Gameboard2[j, i] + " | ";
                    }
                }
        
            }




            resultat = resultat + "\n *****************************************     *****************************************\n";

			return resultat;
		}
	}
}
