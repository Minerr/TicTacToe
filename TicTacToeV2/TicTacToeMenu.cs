using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2
{
    class GameMenu
    {
		// Start variabler
		private TicTacToe gameTTT;
        private BattleShips gameBS;
		private bool isGameRunning;
		private MenuOptions currentMenu;

		public GameMenu()	// Vores Constructor, som sørger for at initialisere vores start variabler
		{
			isGameRunning = false;
			currentMenu = MenuOptions.ChooseGame;
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
			switch(currentMenu)
			{
				case MenuOptions.ChooseGame:
					ChooseGame(input);
					break;
				case MenuOptions.ChooseTTTGameMode:
					ChooseTTTGameMode(input);
					break;
				case MenuOptions.HandleTTTGameMode:
					HandleTTTGameMode(input);
					break;
				case MenuOptions.ChooseBSGameMode:
					ChooseBSGameMode(input);
					break;
				case MenuOptions.HandleBSGameMode:
					HandleBSGameMode(input);
					break;
			}
		}
		private void ChooseGame(string input)
		{
			// Hvis vores menu er "vælg gamemode", så check følgende input:
			if(input == "1")
			{
				// Tic Tac Toe game menu
				currentMenu = MenuOptions.ChooseTTTGameMode;
			}
			else if(input == "2")
			{
				// Create battleships game
				currentMenu = MenuOptions.ChooseBSGameMode;
			}
			else if(input == "0")
			{
				isGameRunning = false;
			}
		}
		private void ChooseBSGameMode(string input)
		{
			if(input == "1")
			{
				CreateBattleShipGame(GameMode.Standard);
			}
			else if(input == "2")
			{
				CreateBattleShipGame(GameMode.Variation);
			}
			else if(input == "0")
			{
				isGameRunning = false;
			}
		}
		private void HandleBSGameMode(string input)
		{
			//
		}
		private void ChooseTTTGameMode(string input)
		{
			// Hvis vores menu er "vælg gamemode", så check følgende input:
			if(input == "1")
			{
				CreateTTTGame(GameMode.Standard);
			}
			else if(input == "2")
			{
				CreateTTTGame(GameMode.Variation);
			}
			else if(input == "0")
			{
				isGameRunning = false;
			}
		}
		private void HandleTTTGameMode(string input)
		{
			// Hvis vores input er 0, så skal vi returnere til Hoved menuen.
			if(input == "0")
			{
				currentMenu = MenuOptions.QuitToMainMenu;
			}
			// Hvis menuen er vores valgte gamemode, så skal vi bare indtaste coordinater.
			else if(IsCoordinateValid(input))
			{
				//Hvis IsCoordinateValid == true, så er vi sikre på der kun er x og y i arrayet.
				string[] coordinates = input.Split(',');
				bool winnerFound = false;

				if(gameTTT.PlayerMoves > 0) // Hvis vi har moves tilbage, så skal vi bare indtaste coordinater.
				{
					winnerFound = gameTTT.PlacePiece(coordinates);
					if(winnerFound != true && gameTTT.CheckForDraw())
					{
						ShowDraw();
						PressKeyToContinue();
					}
				}
				else // Hvis ikke der er flere pladser tilbage, så min vi samle et brik op.
				{
					if(gameTTT.IsPiecePicked != true) // Hvis ikke vi har samlet en brik op, så saml den op
					{
						gameTTT.PickPiece(coordinates); // Set enten true eller false, hvis vi kunne samle brikken op
					}
					else
					{
						winnerFound = gameTTT.MovePiece(coordinates); // Check om der var en vinder, da vi smidt brikken ned.
					}
				}

				if(winnerFound)
				{
					ShowWinner(); // Hvis man har vundet, så vis det på skærmen.
					PressKeyToContinue();
				}
			}
		}

		// -------- End of Handle input methods ----------
		// -------- Start of show menu methods ----------

		public void ShowMenu()
        {
			Console.Clear();

			if(currentMenu == MenuOptions.QuitGame) //Hvis vi skal quit game, så gå ud af game loopet
			{
				isGameRunning = false;
				return;
			}
			else if(currentMenu == MenuOptions.QuitToMainMenu)  //Hvis vi bare skal se "vælg gamemode", så set currentMenu til ChooseGameMode
			{
				currentMenu = MenuOptions.ChooseTTTGameMode;
			}

			switch(currentMenu)
			{
				case MenuOptions.ChooseGame:
					ShowGameMenu();
					break;
				case MenuOptions.ChooseTTTGameMode:
					ShowTTTGameModeMenu();
					break;
				case MenuOptions.HandleTTTGameMode:
					ShowTTTMenu();
					break;
				case MenuOptions.ChooseBSGameMode:
					ShowBSGameModeMenu();
					break;
				case MenuOptions.HandleBSGameMode:
					ShowBSMenu();
					break;
			}
		}
		private void ShowGameMenu()
		{
			Console.WriteLine("Choose game:");
			Console.WriteLine("1. Tic Tac Toe");
			Console.WriteLine("2. Battle Ships");
			Console.WriteLine("0. Quit game");
		}
		private void ShowTTTGameModeMenu()
		{
			Console.WriteLine("Choose game mode:");
			Console.WriteLine("1. Standard Mode");
			Console.WriteLine("2. Variation Mode");
			Console.WriteLine("0. Quit game");
		}
		private void ShowTTTMenu()
		{
			ShowGameBoard();
			Console.WriteLine("Player " + gameTTT.CurrentPlayer + " it is your turn.");
			if(gameTTT.PlayerMoves > 0)
			{
				Console.WriteLine("Write coordinate x,y or 0 to quit gamemode.");
			}
			else
			{
				if(gameTTT.IsPiecePicked != true)
				{
					Console.WriteLine("Pick piece x,y or 0 to quit gamemode");
				}
				else
				{
					Console.WriteLine("Move piece to x,y or 0 to quit gamemode");
				}
			}
		}
		private void ShowBSGameModeMenu()
		{
			Console.WriteLine("Choose game mode:");
			Console.WriteLine("1. Standard Mode");
			Console.WriteLine("2. Variation Mode");
			Console.WriteLine("0. Quit game");
		}
		private void ShowBSMenu()
		{
            Console.WriteLine(gameBS.GetCurrentPlayer());
            Console.Write(gameBS.GetGameBoardView());
            Console.WriteLine("1.Place  : (X,Y, horizontal (H) or Vertical (V)");
            Console.WriteLine("0. Exit");
            
                
        
		}

		public void ShowGameBoard()
        {
            Console.WriteLine(gameTTT.GetGameBoardView());
        }

		// -------- End of show menu methods ----------
		// -------- Start of Other/Uncategorised ----------

		private void CreateTTTGame(GameMode mode)
        {
            gameTTT = new TicTacToe(mode);
			currentMenu = MenuOptions.HandleTTTGameMode;
		}
		private void CreateBattleShipGame(GameMode mode)
		{
			gameBS = new BattleShips(mode);
			currentMenu = MenuOptions.HandleBSGameMode;
		}

		private bool IsCoordinateValid(string input)
		{
			string[] inputs = input.Split(',');

			if (inputs.Length == 2)
			{
				string inputX = inputs[0];
				string inputY = inputs[1];

				if (inputX.Length == 1 && (inputX == "1" || inputX == "2" || inputX == "3") &&
					(inputY.Length == 1 && (inputY == "1" || inputY == "2" || inputY == "3")))
				{
					return true;
				}
			}

			return false;
		}


		private void ShowDraw()
		{
			ShowMenu();
			Console.WriteLine("Draw! Better luck next time!");
			
		}
		private void ShowWinner()
		{
			ShowMenu();
			Console.WriteLine("Winner winner chicken dinner! Player " + gameTTT.CurrentPlayer);
		}

		private void PressKeyToContinue()
		{
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
			currentMenu = MenuOptions.ChooseTTTGameMode;
		}

	}

}
