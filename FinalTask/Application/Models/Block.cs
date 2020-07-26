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

        internal List<Point> newBlock { get; private set; }

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
            for (int i = 0; i < newBlock.Count; i++)
            {
                newBlock[i].DrawPoint();
            }
        }

        void ChooseRandomChar()
        {
            Random random = new Random();
            ch = Convert.ToChar(random.Next(0, BlockConst.RangeChar) + BlockConst.StartChar);
        }

        internal void GoDown()
        {
            for (int i = newBlock.Count - 1; i >= 0; i--)
            {
                newBlock[i].DropDown();
            }
        }

        internal void RotateBlock(int angle)
        {
            List<Point> newTetromino = new List<Point> { };

            for (int i = 0; i < newBlock.Count; i++)
            {
                int newX = newBlock[i].X * Convert.ToInt32(Math.Cos(angle)) - newBlock[i].Y * Convert.ToInt32(Math.Sin(angle));
                int newY = newBlock[i].X * Convert.ToInt32(Math.Sin(angle)) + newBlock[i].Y * Convert.ToInt32(Math.Cos(angle));

                newTetromino.Add(new Point(newX, newY, newBlock[i].Char));
            }
        }

        private void ChooseBlock(TetrominoNames name)
        {
            switch (name)
            {
                case TetrominoNames.T:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x + 1, y + 1, ch),
                        new Point(x, y + 2, ch)
                    };
                    break;

                case TetrominoNames.J:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x, y + 2, ch),
                        new Point(x - 1, y + 2, ch)
                    };
                    break;

                case TetrominoNames.O:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x + 1, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x + 1, y + 1, ch)
                    };
                    break;

                case TetrominoNames.I:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x, y + 2, ch),
                        new Point(x, y + 3, ch)
                    };
                    break;

                case TetrominoNames.L:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x, y + 2, ch),
                        new Point(x + 1, y + 2, ch)
                    };
                    break;

                case TetrominoNames.S:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x + 1, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x - 1, y + 1, ch)
                    };
                    break;

                case TetrominoNames.Z:
                    newBlock = new List<Point>
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
