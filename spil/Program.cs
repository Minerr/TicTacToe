using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spil
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        private void Run()
        {
            TicTacToeMenu ticTacToeMenu = new TicTacToeMenu();
            ticTacToeMenu.Show();
        }
    }
}
