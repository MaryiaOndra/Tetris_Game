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
            int posLeft = GameConst.WindowWidth / 2 - text.Length / 2;
            int posTop = PlayFieldConst.FieldHeight / 2;

            Console.SetCursorPosition(posLeft, posTop);
            Console.WriteLine(text);
            Console.ResetColor();
        }

        internal static void ShowGameInf(int score, int difficulty)
        {
            int posLeft = (GameConst.WindowWidth / 2 + GameConst.WindowWidth) / 2;
            int posTop = PlayFieldConst.FieldHeight / 4;

            "Next piece: ".WriteStrInSpecialPlace(posLeft, posTop);

            $"Score: {score}".WriteStrInSpecialPlace(posLeft, posTop * 3);

            $"Difficulty: {difficulty}".WriteStrInSpecialPlace(posLeft, posTop * 4);
        }

        internal static void ShowHelpInf()
        {
            int posTop = PlayFieldConst.FieldHeight / 7;

            Console.SetCursorPosition(0, posTop);

            Console.WriteLine("\tHOTKEYS" +
                "\n\n\tTurn Right: \n\tRIGHT ARROW" +
                "\n\n\tTurn Left: \n\tLEFT ARROW" +
                "\n\n\tRotate: \n\tUP ARROW" +
                "\n\n\tDrop Down: \n\tDOWN ARROW" +
                "\n\n\tPause: \n\tP" +
                "\n\n\tCancel the game: \n\tESC");
        }
    }
}
