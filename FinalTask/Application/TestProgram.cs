using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Application
{
    class TestProgram
    {
        static Timer time;
        static void Main(string[] args)
        {

            GameWindow gameWindow = new GameWindow();
            PlayField playField = new PlayField();
            playField.DrawPlayField();

            //time = new Timer(Loop(), null, 0, 200);

            while (true)
            {           
                    TetrisLogic tetrisLogic =  new TetrisLogic();
                    ConsoleKeyInfo key = Console.ReadKey();

                    tetrisLogic.GetDirection(key.Key);
                                
            }

            Console.ReadLine();

            //Console.WriteLine('╦');
            //char[] vs = { '║', '║', '║', '║', '║' };
        }
    }
}
