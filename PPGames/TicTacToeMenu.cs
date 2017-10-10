using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGames
{
	public class TicTacToeMenu : GameMenu
	{
		// Start variabler
		private TicTacToe game;
		private MenuOptions currentMenu;

		// Constructor
		public TicTacToeMenu()
		{
			currentMenu = MenuOptions.ChooseGameMode;
		}

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
			Console.WriteLine("Player " + game.CurrentPlayer + " it is your turn.");
			if(game.PlayerMoves > 0)
			{
				Console.WriteLine("Write coordinate x,y or 0 to quit gamemode.");
			}
			else
			{
				if(game.IsPiecePicked != true)
				{
					Console.WriteLine("Pick piece x,y or 0 to quit gamemode");
				}
				else
				{
					Console.WriteLine("Move piece to x,y or 0 to quit gamemode");
				}
			}
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
			
			// Hvis menuen er vores valgte gamemode, så skal vi bare indtaste coordinater.
			if(IsCoordinateValid(input))
			{
				//Hvis IsCoordinateValid == true, så er vi sikre på der kun er x og y i arrayet.
				string[] coordinates = input.Split(',');
				bool winnerFound = false;

				if(game.PlayerMoves > 0) // Hvis vi har moves tilbage, så skal vi bare indtaste coordinater.
				{
					winnerFound = game.PlacePiece(coordinates);
					if(winnerFound != true && game.CheckForDraw())
					{
						ShowDraw();
					}
				}
				else // Hvis ikke der er flere pladser tilbage, så min vi samle et brik op.
				{
					if(game.IsPiecePicked != true) // Hvis ikke vi har samlet en brik op, så saml den op
					{
						game.PickPiece(coordinates); // Set enten true eller false, hvis vi kunne samle brikken op
					}
					else
					{
						winnerFound = game.MovePiece(coordinates); // Check om der var en vinder, da vi smidt brikken ned.
					}
				}

				if(winnerFound)
				{
					ShowWinner(); // Hvis man har vundet, så vis det på skærmen.
					return true;
				}
			}

			return false;
		}


		// ---------- Uncategorized methods --------------

		private void CreateGame(GameMode mode)
		{
			game = new TicTacToe(mode);
			currentMenu = MenuOptions.HandleGameActions;
		}

		private void ShowDraw()
		{
			Console.Clear();
			ShowGameBoard();
			Console.WriteLine("Draw! Better luck next time!");
			PressKeyToContinue();

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
