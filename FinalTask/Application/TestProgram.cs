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

           // GameWindow gameWindow = new GameWindow();

            PlayField playField = new PlayField();
            playField.DrawPlayField();

            //string[] shape = new string[4];
            //shape[0] = ".X..";
            //shape[1] = ".X..";
            //shape[2] = ".X..";
            //shape[3] = ".X..";

            //string[] shape2 = new string[4];
            //shape2[0] = "..X.";
            //shape2[1] = ".X..";
            //shape2[2] = ".X..";
            //shape2[3] = "..X.";

            //List<string> shape3 = new List<string>();
            //shape3.Add(".XX.");
            //shape3.Add("X...");
            //shape3.Add("X...");
            //shape3.Add(".XX.");



            //Console.WriteLine('╦');
            //char[] vs = { '║', '║', '║', '║', '║' };
        }
    }
}
