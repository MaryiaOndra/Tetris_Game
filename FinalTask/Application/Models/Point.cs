using Application.Interfaces;
using System;

namespace Application.Models
{
    class Point : IMovements, IDrawClear
    {

        public int X { get; private set; }
        public int Y { get; private set; }
        public char Char { get; private set; } = '▓';
        public ConsoleColor Color { get; private set; } = ConsoleColor.Gray;

        public Point() { }

        public Point(int x, int y, char ch)
        {
            X = x;
            Y = y;
            Char = ch;
        }

        public Point(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(PointConst.EmptySpace);
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write(Char);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void MoveRight()
        {
            X++;
        }

        public void MoveLeft()
        {
            X--;
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

        public void RotatePoint(Point centerPoint, Point pointToRotate)
        {
            int angle = 90;

            double angleInRadians = angle * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);

            var newX = (cosTheta * (pointToRotate.X - centerPoint.X) + 
                sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X);

            var newY = (cosTheta * (pointToRotate.Y - centerPoint.Y) - 
                sinTheta * (pointToRotate.X - centerPoint.X) + centerPoint.Y);

            X = (int)newX;
            Y = (int)newY;
        }
    }
}
