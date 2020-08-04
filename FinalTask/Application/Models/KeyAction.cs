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
                    TetrisGameConst.Pause.WriteStrInSpecialPlace(
                        GameWindowConst.LeftCursorPos
                        - TetrisGameConst.Pause.Length / 2, TetrisGameConst.posYPause);

                    while (Console.ReadKey(true).Key != ConsoleKey.P) { };

                    TetrisGameConst.Pause.CleanStrInSpecialPlace(
                        GameWindowConst.LeftCursorPos
                        - TetrisGameConst.Pause.Length / 2, TetrisGameConst.posYPause);

                    myBlock.MoveDown();
                    break;

                //case ConsoleKey.Escape:
                //    gameOver = true;
                //    break;

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
