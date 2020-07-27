using Application.Enums;
using Application.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Application.Models
{
    sealed class TetrisLogic
    {
        private Block myBlock;
        private PlayField playField;
        private Direction direction = default;
        private int angle = 90;

        Random random = new Random();
        private static int numOfBlock;
        private static int nextNumOfBlock;
        private static int numOfChar = BlockConst.StartNumChar;
        private static int nextNumOfChar;
        private static ConsoleKeyInfo key;
        private int time = 300;

        private List<Point> bulkOfUsedPoints = new List<Point>();

        public void GameLoop()
        {
            new Thread(() =>
            {
                while (true)
                {                     
                    key = Console.ReadKey();
                    GetDirection(key.Key);
                }

            }).Start();

            playField = new PlayField();

            while (!GameOver())
            {
                myBlock = new Block();
                myBlock.CreateBlock(numOfBlock, numOfChar);
                myBlock.DrawBlock();

                nextNumOfBlock = random.Next(6);
                nextNumOfChar = random.Next(BlockConst.RangeChar) + BlockConst.StartNumChar;

                while (!IsHitBottomOrBlock())
                {
                    Action();
                }

                for (int i = 0; i < myBlock.newBlock.Count; i++)
                {
                    bulkOfUsedPoints.Add(myBlock.newBlock[i]);
                }

                numOfBlock = nextNumOfBlock;
                numOfChar = nextNumOfChar;
            }
        }

        public void Action()
        {
            switch (direction)
            {
                case Direction.Up:

                    Thread.Sleep(time);

                    myBlock.RotateBlock(angle);
                    break;

                case Direction.Left:

                    Thread.Sleep(time);

                    if (!IsHitFieldSides())
                    {
                        for (int i = 0; i < myBlock.newBlock.Capacity; i++)
                        {
                            myBlock.newBlock[i].MoveLeft();
                        }

                        myBlock.DrawBlock();
                    }
                    else
                    {
                        myBlock.GoDown();
                    }
                    break;

                case Direction.Right:

                    Thread.Sleep(time);

                    if (!IsHitFieldSides())
                    {
                        for (int i = 0; i < myBlock.newBlock.Count; i++)
                        {
                            myBlock.newBlock[i].MoveRight();
                        }

                        myBlock.DrawBlock();
                    }
                    else
                    {
                        Thread.Sleep(time);

                        myBlock.GoDown();
                    }
                    break;

                case Direction.Down:

                    while (!IsHitBottomOrBlock())
                    {
                        Thread.Sleep(time / 10);
                        myBlock.GoDown();
                    }
                    break;

                default:
                    Thread.Sleep(time);
                    myBlock.GoDown();
                    break;
            }
        }

        public void GetDirection(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                //TODO Add Keys: Space(pause), Esc(cancel) 
                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;
                case ConsoleKey.UpArrow:
                    direction = Direction.Up;
                    break;
                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;
                case ConsoleKey.DownArrow:
                    direction = Direction.Down;
                    break;
                default:
                    break;
            }
        }

        private bool IsHitBottomOrBlock()
        {
            bool answer = false;

            for (int i = 0; i < myBlock.newBlock.Count; i++)
            {
                for (int j = 0; j < bulkOfUsedPoints.Count; j++)
                {
                    if (myBlock.newBlock[i].Y.Equals(bulkOfUsedPoints[j].Y - 1))
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

        private static bool GameOver()
        {
            return false;
        }
    }
}

