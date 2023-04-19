using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace Logging
{
    /**
    * Author arborshield
    * Created by on 2023/4/2.
    * Logger Factory
    */
    public class LoggerFactory
    {
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
