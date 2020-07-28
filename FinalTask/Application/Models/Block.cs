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

        internal void CreateBlock(int numOfBlock, int numOfChar)
        {
            ChooseRandomChar(numOfChar);

            switch (numOfBlock)
            {
                case (int)TetrominoNames.O:
                    ChooseFormOfBlock(TetrominoNames.O);
                    break;

                case (int)TetrominoNames.I:
                    ChooseFormOfBlock(TetrominoNames.I);
                    break;

                case (int)TetrominoNames.J:
                    ChooseFormOfBlock(TetrominoNames.J);
                    break;

                case (int)TetrominoNames.T:
                    ChooseFormOfBlock(TetrominoNames.T);
                    break;

                case (int)TetrominoNames.L:
                    ChooseFormOfBlock(TetrominoNames.L);
                    break;

                case (int)TetrominoNames.S:
                    ChooseFormOfBlock(TetrominoNames.S);
                    break;

                case (int)TetrominoNames.Z:
                    ChooseFormOfBlock(TetrominoNames.Z);
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

        internal void ShowNextBlock(int numOfNextBlock, int numNextChar) 
        {
            CreateBlock(numOfNextBlock, numNextChar);

            foreach (Point p in newBlock)
            {
                p.DrawPoint();
            }

            //TODO:
            //set cursor position?
            //add numOfBlock == nextNumOfBlock to the end of loop, before creating new block
        }

        void ChooseRandomChar(int numOfChar)
        {
            ch = Convert.ToChar(numOfChar);
        }

        internal void DropBlock()
        {
            for (int i = newBlock.Count - 1; i >= 0; i--)
            {
                newBlock[i].DropDown();
            }
        }

        internal void RotateBlock()
        {
            for (int i = 0; i < newBlock.Count; i++)
            {
                newBlock[i].RotatePoint(newBlock[1], newBlock[i]);
            }
        }

        private void ChooseFormOfBlock(TetrominoNames name)
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
