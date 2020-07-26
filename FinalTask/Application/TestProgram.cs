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
            PlayField playField = new PlayField();

            //time = new Timer(Loop(), null, 0, 200);

            //TetrisLogic tetrisLogic =  new TetrisLogic();

            //tetrisLogic.GameLoop();

            Console.ReadLine();
        }
    }
}
