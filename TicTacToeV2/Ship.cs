using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2
{
    class Ship
    {
        private string m_name;
        private int m_size;
        public string Name
        {
            get
            {
                return m_name;
            }
        }
        public int Size
        {
            get
            {
                return m_size;
            }
        }
        public Ship(int size, string name)
        {
            m_size = size;
            m_name = name;
        }
        
    }
}
