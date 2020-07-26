using Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
   class Point
   {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Char { get; private set; }

        public static Point NewPoint { get; private set; }

        public Point(int x, int y, char ch)
        {
            X = x;
            Y = y;
            Char = ch;
        }

        internal void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(PointConst.EmptySpace);
        }

        internal void DrawPoint()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Char);
        }

        internal void MoveRight() 
        {
            Clear();
            X++;
            DrawPoint();
        }   
        
        internal void MoveLeft() 
        {
            Clear();
            X--;
            DrawPoint();
        }

        internal void DropDown()
        {
            Clear();
            Y++;
            DrawPoint();
        }
    }
}
