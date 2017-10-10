using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGames
{
    class Program
    {
		MenuHandler menu;

		static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

		private void Run()
		{
			menu = new MenuHandler();
			menu.RunGame();
		}
	}
}