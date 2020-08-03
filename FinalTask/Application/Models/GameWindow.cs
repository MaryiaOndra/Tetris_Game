using Application.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Application.Models
{
    sealed class GameWindow
    {
        string path = Directory.GetCurrentDirectory() + @"\scores.txt";

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

            string name;

            while (true)
            {

                Console.SetCursorPosition(GameWindowConst.LeftCursorPos
                    - GameWindowConst.EnterName.Length / 2, GameWindowConst.TopCursorPos + 4);

                name = Console.ReadLine().ToString();
                                
                if (!(name.Length > 15))
                {
                    GameWindowConst.ChooseShortName.CleanStrInSpecialPlace(GameWindowConst.LeftCursorPos
                      - (GameWindowConst.ChooseShortName.Length / 2), GameWindowConst.TopCursorPos + 6);

                    break;
                }
                else
                {
                    GameWindowConst.ChooseShortName.WriteStrInSpecialPlace(GameWindowConst.LeftCursorPos
                        - GameWindowConst.ChooseShortName.Length / 2, GameWindowConst.TopCursorPos + 6);

                    name.CleanStrInSpecialPlace(GameWindowConst.LeftCursorPos
                        - GameWindowConst.EnterName.Length / 2, GameWindowConst.TopCursorPos + 4);
                }
            }

            Console.CursorVisible = false;

            return name;
        }

        internal void AddNameToScore(string name, int score)
        {
            if (!File.Exists(path))
            {
                var newFile = File.Create(path);
                newFile.Close();
            }

            string[] lines = File.ReadAllLines(path);

            if (lines.Length.Equals(0))
            {
                TextWriter text = new StreamWriter(path, true);
                text.WriteLine($"\n\t{name}" + $"\t\t\t{score}");
                text.Close();
            }
            else
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i.Equals(lines.Length - 1))
                    {
                        TextWriter text = new StreamWriter(path, true);
                        text.WriteLine($"\n\t{name}" + $"\t\t\t{score}");
                        text.Close();
                    }
                }
            }
        }

        public void ShowScore()
        {
            Console.Clear();

            ScoreTable.Name.WriteStrInSpecialPlace(5, 5);
            ScoreTable.Score.WriteStrInSpecialPlace(30, 5);

            string[] lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
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
