using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.RunGameLoop();
        }

        private void RunGameLoop()
        {
            TicTacToeMenu menu = new TicTacToeMenu();
            bool isGameRunning = true;
            do
            {
                // Choose game mode loop
                menu.ShowGameModeMenu();
                bool isValidInput = false;
                do
                {
                    string userInput = Console.ReadLine();
                    isValidInput = menu.ChooseGameMode(userInput);
                } while (isValidInput == false);


                // ----------------------------------

                // Show game options loop
                bool running = true;
                do
                {
                    menu.ShowGameBoard();
                    menu.ShowGameOptions();

                    // Choose option loop
                    string optionChoice = "Error";
                    do
                    {
                        string userInput = Console.ReadLine();
                        optionChoice = menu.ChooseOption(userInput);
                    } while (optionChoice == "Error");

                    // React to input
                    if (optionChoice == "1")
                    {
                        bool shouldQuit = false;
                        do
                        {
                            Console.WriteLine("Write koordinat x,y");

                            string userInput = Console.ReadLine();

                            if (userInput == "0")
                            {
                                running = false;
                                shouldQuit = true;
                            }
                            else
                            {
                                shouldQuit = menu.PlaceAPiece(userInput);
                                menu.ShowGameBoard();
                            }

                        } while (shouldQuit != true);


                        running = false;
                    }
                    else if (optionChoice == "0")
                    {
                        running = false;
                    }

                } while (running);

            } while (isGameRunning);

            
        }

    }
}