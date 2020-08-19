using Application.ExtensionMethods;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    sealed class GameWindow
    {
        internal void SetWindowParameters()
        {
            Console.SetWindowSize(WindowConst.WindowWidth, WindowConst.WindowHeight);
            Console.SetBufferSize(WindowConst.WindowWidth, WindowConst.WindowHeight);
            Console.CursorVisible = false;
        }

        internal void ShowTitle()
        {
            int greetX = 0;
            int greetY = WindowConst.WindowHeight / 5;
            int enterX = WindowConst.LeftCursorPos - FrasesConst.PressEnter.Length / 2;
            int enterY = WindowConst.TopCursorPos + 2;

            FrasesConst.Greeting.WriteStrInSpecialPlace(greetX, greetY);
            FrasesConst.PressEnter.WriteStrInSpecialPlace(enterX, enterY);

            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

            Console.Clear();
        }

        internal string QueryForEmail()
        {
            string email;
            string request = FrasesConst.EnterEmail;
            int posX = WindowConst.LeftCursorPos - request.Length / 2;
            int posY = WindowConst.TopCursorPos;

            Console.Clear();

            request.WriteStrInSpecialPlace(posX, posY);

            email = CheckEmail(posX, posY);

            return email;
        }

        private string CheckEmail(int posX, int posY)
        {
            string email;
            string warning = FrasesConst.InvalidEmail;

            while (true)
            {
                Console.SetCursorPosition(posX, posY + 2);


                email = Console.ReadLine();

                if (!new EmailAddressAttribute().IsValid(email))
                {
                    warning.WriteStrInSpecialPlace(posX, posY + 4);
                    email.CleanStrInSpecialPlace(posX, posY + 2);
                }
                else
                {
                    warning.CleanStrInSpecialPlace(posX, posY + 4);
                    break;
                }

                Console.CursorVisible = false;
            }

            return email;
        }

        internal string QueryForName()
        {
            string name;
            string title = FrasesConst.Thanks;
            string request = FrasesConst.EnterName;
            int titleX = WindowConst.LeftCursorPos - title.Length / 2;
            int titleY = WindowConst.TopCursorPos;
            int questX = WindowConst.LeftCursorPos - request.Length / 2;
            int questY = WindowConst.TopCursorPos + 2;

            Console.Clear();

            title.WriteStrInSpecialPlace(titleX, titleY);
            request.WriteStrInSpecialPlace(questX, questY);

            Console.CursorVisible = true;

            name = CheckNameLenght(questX, questY);          

            return name;
        }

        private static string CheckNameLenght(int enterX, int enterY)
        {
            int shortX = WindowConst.LeftCursorPos - (FrasesConst.TooLongName.Length / 2);
            int shortY = WindowConst.TopCursorPos + 6;
            int maxLenghtName = 15;
            string warning = FrasesConst.TooLongName;
            string name;

            while (true)
            {
                Console.SetCursorPosition(enterX, enterY + 2);
                Console.CursorVisible = true;

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

                Console.CursorVisible = false;
            }

            return name;
        }

        internal static bool QueryYN(string question)
        {
            int posX = WindowConst.WindowWidth / 2 - question.Length / 2;
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
            int posX = WindowConst.WindowWidth / 2 - FrasesConst.Bye.Length / 2;
            int posY = PlayFieldConst.FieldHeight / 2 + 2;

            Console.Clear();

            FrasesConst.Bye.WriteStrInSpecialPlace(posX, posY);
        }
    }
}
