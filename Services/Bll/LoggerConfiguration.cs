using Services.Dal.Implementations;
using Services.Dal.Interfaces;
using Services.Domain.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll
{
    public class LoggerConfiguration
    {
        public string LogFilePath { get; set; } = "Logs/app.log"; //Por defecto
        public LogLevel MinimumLogLevel { get; set; } = LogLevel.Information; //Por defecto

        //Se puede aplicar un factory a futuro si tengo varias implementaciones de logs
        public ILogger CreateFileLogger()
        {
            return new FileLogger(LogFilePath, MinimumLogLevel);
        }
    }

}
