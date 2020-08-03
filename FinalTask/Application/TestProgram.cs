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

            gameWindow.SetWindowParameters();
            gameWindow.ShowTitle();

            TetrisGame game = new TetrisGame();

            game.Start();

            while(gameWindow.TryAgain())
            {
                Console.Clear();
                game = new TetrisGame();
                game.Start();
            }
                        
            gameWindow.AddNameToScore(gameWindow.AskName(), TetrisGame.Score);
            gameWindow.ShowScore();
            Console.ReadLine();
        }
    }
}
