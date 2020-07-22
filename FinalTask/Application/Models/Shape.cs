using Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    class Shape
    {
        public  List<Point> _block;
        private int x = PlayFieldConst.BorderXPos;
        private int y = PlayFieldConst.BorderYPos + 2;
        private char ch = 'M';
        int angle = 90;
        public Shape()
        {
            CreateShapeT();
            DrawShape(_block);

            TimeSpan timeSpan = new TimeSpan();

            
            
            RotateShape(angle);
            DrawShape(_block);

            RotateShape(angle);
            DrawShape(_block);
        }

        public int CreateShapeT()
        {
            List<Point> block = new List<Point>
            {
                new Point(x, y, ch),
                new Point(x, y + 1, ch),
                new Point(x + 1, y + 1, ch),
                new Point(x, y + 2, ch)
            };

            _block = block;

            return (int)TetrominoNames.T;
        }

        public void DrawShape(List<Point> shape)
        {
            foreach (Point p in shape)
            {
                if (p.X < 0 || p.Y < 0)
                {
                    break;
                }
            }
        }

        public void RotateShape(int angle)
        {
            List<Point> newBlock = new List<Point> { };

            for (int i = 0; i < _block.Count; i++)
            {
                
                int newX = _block[i].X * Convert.ToInt32(Math.Cos(angle)) - _block[i].Y * Convert.ToInt32(Math.Sin(angle));
                int newY = _block[i].X * Convert.ToInt32(Math.Sin(angle)) + _block[i].Y * Convert.ToInt32(Math.Cos(angle));

                newBlock.Add(new Point(newX, newY, _block[i].Char));
            }

            for (int i = 0; i < _block.Count; i++)
            {
                _block[i].Clear();
            }

            _block = newBlock;
        }        
    }
}

