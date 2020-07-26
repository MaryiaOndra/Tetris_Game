using Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Shapes
{
    sealed class Block
    {
        private int x = BlockConst.StartX;
        private int y = BlockConst.StartY;
        private char ch = 'A';

        internal List<Point> MyBlock { get; private set; }

        public Block()
        {
            ChooseRandomChar();
            CreateBlock();
        }

        internal void CreateBlock()
        {            
            Random r = new Random();
            
            int numShape = r.Next(0, 6);

            switch (numShape)
            {
                case (int)TetrominoNames.O:
                    ChooseBlock(TetrominoNames.O);
                    break;

                case (int)TetrominoNames.I:
                    ChooseBlock(TetrominoNames.I);
                    break;

                case (int)TetrominoNames.J:
                    ChooseBlock(TetrominoNames.J);
                    break;

                case (int)TetrominoNames.T:
                    ChooseBlock(TetrominoNames.T);
                    break;

                case (int)TetrominoNames.L:
                    ChooseBlock(TetrominoNames.L);
                    break;

                case (int)TetrominoNames.S:
                    ChooseBlock(TetrominoNames.S);
                    break;

                case (int)TetrominoNames.Z:
                    ChooseBlock(TetrominoNames.Z);
                    break;
            }
        }

        internal void DrawBlock() 
        {
            for (int i = 0; i < MyBlock.Count; i++)
            {
                MyBlock[i].DrawPoint();
            }
        }

        void ChooseRandomChar()
        {
            Random random = new Random();
            ch = Convert.ToChar(random.Next(0, BlockConst.RangeChar) + BlockConst.StartChar);
        }

        internal void RotateBlock(int angle)
        {
            List<Point> newTetromino = new List<Point> { };

            for (int i = 0; i < MyBlock.Count; i++)
            {
                int newX = MyBlock[i].X * Convert.ToInt32(Math.Cos(angle)) - MyBlock[i].Y * Convert.ToInt32(Math.Sin(angle));
                int newY = MyBlock[i].X * Convert.ToInt32(Math.Sin(angle)) + MyBlock[i].Y * Convert.ToInt32(Math.Cos(angle));

                newTetromino.Add(new Point(newX, newY, MyBlock[i].Char));
            }
        }
        
        private void ChooseBlock(TetrominoNames name)
        {
            switch (name)
            {
                case TetrominoNames.T:
                    MyBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x + 1, y + 1, ch),
                        new Point(x, y + 2, ch)
                    };
                    break;

                case TetrominoNames.J:
                    MyBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x, y + 2, ch),
                        new Point(x - 1, y + 2, ch)
                    };
                    break;

                case TetrominoNames.O:
                    MyBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x + 1, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x + 1, y + 1, ch)
                    };
                    break;

                case TetrominoNames.I:
                    MyBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x, y + 2, ch),
                        new Point(x, y + 3, ch)
                    };
                    break;

                case TetrominoNames.L:
                    MyBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x, y + 2, ch),
                        new Point(x + 1, y + 2, ch)
                    };
                    break;

                case TetrominoNames.S:
                    MyBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x + 1, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x - 1, y + 1, ch)
                    };
                    break;

                case TetrominoNames.Z:
                    MyBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x - 1, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x + 1, y + 1, ch)
                    };
                    break;

                default:
                    break;
            }
        }
        
    }
}
