using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    class TestProgram
    {
        static void Main(string[] args)
        {

            GameWindow gameWindow = new GameWindow();

            PlayField playField = new PlayField();
            playField.DrawPlayField();

            TetrisLogic shape = new TetrisLogic();


            Console.ReadLine();



            //Console.WriteLine('╦');
            //char[] vs = { '║', '║', '║', '║', '║' };
        }
    }
}
