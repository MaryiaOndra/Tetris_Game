using Application.Enums;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
   class Point : IMovements, IDrawClear
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

        public void ChangeChar(char ch) 
        {
            Char = ch;
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(PointConst.EmptySpace);
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Char);
        }

        public void MoveRight() 
        {
            X++;
        }   
        
        public void MoveLeft() 
        {
            X--;
        }

        public void RotatePoint(Point centerPoint, Point pointToRotate) 
        {
            double angleInRadians = Angle * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);

            var newX = (cosTheta * (pointToRotate.X - centerPoint.X) + sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X);
            var newY = (cosTheta * (pointToRotate.Y - centerPoint.Y) - sinTheta * (pointToRotate.X - centerPoint.X) + centerPoint.Y);
            X = (int)newX;
            Y = (int)newY;
        }

        public void MoveDown()
        {
            Y++;
        }

        internal void IncreaseXY(int stepsX, int stepsY) 
        {
            Y += stepsY;
            X += stepsX;        
        }
    }
}
