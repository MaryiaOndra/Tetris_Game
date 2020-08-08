using Application.ExtensionMethods;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Application.Models
{
    class ScoreTable
    {
        string path = @"C:\Users\Maria\Source\Repos\ITAcademy_console_TETRIS\FinalTask\Application\Utility\Scores\scores.txt";

        internal void AddNameToScore(string name, int score)
        {
            int gap = 25;
            string interval = new string(' ', gap - name.Length);

            if (!File.Exists(path))
            {
                var newFile = File.Create(path);
                newFile.Close();
            }

            string[] lines = File.ReadAllLines(path);

            if (lines.Length.Equals(0))
            {
                TextWriter text = new StreamWriter(path, true);
                text.WriteLine($"\n\t\t{name}" + $"{interval}" + $"{score}");

                text.Close();
            }
            else
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i.Equals(lines.Length - 1))
                    {
                        TextWriter text = new StreamWriter(path, true);
                        text.WriteLine($"\n\t\t{name}" + $"{interval}" + $"{score}");
                        text.Close();
                    }
                }
            }
        }

        internal  void AddPersonDataToJson(string name, int score)
        {
            string pathJSON = @"G:\JSON\scores.json";
            
            int number = 0;
            string newJson = string.Empty;

            Person player = new Person { Name = name, Score = score, Number = number };

            List<Person> allPlayers = new List<Person>();


            if (File.Exists(pathJSON))
            {
                using (StreamReader r = new StreamReader(pathJSON))
                {
                    string json = r.ReadToEnd();
                    allPlayers = JsonConvert.DeserializeObject<List<Person>>(json);
                    File.Delete(pathJSON);
                    allPlayers.Add(player);
                    newJson = JsonConvert.SerializeObject(allPlayers);
                }
            }
            else if (!File.Exists(pathJSON))
            {
                using (StreamReader r = new StreamReader(pathJSON))
                {
                    allPlayers.Add(player);
                    newJson = JsonConvert.SerializeObject(allPlayers);
                }
            }

            File.WriteAllText(pathJSON, newJson);
        }


        public void ShowScore()
        {
            Console.Clear();

            "Name:".WriteStrInSpecialPlace(15, 5);
            "Score:".WriteStrInSpecialPlace(40, 5);
            "Place:".WriteStrInSpecialPlace(5, 5);

            string[] lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
