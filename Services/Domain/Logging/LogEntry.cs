using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Logging
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; } // Opcional: Para información de excepciones

        public override string ToString()
        {
            string exceptionInfo = Exception != null ? $"\nExcepción: {Exception}, StackTrace: {Exception.StackTrace}" : "";
            return $"[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level}] {Message}{exceptionInfo}";
        }
    }
}
