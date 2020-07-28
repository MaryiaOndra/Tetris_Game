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

            GameWindow gameWindow = new GameWindow();

            //time = new Timer(Loop(), null, 0, 200);

            TetrisGame tetrisLogic =  new TetrisGame();

            tetrisLogic.Start();

            Console.ReadLine();
        }
    }
}
