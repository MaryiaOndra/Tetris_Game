using Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
   class Point
   {
        const int Angle = 90;

        public int X { get; private set; }
        public int Y { get; private set; }
        public char Char { get; private set; }

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
        }   
        
        internal void MoveLeft() 
        {
            Clear();
            X--;
        }

        internal void RotatePoint(Point centerPoint, Point pointToRotate) 
        {
            Clear();

            double angleInRadians = Angle * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);

            var newX = (cosTheta * (pointToRotate.X - centerPoint.X) + sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X);
            var newY = (cosTheta * (pointToRotate.Y - centerPoint.Y) - sinTheta * (pointToRotate.X - centerPoint.X) + centerPoint.Y);
            X = (int)newX;
            Y = (int)newY;
        }

        internal void DropDown()
        {
            Clear();
            Y++;
        }
    }
}
