using System;
using System.IO;
using System.ComponentModel.Composition;

namespace Logging
{
    [Export(typeof(ILogger))]
    public class FileLogger : ILogger
    {
        private string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
        }

        public void Log(string message)
        {
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
