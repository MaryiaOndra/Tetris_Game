using Application.ExtensionMethods;
using System;
using System.IO;
using System.Net.Mail;
using System.Threading;

namespace Application.Models
{
    class ScoreTable
    {
        static int place = 1;
        string path = @"C:\Users\Maria\Source\Repos\ITAcademy_console_TETRIS5\FinalTask\Application\Utility\Scores\scores.txt";

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
                text.WriteLine($"\n\t{place}\t\t{name}" + $"{interval}" + $"{score}");

                text.Close();
            }
            else
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i.Equals(lines.Length - 1))
                    {
                        TextWriter text = new StreamWriter(path, true);
                        place = i + 2;
                        text.WriteLine($"\n\t{place}\t\t{name}" + $"{interval}" + $"{score}");
                        text.Close();
                    }
                }
            }
        }

        public void ShowScore()
        {
            Console.Clear();

            "Place:".WriteStrInSpecialPlace(5, 5);
            "Name:".WriteStrInSpecialPlace(25, 5);
            "Score:".WriteStrInSpecialPlace(45, 5);

            string[] lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        internal void SendScoreToMail(string email)
        {
            Console.Clear();

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("ya.ondra@yandex.by");
                mail.To.Add(email);
                mail.Subject = "TETRIS scores";
                mail.Body = "mail with attachment";

                Attachment attachment;
                attachment = new Attachment(path);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception)
            {
                int posX = GameConst.WindowWidth / 2 - (ExceptConst.SendMail.Length / 2);
                int posY = GameConst.WindowHeight / 2;

                Console.Clear();

                ExceptConst.SendMail.WriteStrInSpecialPlace(posX, posY);

                Thread.Sleep(1000);                
            }     
        }
    }
}
