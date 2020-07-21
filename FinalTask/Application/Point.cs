using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Application
{
    class Point
    {
        private int _x;
        private int _y;
        private char symbol = '*';

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        internal void DrawPoint() 
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(symbol);
        }
    }
}
