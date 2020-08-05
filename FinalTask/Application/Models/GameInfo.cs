using Application.ExtensionMethods;
using Application.Logs;
using System;
using System.Reflection;

namespace Application.Models
{
    class GameInfo
    {
        internal static void ShowGameOver()
        {
            Utility.Logger(LogConst.FinishLog, MethodBase.GetCurrentMethod().ToString());

            Console.ForegroundColor = ConsoleColor.Red;

            string text = "GAME OVER";
            int posLeft = GameWindowConst.WindowWidth / 2 - text.Length / 2;
            int posTop = PlayFieldConst.FieldHeight / 2;

            Console.SetCursorPosition(posLeft, posTop);
            Console.WriteLine(text);
            Console.ResetColor();
        }

        internal static void ShowGameInf(int score, int difficulty)
        {
            int posLeft = (GameWindowConst.WindowWidth / 2 + GameWindowConst.WindowWidth) / 2;
            int posTop = PlayFieldConst.FieldHeight / 4;

            "Next piece: ".WriteStrInSpecialPlace(posLeft, posTop);

            $"Score: {score}".WriteStrInSpecialPlace(posLeft, posTop * 3);

            $"Difficulty: {difficulty}".WriteStrInSpecialPlace(posLeft, posTop * 4);
        }

        internal static void ShowHelpInf()
        {
            int posTop = PlayFieldConst.FieldHeight / 7;

            Console.SetCursorPosition(0, posTop);

            Console.WriteLine("\tHOT KEY");

            Console.WriteLine("\n\tTurn Right: \n\tRIGHT ARROW");

            Console.WriteLine("\n\tTurn Left: \n\tLEFT ARROW");

            Console.WriteLine("\n\tRotate: \n\tUP ARROW");

            Console.WriteLine("\n\tDrop Down: \n\tDOWN ARROW");

            Console.WriteLine("\n\tPause: \n\tP");

            //Console.WriteLine("\n\tCancel the game: \n\tESC");
        }
    }
}
