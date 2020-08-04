using Application.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Threading;
using Application.Logs;

namespace Application.Models
{
    sealed class TetrisGame
    {
        private Block myBlock, nextBlock = new Block();
        private List<Point> usedPoints = new List<Point>();
        private bool gameOver;

        private static int numOfBlock, nextNumOfBlock;
        private static int numOfChar, nextNumOfChar = BlockConst.StartNumChar;
        private static int difficulty;
        private static int countOfPieses;
        private static int time = 300;

        public static int Score { get; private set; } = 0;

        public void Start()
        {
            Utility.Logger(LogConst.StartLog);

            Score = 0;
            difficulty = 0;

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
                    else if(gameOver)
                    {
                        break;
                    }
                    else
                    {
                        keyAction.HandlePressingKey(default, myBlock, playField, usedPoints, time);
                    }
                }

                if (countOfPieses > 5)
                {
                    time -= 50;
                    Score += 50;
                    difficulty++;
                    countOfPieses = 0;

                    Utility.Logger(LogConst.Increase);

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
    }
}

