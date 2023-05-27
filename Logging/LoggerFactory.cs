using System;
using System.Configuration;
using Autofac;

namespace Logging
{
    public class LoggerFactory
    {
        private static IContainer container;

        public static ContainerBuilder Configure()
        {
            var builder = new ContainerBuilder();

            // Register the LoggerFactory class itself
            builder.RegisterType<LoggerFactory>().SingleInstance();

            // Register ILogger interface
            builder.Register(c => LoggerFactory.CreateLogger()).As<ILogger>();

            return builder;
        }

        public static ILogger CreateLogger()
        {
            string loggerType = ConfigurationManager.AppSettings["LoggerType"];

            if (loggerType == "FileLogger")
            {
                string filePath = ConfigurationManager.AppSettings["LogFilePath"];
                return new FileLogger(filePath);
            }
            else
            {
                throw new NotSupportedException($"Logger type '{loggerType}' is not supported.");
            }
        }
    }
}
