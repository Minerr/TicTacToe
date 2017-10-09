﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2
{
    public class BattleShips
    {
        private const string player1 = "player1";
        private const string player2 = "player2";
		public char[,] P1GameBoard { get; set; }
        public char[,] P2GameBoard { get; set; }
        private string currentPlayer;
        public BattleShips(GameMode mode)
        
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
                    resultat = resultat + GameBoard1[j, i] + " | ";
                }

                resultat = resultat + "    | ";

                for (int j = 0; j < 10; j++)
                {
                    resultat = resultat + Gameboard2[j, i] + " | ";
                }
            }

            resultat = resultat + "\n *****************************************     *****************************************\n";

            return resultat;
        }

        public bool IsHit(char [] validCoordinates)
        {
            int j = Convert.ToInt32(validCoordinates[0]) - 1;
            int i = Convert.ToInt32(validCoordinates[1]) - 1;

            if (Gameboard2[j, i] == 'B')
            {
                Gameboard2[j, i] = 'X';
                return true;

            }
            else if (Gameboard2[j, i] == ' ')
            {
                Gameboard2[j, i] = 'O';
                return true;
            }

            return false;

			return resultat;
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
