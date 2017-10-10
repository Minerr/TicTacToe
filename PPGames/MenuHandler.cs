using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGames
{
	public class MenuHandler
    {
		// Start variabler
		private TicTacToeMenu ticTacToeMenu;
		private BattleShipsMenu battleShipsMenu;
		private bool isGameRunning;
		private bool isGameChosen;
		private bool isBattleShipsChosen;

		public MenuHandler()	// Vores Constructor, som sørger for at initialisere vores start variabler
		{
			isGameRunning = false;
			isGameChosen = false;
			isBattleShipsChosen = false;

			battleShipsMenu = new BattleShipsMenu();
			ticTacToeMenu = new TicTacToeMenu();
		}

		public void RunGame() // Vores Game loop
		{
			isGameRunning = true;
			do
			{
				ShowMenu(); // Varierer baseret på "currentMenu" variablen
				HandleInput(Console.ReadLine()); //Hent input fra consolen og udfør action.

			} while (isGameRunning);
		}

		// -------- Start of Handle input methods ----------

		private void HandleInput(string input)
		{
			bool quitToMainMenu = false;
			if(isGameChosen != true)
			{
				ChooseGame(input);
			}
			else
			{
				if(isBattleShipsChosen)
				{
					quitToMainMenu = battleShipsMenu.HandleInput(input);
				}
				else
				{
					quitToMainMenu = ticTacToeMenu.HandleInput(input);
				}
			}

			if(quitToMainMenu)	// if we should quit to main menu, that chooses which game to play, then just set isGameChosen to false.
			{
				isGameChosen = false;
			}
		}

		private void ChooseGame(string input)
		{
			// Hvis vores menu er "vælg game", så check følgende input:
			if(input == "1")
			{
				// Use Tic Tac Toe menu
				isGameChosen = true;
				isBattleShipsChosen = false;
			}
			else if(input == "2")
			{
				// Use Battleships menu
				isGameChosen = true;
				isBattleShipsChosen = true;
			}
			else if(input == "0")
			{
				isGameRunning = false;
			}
		}
		

		// -------- End of Handle input methods ----------
		// -------- Start of show menu methods ----------

		public void ShowMenu()
        {
			Console.Clear();

			if(isGameChosen != true)
			{
				Console.WriteLine("Choose game:");
				Console.WriteLine("1. Tic Tac Toe");
				Console.WriteLine("2. Battle Ships");
				Console.WriteLine("0. Quit game");
			}
			else
			{
				if(isBattleShipsChosen)
				{
					battleShipsMenu.DisplayCurrentMenu();
				}
				else
				{
					ticTacToeMenu.DisplayCurrentMenu();
				}
			}
		}

	}

}
