using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            StreamWriter writer = File.AppendText(_filePath);
            writer.WriteLine($"{DateTime.Now} {ClassName} {logLevel} {message}");
            writer.Close();
        }
    }
}
