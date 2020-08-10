using Application.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Threading;
using Application.Logs;
using System.Reflection;

namespace Application.Models
{
    sealed class TetrisGame
    {
        private Block myBlock = new Block();
        private Block nextBlock = new Block();
        private List<Point> usedPoints = new List<Point>();
        private bool gameOver;
        private int row;

        private static int numOfBlock, nextNumOfBlock = 0;
        private static int numOfChar = BlockConst.StartNumChar;
        private static int nextNumOfChar;
        private static int difficulty;
        private static int countOfPieses;
        private static int time = 300;

        public static int Score { get; private set; } = 0;

        public void Start()
        {
            Utility.Logger(LogConst.StartLog, MethodBase.GetCurrentMethod().ToString());

            Score = 0;
            difficulty = 0;
            time = 300;

            PlayField playField = new PlayField();
            KeyAction keyAction = new KeyAction();

            playField.CreateListOfFieldPoints();
            GameInfo.ShowHelpInf();
            Thread.Sleep(500);

            while (!gameOver)
            {
                GameInfo.ShowGameInf(Score, difficulty);

                ShowNextFigure();

                myBlock.CreateBlock(numOfBlock, numOfChar);

                myBlock.Draw();

                if (Validation.IsOver(usedPoints))
                {
                    gameOver = true;
                    break;
                }

                while (!Validation.IsHitBottomOrBlock(myBlock, usedPoints, playField))
                {
                    if (Console.KeyAvailable)
                    {
                        keyAction.HandlePressingKey(Console.ReadKey(true).Key, myBlock, playField, usedPoints, time);
                    }
                    else if (gameOver)
                    {
                        break;
                    }
                    else
                    {
                        keyAction.HandlePressingKey(default, myBlock, playField, usedPoints, time);
                    }
                }

                if (countOfPieses >= 10)
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

                for (int i = 0; i < myBlock.newBlock.Count; i++)
                {
                    usedPoints.Add(myBlock.newBlock[i]);
                }

                while(Validation.IsFullLines(usedPoints, out row))
                {
                    DeleteFullLine(usedPoints);
                    DrawChangedField(usedPoints);

                    Score += 50;

                    Utility.Logger(LogConst.Increase, MethodBase.GetCurrentMethod().ToString());
                }

                countOfPieses++;
                numOfBlock = nextNumOfBlock;
                numOfChar = nextNumOfChar;
            }

            GameInfo.ShowGameOver();
            Thread.Sleep(500);
        }

        private void ShowNextFigure()
        {
            Block oldBlock = new Block();
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

        internal void DeleteFullLine(List<Point> points)
        {


            Console.SetCursorPosition(PlayFieldConst.BorderXPos + 1, row);
            Console.WriteLine(new string('$', PlayFieldConst.FieldWidth - 1));
            Thread.Sleep(300);

            foreach (var item in points)
            {
                item.Clear();
            }

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Y.Equals(row))
                {
                    points.Remove(points[i]);
                    i = -1;
                }
            }

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Y < row)
                {
                    points[i].MoveDown();
                }
            }

            usedPoints = points;
        }

        internal void DrawChangedField(List<Point> points)
        {
            foreach (var point in points)
            {
                point.Draw();
            }
        }
    }
}

