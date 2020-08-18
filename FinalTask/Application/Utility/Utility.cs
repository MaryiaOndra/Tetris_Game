using System;
using System.IO;

namespace Application.Logs
{
    public class Utility
    {
        private static int count = 0;

        public static void VerifyDir(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (!dir.Exists)
                {
                    dir.Create();
                }
            }
            catch { }
        }

        public static void Logger(string message, string methodLocation)
        {
            string path2 = Directory.GetCurrentDirectory();

            string path = @"C:\Users\Maria\Source\Repos\ITAcademy_console_TETRIS\FinalTask\Application\Utility\Logs\";

            string fileName = "log" + System.DateTime.Today.ToString("yyyyMMdd") + $"_[{count}]" + ".txt";

            string lines = $"[{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToShortDateString()}]" +
                $"[{methodLocation}] : [{message}]";

            VerifyDir(path);

            try
            {
                StreamWriter file = new System.IO.StreamWriter(path + fileName, true);
                file.WriteLine(lines);
                file.Close();

                byte[] fileBytes = File.ReadAllBytes(path + fileName);

                if (fileBytes.Length >= 30_000)
                {
                    count++;
                }
            }
            catch (Exception) { }
        }
    }
}


