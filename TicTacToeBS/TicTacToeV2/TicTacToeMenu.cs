using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2
{
    class TicTacToeMenu
    {
        TicTacToe game;
        private string gameMode;
        public void ShowGameModeMenu()
        {
            Console.WriteLine("Choose game mode:");
            Console.WriteLine("1. Standard Mode");
            Console.WriteLine("2. Variation Mode");
        }

        public bool PlaceAPiece(string input)
        {
            return game.PlacePiece(input);
        }

        public bool ChooseGameMode(string choice)
        {
            if(choice == "1")
            {
                CreateStandardGame();
            }
            else if (choice == "2")
            {
                CreateVariationGame();
            }
            else
            {
                Console.WriteLine("Wrong input!");
                return false;
            }
            return true;
        }

        public void ShowGameOptions()
        {
            if(gameMode == "Standard")
            {
                Console.WriteLine("Choose play:");
                Console.WriteLine("1. Place a Piece");
                Console.WriteLine("0. Quit");
            }
            else if (gameMode == "Variation")
            {
                Console.WriteLine("Choose play:");
                Console.WriteLine("1. Place a Piece");
                Console.WriteLine("2. Move a Piece");
                Console.WriteLine("0. Quit");
            }
        }

        public string ChooseOption(string choice)
        {
            if (choice == "1")
            {
                return "1";
            }
            else if (choice == "2")
            {
                return "2";
            }
            else if (choice == "0")
            {
                return "0";
            }
            else
            {
                Console.WriteLine("Wrong input!");
                return "Error";
            }
        }

        public void ShowGameBoard()
        {
            Console.Clear();
            Console.WriteLine(game.GetGameBoardView());
        }

        private void CreateStandardGame()
        {
            gameMode = "Standard";
            game = new TicTacToe();
        }
        private void CreateVariationGame()
        {
            gameMode = "Variation";
            game = new TicTacToe();
        }
    }
}
