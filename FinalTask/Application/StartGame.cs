using Application.Models;
using System;
using System.Threading;

namespace Application
{
    class StartGame
    {
        static void Main(string[] args)
        {
            GameWindow gameWindow = new GameWindow();

            gameWindow.SetWindowParameters();

            gameWindow.ShowTitle();

            TetrisGame game = new TetrisGame();

            game.Start();

            while(GameWindow.QueryYN(FrasesConst.WantTryAgain))
            {
                Console.Clear();
                game = new TetrisGame();
                game.Start();
            }

            ScoreTable scores = new ScoreTable();

            scores.AddNameToScore(gameWindow.QueryForName(), TetrisGame.Score);
            scores.ShowScore();

            Thread.Sleep(3000);

            while (GameWindow.QueryYN(FrasesConst.WantSendMail))
            {
                while (!scores.SendScoreToMail(gameWindow.QueryForEmail()))
                {
                    if (GameWindow.QueryYN(FrasesConst.TrySendMailAgain))
                        continue;

                    else
                        break;
                }

                break;
            }

            gameWindow.SayGoodbye();

            Environment.Exit(1);
        }
    }
}
