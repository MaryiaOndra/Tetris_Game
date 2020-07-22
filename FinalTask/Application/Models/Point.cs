using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
   struct Point
   {
        public int X { get; set; }
        public int Y { get; set; }
        public char Char { get; set; }

        public Point(int x, int y, char ch)
        {
            X = x;
            Y = y;
            Char = ch;

        }

        public void Draw()
        {
            DrawPoint(Char);
        }
        public void Clear()
        {
            DrawPoint(' ');
        }
        private void DrawPoint(char ch)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(ch);
        }
   }
}
