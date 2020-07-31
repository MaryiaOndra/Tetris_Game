using Application.Enums;
using Application.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace Application.Models
{
    sealed class TetrisGame
    {
        private Block myBlock = new Block();
        private Block oldBlock = new Block();
        private Block nextBlock = new Block();

        private PlayField playField;
        private List<Point> usedPoints = new List<Point>();

        private static int numOfBlock;
        private static int nextNumOfBlock;
        private static int numOfChar = BlockConst.StartNumChar;
        private static int nextNumOfChar;
        private static int difficulty = 0;
        private static int time = 300;
        private static int countOfPieses = 0;
        private static int score = 0;
        private static bool pause = false;
        private bool gameOver = false;

        public void Start()
        {
            playField = new PlayField();
            playField.CreateListOfFieldPoints();
            ShowHelpInf();
            Thread.Sleep(500);

            while (!gameOver)
            {
                ShowGameInf();
                myBlock.CreateBlock(numOfBlock, numOfChar);
                myBlock.Draw();

                if (IsOver())
                {
                    gameOver = true;
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

                if (pause)
                {

                }

                if (countOfPieses > 5)
                {
                    time -= 50;
                    score += 50;
                    difficulty++;
                    countOfPieses = 0;

                    if (time <= 50)
                    {
                        time = 50;
                        difficulty = 10;
                    }
                }

                for (int i = 0; i < myBlock.newBlock.Count; i++)
                {
                    usedPoints.Add(myBlock.newBlock[i]);
                }

                countOfPieses++;
                numOfBlock = nextNumOfBlock;
                numOfChar = nextNumOfChar;
            }

            ShowGameOver();
            Thread.Sleep(500);
        }

        public void HandlePressingKey(ConsoleKey consoleKey)
        {
            int sleepTime = 100;
           
            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:

                    if (!IsHitLeftSide() && !IsHitRightSide())
                        myBlock.RotateBlock();
                    break;

                case ConsoleKey.LeftArrow:

                    if (!IsHitLeftSide())
                        myBlock.MoveLeft();
                    break;

                case ConsoleKey.RightArrow:

                    if (!IsHitRightSide())
                        myBlock.MoveRight();
                    break;

                case ConsoleKey.DownArrow:

                    while (!IsHitBottomOrBlock())
                    {
                        Thread.Sleep(20);
                        myBlock.MoveDown();
                        myBlock.Draw();
                    }
                    break;

                case ConsoleKey.P:
                    while (Console.ReadKey(true).Key != ConsoleKey.P) { };
                    myBlock.MoveDown();
                    break;

                default:
                    Thread.Sleep(time);
                    myBlock.MoveDown();
                    break;
            }

            myBlock.Draw();
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

        private void ShowNextFigure() 
        {
            oldBlock.CreateBlock(numOfBlock, numOfChar);
            oldBlock.RelocateBlock();

            Random random = new Random();
            nextNumOfBlock = random.Next(6);
            nextNumOfChar = random.Next(BlockConst.RangeChar) + BlockConst.StartNumChar;

            nextBlock.CreateBlock(nextNumOfBlock, nextNumOfChar);
            nextBlock.RelocateBlock();
            oldBlock.Clear();
            nextBlock.Draw();
        }

        private void ShowGameInf()
        {
            int posLeft = (GameWindowConst.WindowWidth / 2 + GameWindowConst.WindowWidth) / 2;
            int posTop = PlayFieldConst.FieldHeight / 4;

            Console.SetCursorPosition(posLeft, posTop);
            Console.WriteLine("Next piece: ");

            ShowNextFigure();            

            Console.SetCursorPosition(posLeft, posTop * 3);
            Console.WriteLine("Score: {0}", score);

            Console.SetCursorPosition(posLeft, posTop * 4);
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

            Console.WriteLine("\n\tPause: \n\tP");
        }


        #region Validation

        private bool IsHitBottomOrBlock()
        {
            bool answer = false;

            for (int i = 0; i < myBlock.newBlock.Count; i++)
            {
                for (int j = 0; j < usedPoints.Count; j++)
                {
                    if (myBlock.newBlock[i].Y.Equals(usedPoints[j].Y - 1)
                        && myBlock.newBlock[i].X.Equals(usedPoints[j].X))
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

            for (int i = 0; i < usedPoints.Count; i++)
            {
                if (usedPoints[i].Y.Equals(BlockConst.StartY))
                {
                    answer = true;
                }
            }

            return answer;
        }

        private bool IsFullLines()
        {
            bool answer = false;
            int y = PlayFieldConst.FieldHeight;
            int maxCount = PlayFieldConst.FieldWidth;
            int count = 0;
            int row = 0;

            for (int i = y; i > 0; i--)
            {
                for (int j = 0; j < usedPoints.Count; j++)
                {
                    if (usedPoints[j].Y.Equals(i))
                    {
                        count++;
                    }
                    if (count.Equals(maxCount))
                    {
                        row = i;
                        count = 0;
                    }
                }
            }

            if (count.Equals(maxCount))
            {
                answer = true;
            }
            return answer;
        }

        #endregion
    }
}

