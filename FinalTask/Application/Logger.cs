using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Application.Enums;

namespace Application
{
    public class LogWriter
    {
        private string exePath = string.Empty;
        private static int count = 0;
        

        public LogWriter(string logMessage, string methodLocation)
        {
            WriteLog(logMessage, methodLocation);            
        }

        public void WriteLog(string logMessage, string methodLocation)
        {
            exePath = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            StreamWriter logName = File.AppendText("log" +
                    System.DateTime.Today.ToString("yyyyMMdd") + $"_[{count}]" + ".txt");

            FileInfo logFileInfo = new FileInfo(exePath + logName);

            try
            {
                using (logName)
                {

                    Log(logMessage, logName, methodLocation);
                }
            }
            catch (ArgumentException ex)
            {

            }
        }

        public void Log(string logMessage, TextWriter txtWriter, string methodLocation)
        {
            txtWriter.Write("\r\nLog Entry : ");
            txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            txtWriter.WriteLine("Method: " + methodLocation);
            txtWriter.Write("Message: {0}\n", logMessage);
        }
    }
}
