using Application.Enums;
using Application.ExtensionMethods;
using Application.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Application.Models
{
    class KeyAction
    {
        public void HandlePressingKey(ConsoleKey consoleKey, Block myBlock, PlayField playField, List<Point> usedPoints, int time)
        {
            int sleepTime = 100;
            int pauseX = GameConst.LeftCursorPos - GameConst.Pause.Length / 2;
            int downY = GameConst.WindowHeight - 2;
            int exitX = GameConst.LeftCursorPos - GameConst.WantExitGame.Length / 2;

            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                    if (!Validation.IsHitLeftSide(myBlock, playField)
                        && !Validation.IsHitRightSide(myBlock, playField))
                        myBlock.RotateBlock();
                    break;

                case ConsoleKey.LeftArrow:
                    if (!Validation.IsHitLeftSide(myBlock, playField))
                        myBlock.MoveLeft();
                    break;

                case ConsoleKey.RightArrow:
                    if (!Validation.IsHitRightSide(myBlock, playField))
                        myBlock.MoveRight();
                    break;

                case ConsoleKey.DownArrow:
                    while (!Validation.IsHitBottomOrBlock(myBlock, usedPoints, playField))
                    {
                        Thread.Sleep(20);
                        myBlock.MoveDown();
                        myBlock.Draw();
                    }
                    break;

                case ConsoleKey.P:
                    GameConst.Pause.WriteStrInSpecialPlace(pauseX, downY);

                    while (Console.ReadKey(true).Key != ConsoleKey.P) { };

                    GameConst.Pause.CleanStrInSpecialPlace(pauseX, downY);

                    break;

                case ConsoleKey.Escape:
                    while (GameWindow.QueryYN(GameConst.WantExitGame,
                        exitX, downY))
                    {
                        Environment.Exit(1);
                    }
                    break;

                default:
                    Thread.Sleep(time);
                    myBlock.MoveDown();
                    break;
            }

            myBlock.Draw();
            Thread.Sleep(sleepTime * 2);
        }
    }
}
