using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2
{
	public class BattleShips
	{
		public char[,] GameBoard { get; set; }

		public BattleShips(GameMode mode)
		{

			GameBoard = new char[10, 10]
			{
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', 'X', 'O', 'O', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', 'O', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', '!', ' ', ' ', ' ', ' ', ' ', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
			};
		}

		public string GetGameBoardView()
		{
			string resultat = "";

			for(int i = 0; i < 10; i++)
			{
				resultat = resultat + "\n ****************************************\n";
				resultat = resultat + " | ";
				for(int j = 0; j < 10; j++)
				{
					resultat = resultat + GameBoard[j, i] + " | ";
				}
				
			}

			resultat = resultat + "\n ****************************************\n";

			return resultat;
		}
	}
}
