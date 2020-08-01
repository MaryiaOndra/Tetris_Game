using Application.ExtensionMethods;
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
            GameWindowConst.Greeting2.WriteStrInSpecialPlace(0, GameWindowConst.WindowHeight / 5);

            GameWindowConst.PressEnter.WriteStrInSpecialPlace(GameWindowConst.LeftCursorPos -
                 GameWindowConst.PressEnter.Length / 2, GameWindowConst.TopCursorPos + 2);

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
            }

            Console.Clear();
        }

        internal string AskName()
        {            
            Console.Clear();

            GameWindowConst.Thanks.WriteStrInSpecialPlace(GameWindowConst.LeftCursorPos
                - GameWindowConst.Thanks.Length / 2, GameWindowConst.TopCursorPos);

            GameWindowConst.EnterName.WriteStrInSpecialPlace(GameWindowConst.LeftCursorPos
                - GameWindowConst.EnterName.Length / 2, GameWindowConst.TopCursorPos + 2);

            Console.CursorVisible = true;

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.SetCursorPosition(GameWindowConst.LeftCursorPos
                - GameWindowConst.EnterName.Length / 2, GameWindowConst.TopCursorPos + 4);

            string name = Console.ReadLine().ToString();

            Console.CursorVisible = false;

            Console.ResetColor();

            return name;
        }
        internal bool TryAgain()
        {
            ConsoleKeyInfo keyInfo;
            bool answer;

            Console.ForegroundColor = ConsoleColor.Red;

            GameWindowConst.WantTryAgain.WriteStrInSpecialPlace(GameWindowConst.WindowWidth / 2 
                - GameWindowConst.WantTryAgain.Length / 2, PlayFieldConst.FieldHeight / 2 + 2);

            Console.ResetColor();

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
