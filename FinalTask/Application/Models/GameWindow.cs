using Application.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    sealed class GameWindow
    {
        string path = Directory.GetCurrentDirectory() + @"\scores.txt";
        static int number = 1;

        internal void SetWindowParameters()
        {
            Console.SetWindowSize(GameConst.WindowWidth, GameConst.WindowHeight);
            Console.SetBufferSize(GameConst.WindowWidth, GameConst.WindowHeight);
            Console.CursorVisible = false;
        }

        internal void ShowTitle()
        {
            int greetX = 0;
            int greetY = GameConst.WindowHeight / 5;
            int enterX = GameConst.LeftCursorPos - GameConst.PressEnter.Length / 2;
            int enterY = GameConst.TopCursorPos + 2;

            GameConst.Greeting.WriteStrInSpecialPlace(greetX, greetY);
            GameConst.PressEnter.WriteStrInSpecialPlace(enterX, enterY);

            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

            Console.Clear();
        }

        internal string QueryForEmail()
        {
            string email;
            string request = GameConst.EnterEmail;
            int posX = GameConst.LeftCursorPos - request.Length / 2;
            int posY = GameConst.TopCursorPos;

            Console.Clear();

            request.WriteStrInSpecialPlace(posX, posY);

            email = CheckEmail(posX, posY);

            return email;
        }

        private string CheckEmail(int posX, int posY)
        {
            string email;
            string warning = GameConst.InvalidEmail;

            while (true)
            {
                Console.SetCursorPosition(posX, posY + 2);

                Console.CursorVisible = true;

                email = Console.ReadLine();

                if (new EmailAddressAttribute().IsValid(email))
                {
                    warning.CleanStrInSpecialPlace(posX, posY + 4);
                    break;
                }
                else
                {
                    warning.WriteStrInSpecialPlace(posX, posY + 4);
                    email.CleanStrInSpecialPlace(posX, posY + 2);
                }

                Console.CursorVisible = false;
            }

            return email;
        }

        internal string QueryForName()
        {
            string name;
            string title = GameConst.Thanks;
            string request = GameConst.EnterName;
            int titleX = GameConst.LeftCursorPos - title.Length / 2;
            int titleY = GameConst.TopCursorPos;
            int questX = GameConst.LeftCursorPos - request.Length / 2;
            int questY = GameConst.TopCursorPos + 2;

            Console.Clear();

            title.WriteStrInSpecialPlace(titleX, titleY);
            request.WriteStrInSpecialPlace(questX, questY);

            Console.CursorVisible = true;

            name = CheckNameLenght(questX, questY);

            Console.CursorVisible = false;

            return name;
        }

        private static string CheckNameLenght(int enterX, int enterY)
        {
            int shortX = GameConst.LeftCursorPos - (GameConst.TooLongName.Length / 2);
            int shortY = GameConst.TopCursorPos + 6;
            int maxLenghtName = 15;
            string warning = GameConst.TooLongName;
            string name;

            while (true)
            {
                Console.SetCursorPosition(enterX, enterY + 2);

                name = Console.ReadLine().ToString();

                if (!(name.Length > maxLenghtName))
                {
                    warning.CleanStrInSpecialPlace(shortX, shortY);
                    break;
                }
                else
                {
                    warning.WriteStrInSpecialPlace(shortX, shortY);
                    name.CleanStrInSpecialPlace(enterX, enterY + 2);
                }
            }

            return name;
        }

        internal static bool QueryYN(string question)
        {
            int posX = GameConst.WindowWidth / 2 - question.Length / 2;
            int posY = PlayFieldConst.FieldHeight / 2 + 2;
            bool answer;

            Console.ForegroundColor = ConsoleColor.Red;

            question.WriteStrInSpecialPlace(posX, posY);

            answer = PressYN();

            question.CleanStrInSpecialPlace(posX, posY);

            Console.ResetColor();

            return answer;
        }

        internal static bool QueryYN(string question, int posX, int posY)
        {
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

        internal void SayGoodbye()
        {
            int posX = GameConst.WindowWidth / 2 - GameConst.Bye.Length / 2;
            int posY = PlayFieldConst.FieldHeight / 2 + 2;

            Console.Clear();
            GameConst.Bye.WriteStrInSpecialPlace(posX, posY);
        }
    }
}
