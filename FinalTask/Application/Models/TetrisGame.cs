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
        private Block myBlock = new Block();
        private Block nextBlock = new Block();
        private PlayField playField;
        private List<Point> bulkOfUsedPoints = new List<Point>();

        private static int numOfBlock;
        private static int nextNumOfBlock;
        private static int numOfChar = BlockConst.StartNumChar;
        private static int nextNumOfChar;
        private static int difficulty = 0;
        private static int time = 300;
        private static int countOfPieses = 0;
        private static int score = 0;

        public void Start()
        {
            playField = new PlayField();
            playField.CreateListOfFieldPoints();
            ShowHelpInf();
            Thread.Sleep(700);

            while (true)
            {
                ShowGameInf();
                myBlock.CreateBlock(numOfBlock, numOfChar);
                myBlock.DrawBlock();

                Random random = new Random();
                nextNumOfBlock = random.Next(6);
                nextNumOfChar = random.Next(BlockConst.RangeChar) + BlockConst.StartNumChar;
                nextBlock.CreateBlock(nextNumOfBlock, nextNumOfChar);
                //nextBlock.RelocateNextBlock();                      

                if (IsOver())
                {
                    break;
                }

                while (!IsHitBottomOrBlock())
                {
                    if (Console.KeyAvailable)
                    {
                        HandlePressingKey(Console.ReadKey(true).Key);
                    }
                    else
                    {
                        HandlePressingKey(default);
                    }
                }

                if (countOfPieses > 3)
                {
                    time -= 50;
                    difficulty++;
                    countOfPieses = 0;

                    if (time <= 50)
                    {
                        time = 50;
                        difficulty = 10;
                    }
                }

                if (IsFullLines())
                {

                }

                for (int i = 0; i < myBlock.newBlock.Count; i++)
                {
                    bulkOfUsedPoints.Add(myBlock.newBlock[i]);
                }

                countOfPieses++;
                numOfBlock = nextNumOfBlock;
                numOfChar = nextNumOfChar;
            }

            ShowGameOver();
        }

        public void HandlePressingKey(ConsoleKey consoleKey)
        {
            int sleepTime = 100;
           
            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                    if (!IsHitLeftSide() && !IsHitRightSide())
                    {
                        myBlock.RotateBlock();
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (!IsHitLeftSide())
                    {
                        for (int i = 0; i < myBlock.newBlock.Capacity; i++)
                        {
                            myBlock.newBlock[i].MoveLeft();
                        }
                    }
                    break;

                case ConsoleKey.RightArrow:

                    if (!IsHitRightSide())
                    {
                        for (int i = 0; i < myBlock.newBlock.Count; i++)
                        {
                            myBlock.newBlock[i].MoveRight();
                        }
                    }
                    break;

                case ConsoleKey.DownArrow:
                    while (!IsHitBottomOrBlock())
                    {
                        Thread.Sleep(20);
                        myBlock.DropBlock();
                        myBlock.DrawBlock();
                    }
                    break;                    

                default:
                    Thread.Sleep(time);
                    myBlock.DropBlock();
                    break;
            }

            myBlock.DrawBlock();
            Thread.Sleep(sleepTime * 2);
        }

        private static void ShowGameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string text = "GAME OVER";
            int posLeft = GameWindowConst.WindowWidth / 2 - text.Length / 2;
            int posTop = PlayFieldConst.FieldHeight / 2;

            Console.SetCursorPosition(posLeft, posTop);
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void ShowGameInf()
        {
            int posLeft = (GameWindowConst.WindowWidth / 2 + GameWindowConst.WindowWidth) / 2;
            int posTop = PlayFieldConst.FieldHeight / 4;

            Console.SetCursorPosition(posLeft, posTop);
            Console.WriteLine("Next piece: ");

            Console.SetCursorPosition(posLeft, posTop * 2);
            Console.WriteLine("Score: {0}", score);

            Console.SetCursorPosition(posLeft, posTop * 3);
            Console.WriteLine("Difficulty: {0}", difficulty);
        }

        private void ShowHelpInf() 
        {
            int posTop = PlayFieldConst.FieldHeight / 4;

            Console.SetCursorPosition(0, posTop);
            Console.WriteLine("\tHOT KEY");

            Console.WriteLine("\n\tTurn Right: \n\tRIGHT ARROW");

            Console.WriteLine("\n\tTurn Left: \n\tLEFT ARROW");

            Console.WriteLine("\n\tRotate: \n\tUP ARROW");

            Console.WriteLine("\n\tDrop Down: \n\tDOWN ARROW");
        }

        #region Validation

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

        private bool IsHitLeftSide()
        {
            bool answer = false;

            for (int i = 0; i < myBlock.newBlock.Count; i++)
            {
                if ( myBlock.newBlock[i].X.Equals(playField.LeftSide[0].X + 1))
                {
                    answer = true;
                }
            }

            return answer;
        }

        private bool IsHitRightSide()
        {
            bool answer = false;

            for (int i = 0; i < myBlock.newBlock.Count; i++)
            {
                if (myBlock.newBlock[i].X.Equals(playField.RightSide[0].X - 1))                    
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

