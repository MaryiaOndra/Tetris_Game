using Application.Enums;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

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

        private ConsoleColor ChangeBlockColor(int numOfBlock) 
        {
            ConsoleColor color = ConsoleColor.Red;

            switch (numOfBlock)
            {
                case (int)ConsoleColor.Blue:
                    color = ConsoleColor.Blue;
                    break;              
                
                case (int)ConsoleColor.Cyan:
                    color = ConsoleColor.Cyan;
                    break;   
                    
                case (int)ConsoleColor.Green:
                    color = ConsoleColor.Green;
                    break; 
                    
                case (int)ConsoleColor.Red:
                    color = ConsoleColor.Red;
                    break;  
                    
                case (int)ConsoleColor.Magenta:
                    color = ConsoleColor.Magenta;
                    break;  
                    
                case (int)ConsoleColor.Yellow:
                    color = ConsoleColor.Yellow;
                    break;    
                    
                case (int)ConsoleColor.White:
                    color = ConsoleColor.White;
                    break;
            }

            return color;
        }

        internal void CreateBlock(int numOfBlock, int numOfChar)
        {
            ch = Convert.ToChar(numOfChar);
            ConsoleColor color = ChangeBlockColor(numOfBlock);

            Console.ForegroundColor = color;

            switch (numOfBlock)
            {
                case (int)TetrominoNames.T:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch, color),
                        new Point(x, y + 1, ch, color),
                        new Point(x + 1, y + 1, ch, color),
                        new Point(x, y + 2, ch, color)
                    };
                    break;

                case (int)TetrominoNames.J:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch, color),
                        new Point(x, y + 1, ch, color),
                        new Point(x, y + 2, ch, color),
                        new Point(x - 1, y + 2, ch, color)
                    };
                    break;

                case (int)TetrominoNames.O:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch, color),
                        new Point(x + 1, y, ch, color),
                        new Point(x, y + 1, ch, color),
                        new Point(x + 1, y + 1, ch, color)
                    };
                    break;

                case (int)TetrominoNames.I:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch, color),
                        new Point(x, y + 1, ch, color),
                        new Point(x, y + 2, ch, color),
                        new Point(x, y + 3, ch, color)
                    };
                    break;

                case (int)TetrominoNames.L:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch, color),
                        new Point(x, y + 1, ch, color),
                        new Point(x, y + 2, ch, color),
                        new Point(x + 1, y + 2, ch, color)
                    };
                    break;

                case (int)TetrominoNames.S:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch, color),
                        new Point(x + 1, y, ch, color),
                        new Point(x, y + 1, ch, color),
                        new Point(x - 1, y + 1, ch, color)
                    };
                    break;

                case (int)TetrominoNames.Z:
                    newBlock = new List<Point>
                    {
                        new Point(x, y, ch, color),
                        new Point(x - 1, y, ch, color),
                        new Point(x, y + 1, ch, color),
                        new Point(x + 1, y + 1, ch, color)
                    };
                    break;

                default:
                    break;
            }
        }
    }
}
