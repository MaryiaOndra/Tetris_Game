using Application.Enums;
using Application.Interfaces;
using System;
using System.Collections.Generic;

namespace Application.Models.Shapes
{
    sealed class Block : IMovements, IDrawClear
    {
        private readonly int x = BlockConst.StartX;
        private int y = BlockConst.StartY;
        private char ch = 'A';

        internal List<Point> newBlock { get; private set; }

        public void MoveRight()
        {
            for (int i = 0; i < newBlock.Count; i++)
            {
                newBlock[i].Clear();
                newBlock[i].MoveRight();
            }
        }

        public void MoveLeft()
        {
            for (int i = 0; i < newBlock.Count; i++)
            {
                newBlock[i].Clear();
                newBlock[i].MoveLeft();
            }
        }

        public void MoveDown()
        {
            for (int i = newBlock.Count - 1; i >= 0; i--)
            {
                newBlock[i].Clear();
                newBlock[i].MoveDown();
            }
        }

        public void RotateBlock()
        {
            for (int i = 0; i < newBlock.Count; i++)
            {
                newBlock[i].Clear();
                newBlock[i].RotatePoint(newBlock[1], newBlock[i]);
            }
        }

        public void Draw()
        {
            for (int i = 0; i < newBlock.Count; i++)
            {
                newBlock[i].Draw();
            }
        }

        public void Clear()
        {
            for (int i = 0; i < newBlock.Count; i++)
            {
                newBlock[i].Clear();
            }
        }

        internal void RelocateBlock()
        {
            int stepsY = 7;
            int stepsX = 25;

            for (int i = 0; i < newBlock.Count; i++)
            {
                newBlock[i].IncreaseXY(stepsX, stepsY);
            }
        }

        internal void CreateBlock(int numOfBlock, int numOfChar)
        {
            ch = Convert.ToChar(numOfChar);

            switch (numOfBlock)
            {
                case (int)TetrominoNames.T:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x + 1, y + 1, ch),
                        new Point(x, y + 2, ch)
                    };
                    break;

                case (int)TetrominoNames.J:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x, y + 2, ch),
                        new Point(x - 1, y + 2, ch)
                    };
                    break;

                case (int)TetrominoNames.O:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x + 1, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x + 1, y + 1, ch)
                    };
                    break;

                case (int)TetrominoNames.I:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x, y + 2, ch),
                        new Point(x, y + 3, ch)
                    };
                    break;

                case (int)TetrominoNames.L:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x, y + 2, ch),
                        new Point(x + 1, y + 2, ch)
                    };
                    break;

                case (int)TetrominoNames.S:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch),
                        new Point(x + 1, y, ch),
                        new Point(x, y + 1, ch),
                        new Point(x - 1, y + 1, ch)
                    };
                    break;

                case (int)TetrominoNames.Z:
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
