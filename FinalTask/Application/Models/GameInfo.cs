using Application.ExtensionMethods;
using Application.Logs;
using Application.Models.Shapes;
using System;
using System.Reflection;

namespace Application.Models
{
    sealed class GameInfo
    {
        internal static void ShowGameOver()
        {
            string text = "GAME OVER";
            int posLeft = WindowConst.WindowWidth / 2 - text.Length / 2;
            int posTop = PlayFieldConst.FieldHeight / 2;

            Logger.AddLog(LogConst.FinishLog, MethodBase.GetCurrentMethod().ToString());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(posLeft, posTop);
            Console.WriteLine(text);
            Console.ResetColor();
        }

        internal static void ShowGameInf(int score, int difficulty)
        {
            int posLeft = (WindowConst.WindowWidth / 2 + WindowConst.WindowWidth) / 2;
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

        internal static void ShowNextFigure(int numOfBlock, int numOfChar, out int nextNumOfBlock, out int nextNumOfChar)
        {
            Block oldBlock = new Block();
            Block nextBlock = new Block();

            oldBlock.CreateBlock(numOfBlock, numOfChar);
            oldBlock.RelocateBlock();

            Random random = new Random();
            nextNumOfBlock = random.Next(6);
            nextNumOfChar = random.Next(BlockConst.RangeChar) + BlockConst.StartNumChar;

            nextBlock.CreateBlock(nextNumOfBlock, nextNumOfChar);
            nextBlock.RelocateBlock();

            oldBlock.Clear();
            nextBlock.Draw();
        }
    }
}
