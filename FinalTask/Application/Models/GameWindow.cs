using Application.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Application.Models
{
    sealed class GameWindow
    {
        string path = Directory.GetCurrentDirectory() + @"\scores.txt";
        static int number = 1;

        internal void SetWindowParameters()
        {
            Console.SetWindowSize(GameWindowConst.WindowWidth, GameWindowConst.WindowHeight);
            Console.SetBufferSize(GameWindowConst.WindowWidth, GameWindowConst.WindowHeight);
            Console.CursorVisible = false;
        }

        internal void ShowTitle()
        {
            int greetX = 0;
            int greetY = GameWindowConst.WindowHeight / 5;
            int enterX = GameWindowConst.LeftCursorPos - GameWindowConst.PressEnter.Length / 2;
            int enterY = GameWindowConst.TopCursorPos + 2;

            GameWindowConst.Greeting.WriteStrInSpecialPlace(greetX, greetY);
            GameWindowConst.PressEnter.WriteStrInSpecialPlace(enterX, enterY);

            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

            Console.Clear();
        }

        internal string AskName()
        {
            string name;
            int thanksX = GameWindowConst.LeftCursorPos - GameWindowConst.Thanks.Length / 2;
            int thanksY = GameWindowConst.TopCursorPos;
            int enterX = GameWindowConst.LeftCursorPos - GameWindowConst.EnterName.Length / 2;
            int enterY = GameWindowConst.TopCursorPos + 2;

            Console.Clear();

            GameWindowConst.Thanks.WriteStrInSpecialPlace(thanksX, thanksY);
            GameWindowConst.EnterName.WriteStrInSpecialPlace(enterX, enterY);

            Console.CursorVisible = true;

            name = CheckNameLenght(enterX, enterY);

            Console.CursorVisible = false;

            return name;
        }

        private static string CheckNameLenght(int enterX, int enterY)
        {
            int shortX = GameWindowConst.LeftCursorPos - (GameWindowConst.ChooseShortName.Length / 2);
            int shortY = GameWindowConst.TopCursorPos + 6;
            int maxLenghtName = 15;
            string name;

            while (true)
            {
                Console.SetCursorPosition(enterX, enterY + 2);

                name = Console.ReadLine().ToString();

                if (!(name.Length > maxLenghtName))
                {
                    GameWindowConst.ChooseShortName.CleanStrInSpecialPlace(shortX, shortY);
                    break;
                }
                else
                {
                    GameWindowConst.ChooseShortName.WriteStrInSpecialPlace(shortX, shortY);
                    name.CleanStrInSpecialPlace(enterX, enterY + 2);
                }
            }

            return name;
        }

        internal static bool QueryYN(string question)
        {

            int posX = GameWindowConst.WindowWidth / 2 - question.Length / 2;
            int posY = PlayFieldConst.FieldHeight / 2 + 2;
            bool answer;

            Console.ForegroundColor = ConsoleColor.Red;

            question.WriteStrInSpecialPlace(posX, posY);

            answer = PressYN();

            question.CleanStrInSpecialPlace(posX, posY);

            Console.ResetColor();

            return answer;
        }

        private static bool PressYN()
        {
            bool answer;

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

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
