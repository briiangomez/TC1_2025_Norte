using Services.Dal.Interfaces;
using Services.Domain.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Implementations
{
    public class FileLogger : ILogger, IDisposable
    {
        private readonly string _logFilePath;
        private readonly LogLevel _minimumLogLevel;
        private readonly StreamWriter _writer;
        private bool _disposed = false;

        public FileLogger(string logFilePath, LogLevel minimumLogLevel)
        {
            _logFilePath = logFilePath;
            _minimumLogLevel = minimumLogLevel;

            //Verificar que exista el directorio
            string directoryPath = Path.GetDirectoryName(_logFilePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            _writer = new StreamWriter(_logFilePath, true); // true para append
        }

        private void Log(LogLevel level, string message, Exception exception = null)
        {
            try
            {
                if (level >= _minimumLogLevel)
                {
                    var logEntry = new LogEntry
                    {
                        Timestamp = DateTime.Now,
                        Level = level,
                        Message = message,
                        Exception = exception
                    };
                    _writer.WriteLine(logEntry.ToString());
                    _writer.Flush(); //Me aseguro que se escriba inmediatamente
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _writer.Close();
            }
        }

        public void Trace(string message) => Log(LogLevel.Trace, message);
        public void Trace(string message, Exception exception) => Log(LogLevel.Trace, message, exception);
        public void Debug(string message) => Log(LogLevel.Debug, message);
        public void Debug(string message, Exception exception) => Log(LogLevel.Debug, message, exception);
        public void Information(string message) => Log(LogLevel.Information, message);
        public void Information(string message, Exception exception) => Log(LogLevel.Information, message, exception);
        public void Warning(string message) => Log(LogLevel.Warning, message);
        public void Warning(string message, Exception exception) => Log(LogLevel.Warning, message, exception);
        public void Error(string message) => Log(LogLevel.Error, message);
        public void Error(string message, Exception exception) => Log(LogLevel.Error, message, exception);
        public void Fatal(string message) => Log(LogLevel.Fatal, message);
        public void Fatal(string message, Exception exception) => Log(LogLevel.Fatal, message, exception);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _writer?.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this); //Evitar redundancia con el dispose del writer
        }
    }
}