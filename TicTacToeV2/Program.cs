using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2
{
    class Program
    {
		GameMenu menu;

		static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

		private void Run()
		{
			menu = new GameMenu();
			menu.RunGame();
		}
	}
}