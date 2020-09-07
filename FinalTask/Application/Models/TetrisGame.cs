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
        private List<Point> usedPoints = new List<Point>();
        private bool gameOver;
        private int row;
        private KeyAction keyAction = new KeyAction();

        private static int numOfBlock = 9;
        private static int nextNumOfBlock;
        private static int difficulty;
        private static int countOfPieses;
        private static int time = 300;

        public static int Score { get; private set; } = 0;

        public void Start()
        {
            Logger.AddLog(LogConst.StartLog, MethodBase.GetCurrentMethod().ToString());

            Score = 0;
            difficulty = 0;
            time = 300;

            GameInfo.ShowHelpInf();

            PlayField playField = new PlayField();

            while (!gameOver)
            {
                Console.ForegroundColor = ConsoleColor.Gray;

                GameInfo.ShowGameInf(Score, difficulty);

                GameInfo.ShowNextFigure(numOfBlock, out nextNumOfBlock);

                myBlock.CreateBlock(numOfBlock);

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
                        keyAction.HandlePressingKey(Console.ReadKey(true).Key,
                            myBlock, playField, usedPoints, time);
                    }
                    else
                    {
                        keyAction.HandlePressingKey(default, 
                            myBlock, playField, usedPoints, time);
                    }
                }

                if (countOfPieses >= 10)
                {
                    time -= 60;
                    difficulty++;
                    countOfPieses = 0;  
                    
                    if (time <= 60)
                    {
                        time = 30;
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

                    playField.DrawChangedField(usedPoints);

                    Score += 50;

                    Logger.AddLog(LogConst.Increase, MethodBase.GetCurrentMethod().ToString());
                }

                countOfPieses++;
                numOfBlock = nextNumOfBlock;
            }

            GameInfo.ShowGameOver();
            Thread.Sleep(500);
        }

        internal void DeleteFullLine(List<Point> points)
        {
            Console.SetCursorPosition(PlayFieldConst.BorderXPos + 1, row);
            Console.WriteLine(new string('╬', PlayFieldConst.FieldWidth - 1));
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
    }
}

