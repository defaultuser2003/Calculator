using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Logging
{
    /**
    * Author arborshield
    * Created by on 2023/4/2.
    * FielLogger
    */
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
