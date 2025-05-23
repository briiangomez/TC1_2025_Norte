using Services.Bll;
using Services.Dal.Interfaces;
using Services.Domain.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public class LoggerService
    {
        public static ILogger GetLogger()
        {
            var config = new LoggerConfiguration
            {
                LogFilePath = "Logs/mi_app.log", //Leer desde app.config
                MinimumLogLevel = LogLevel.Debug //Leer desde app.config
            };

            return config.CreateFileLogger();
        }
    }
}
