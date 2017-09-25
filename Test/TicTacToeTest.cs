using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spil;

namespace Test
{
    [TestClass]
    public class TicTacToeTest
    {
        [TestMethod]
        public void NeitherPlayerHasThreeInARow()
        {
            TicTacToe ticTacToe = new TicTacToe();
            const char expectet = ' ';
            char actual = ticTacToe.Validate();
            Assert.AreEqual(expectet, actual); 
        }
    }
}
