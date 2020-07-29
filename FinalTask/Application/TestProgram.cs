using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Application
{
    class TestProgram
    {
        static void Main(string[] args)
        {
            new GameWindow();

            Console.SetCursorPosition(GameWindowConst.WindowWidth / 2 - 
                GameWindowConst.Greeting.Length / 2, GameWindowConst.WindowHeight / 2 - 2);
            Console.WriteLine(GameWindowConst.Greeting);

            Console.SetCursorPosition(GameWindowConst.LeftCursorPos -
                 GameWindowConst.PressEnter.Length / 2, GameWindowConst.TopCursorPos);

            Console.WriteLine(GameWindowConst.PressEnter);

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
            }

            TetrisGame tetrisLogic = new TetrisGame();
            Console.Clear();
            tetrisLogic.Start();
        }
    }
}
