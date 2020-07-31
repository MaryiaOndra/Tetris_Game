using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    sealed class GameWindow
    {
        internal void SetWindowParameters()
        {
            Console.SetWindowSize(GameWindowConst.WindowWidth, GameWindowConst.WindowHeight);
            Console.SetBufferSize(GameWindowConst.WindowWidth, GameWindowConst.WindowHeight);
            Console.CursorVisible = false;
        }

        internal void ShowTitle()
        {
            Console.SetCursorPosition(0, GameWindowConst.WindowHeight / 5);
            Console.WriteLine(GameWindowConst.Greeting2);

            Console.SetCursorPosition(GameWindowConst.LeftCursorPos -
                 GameWindowConst.PressEnter.Length / 2, GameWindowConst.TopCursorPos + 2);

            Console.WriteLine(GameWindowConst.PressEnter);

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
            }

            Console.Clear();
        }

        internal string AskName()
        {
            Console.Clear();

            Console.SetCursorPosition(GameWindowConst.LeftCursorPos -
                 GameWindowConst.Thanks.Length / 2, GameWindowConst.TopCursorPos);

            Console.WriteLine(GameWindowConst.Thanks);

            Console.SetCursorPosition(GameWindowConst.LeftCursorPos - GameWindowConst.EnterName.Length / 2,
                GameWindowConst.TopCursorPos + 2);

            Console.WriteLine(GameWindowConst.EnterName);

            Console.SetCursorPosition(GameWindowConst.LeftCursorPos + GameWindowConst.EnterName.Length / 2,
               GameWindowConst.TopCursorPos + 2);

            Console.CursorVisible = true;

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            string name = Console.ReadLine().ToString();

            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.White;

            return name;
        }
        internal bool TryAgain()
        {
            string text = "Do you want to continue? Y/N";
            int posLeft = GameWindowConst.WindowWidth / 2 - text.Length / 2;
            int posTop = PlayFieldConst.FieldHeight / 2 + 2;
            bool answer = true;
            ConsoleKeyInfo keyInfo;

            Console.SetCursorPosition(posLeft, posTop);
            Console.WriteLine(text);

            do
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key.Equals(ConsoleKey.Y))
                {
                    answer = true;
                    break;
                }
                else if (keyInfo.Key.Equals(ConsoleKey.N))
                {
                    answer = false;
                    break;
                }
                else
                    continue;

            } while (true);

            return answer;
        }
    }
}
