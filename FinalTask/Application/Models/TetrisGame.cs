using Application.Enums;
using Application.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace Application.Models
{
    sealed class TetrisGame
    {
        private Block myBlock;
        private PlayField playField;
        private Random random = new Random();
        private static int numOfBlock;
        private static int nextNumOfBlock;
        private static int numOfChar = BlockConst.StartNumChar;
        private static int nextNumOfChar;
        private int time = 50;
        private List<Point> bulkOfUsedPoints = new List<Point>();
        private static int Score;

        public void Start()
        {
            playField = new PlayField();
            playField.CreateListOfFieldPoints();

            Score = 0;

            while (true)
            {
                myBlock = new Block();
                myBlock.CreateBlock(numOfBlock, numOfChar);
                myBlock.DrawBlock();

                nextNumOfBlock = random.Next(6);
                nextNumOfChar = random.Next(BlockConst.RangeChar) + BlockConst.StartNumChar;

                if (IsOver())
                {                    
                    break;
                }

                while (!IsHitBottomOrBlock())
                {
                    if (Console.KeyAvailable)
                    {
                        HandleKey(Console.ReadKey(true).Key);
                    }
                    else
                    {
                        HandleKey(default);
                    }
                }

                if (IsFullLines())
                {

                }

                for (int i = 0; i < myBlock.newBlock.Count; i++)
                {
                    bulkOfUsedPoints.Add(myBlock.newBlock[i]);
                }

                numOfBlock = nextNumOfBlock;
                numOfChar = nextNumOfChar;
            }

            ShowGameOver();
        }

        public void HandleKey(ConsoleKey consoleKey)
        {
            Thread.Sleep(time);

            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                    myBlock.RotateBlock();
                    break;

                case ConsoleKey.LeftArrow:
                    if (!IsHitFieldSides())
                    {
                        for (int i = 0; i < myBlock.newBlock.Capacity; i++)
                        {
                            myBlock.newBlock[i].MoveLeft();
                        }
                    }
                    else
                        myBlock.DropBlock();
                    break;

                case ConsoleKey.RightArrow:
                    if (!IsHitFieldSides())
                    {
                        for (int i = 0; i < myBlock.newBlock.Count; i++)
                        {
                            myBlock.newBlock[i].MoveRight();
                        }
                    }
                    else
                        myBlock.DropBlock();
                    break;

                case ConsoleKey.DownArrow:

                    while (!IsHitBottomOrBlock())
                    {
                        Thread.Sleep(time / 10);
                        myBlock.DropBlock();
                    }
                    break;

                default:
                    Thread.Sleep(time);
                    myBlock.DropBlock();
                    break;
            }

            myBlock.DrawBlock();
        }

        private static void ShowGameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string text = "GAME OVER";
            Console.SetCursorPosition(GameWindowConst.WindowWidth / 2 - text.Length / 2, PlayFieldConst.FieldHeight / 2);
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        #region BlockValidation

        private bool IsHitBottomOrBlock()
        {
            bool answer = false;

            for (int i = 0; i < myBlock.newBlock.Count; i++)
            {
                for (int j = 0; j < bulkOfUsedPoints.Count; j++)
                {
                    if (myBlock.newBlock[i].Y.Equals(bulkOfUsedPoints[j].Y - 1)
                        && myBlock.newBlock[i].X.Equals(bulkOfUsedPoints[j].X))
                    {
                        answer = true;
                        break;
                    }
                }

                if (myBlock.newBlock[i].Y.Equals(playField.BottomSide[0].Y - 1))
                {
                    answer = true;
                    break;
                }
            }

            return answer;
        }

        private bool IsHitFieldSides()
        {
            bool answer = false;

            for (int i = 0; i < myBlock.newBlock.Count; i++)
            {
                if (myBlock.newBlock[i].X.Equals(playField.RightSide[0].X - 1)
                    || myBlock.newBlock[i].X.Equals(playField.LeftSide[0].X + 1))
                {
                    answer = true;
                }
            }

            return answer;
        }
        private bool IsOver()
        {
            bool answer = false;

            for (int i = 0; i < bulkOfUsedPoints.Count; i++)
            {
                if (bulkOfUsedPoints[i].Y.Equals(BlockConst.StartY))
                {
                    answer = true;
                }
            }

            return answer;
        }

        private bool IsFullLines() 
        {
            bool answer = false;

            


            return answer;
        }

        #endregion
    }
}

