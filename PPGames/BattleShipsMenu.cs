using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGames
{
	class BattleShipsMenu : GameMenu
	{

		private BattleShips game;
		private MenuOptions currentMenu;

		// Constructor
		public BattleShipsMenu()
		{
			currentMenu = MenuOptions.ChooseGameMode;
		}

		/// <summary>
		/// Displays the current menu, using the MenuOption enum.
		/// </summary>
		public void DisplayCurrentMenu()
		{
			switch(currentMenu)
			{
				case MenuOptions.ChooseGameMode:
					ShowGameModes();
					break;
				case MenuOptions.HandleGameActions:
					ShowGameActions();
					break;
			}
		}

		/// <summary>
		/// Uses a string input that contains the action based on the shown menu.
		/// <para> Returns true if the action was to quit to the main menu. </para>
		/// </summary>
		/// <param name="input">A string that contains the action based on the current menu</param>
		/// <returns>Returns true if the action was to quit to the main menu</returns>
		public bool HandleInput(string input)
		{
			bool quitToMainMenu = false;
			bool quitToChooseGameMode = false;

			switch(currentMenu)
			{
				case MenuOptions.ChooseGameMode:
					quitToMainMenu = ChooseGameMode(input);
					break;
				case MenuOptions.HandleGameActions:
					quitToChooseGameMode = HandleGameAction(input);
					break;
			}

			if(quitToChooseGameMode)
			{
				currentMenu = MenuOptions.ChooseGameMode;
			}

			return quitToMainMenu;
		}

		//------------- Show actions menu's ---------------

		private void ShowGameModes()
		{
			Console.WriteLine("Choose game mode:");
			Console.WriteLine("1. Standard Mode");
			Console.WriteLine("2. Variation Mode");
			Console.WriteLine("0. Quit to Main Menu");
		}

		private void ShowGameActions()
		{
			ShowGameBoard();
			Console.WriteLine("Player " + game.CurrentPlayer + ", it is your turn.");
			
			//TODO: Show actions for either placing ships or boats, depending on if all ships are placed.

		}

		//------------- Handle Input menu's ---------------

		private bool ChooseGameMode(string input)
		{
			// Hvis vores menu er "vælg gamemode", så check følgende input:
			if(input == "1")
			{
				CreateGame(GameMode.Standard);
			}
			else if(input == "2")
			{
				CreateGame(GameMode.Variation);
			}
			else if(input == "0")
			{
				return true;
			}

			return false;
		}

		private bool HandleGameAction(string input)
		{
			// Hvis vores input er 0, så skal vi returnere til Hoved menuen.
			if(input == "0")
			{
				return true;
			}
			
			//TODO: Code for place ship and place bomb goes here


			return false;
		}


		// ---------- Uncategorized methods --------------

		private void CreateGame(GameMode mode)
		{
			game = new BattleShips(mode);
			currentMenu = MenuOptions.HandleGameActions;
		}

		private void ShowWinner()
		{
			Console.Clear();
			ShowGameBoard();
			Console.WriteLine("Winner winner chicken dinner! Player " + game.CurrentPlayer + " won the game!");
			PressKeyToContinue();
		}

		private void PressKeyToContinue()
		{
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
		}

		private void ShowGameBoard()
		{
			Console.WriteLine(game.GetGameBoardView());
		}

		private bool IsCoordinateValid(string input)
		{
			string[] inputs = input.Split(',');

			if(inputs.Length == 2)
			{
				string inputX = inputs[0];
				string inputY = inputs[1];

				if(inputX.Length == 1 && (inputX == "1" || inputX == "2" || inputX == "3") &&
					(inputY.Length == 1 && (inputY == "1" || inputY == "2" || inputY == "3")))
				{
					return true;
				}
			}

			return false;
		}
	}
}
