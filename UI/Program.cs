using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using Autofac;
using Logging;

namespace UI
{
    static class Program
    {
        private static IContainer container;

        [STAThread]
        static void Main()
        {
            // Read settings from JSON file
            var jsonString = File.ReadAllText("appsettings.json");
            var config = JsonSerializer.Deserialize<Config>(jsonString);

            var builder = new ContainerBuilder();

            if (config.Logger.Type == "FileLogger")
            {
                builder.Register(c => new FileLogger(config.Logger.LogFilePath)).As<ILogger>();
            }
            else
            {
                throw new NotSupportedException($"Logger type '{config.Logger.Type}' is not supported.");
            }

            container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public class Config
        {
            public LoggerConfig Logger { get; set; }
        }

        public class LoggerConfig
        {
            public string Type { get; set; }
            public string LogFilePath { get; set; }
        }
    }
}
