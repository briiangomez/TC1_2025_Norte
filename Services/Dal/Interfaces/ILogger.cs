using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Interfaces
{
    public interface ILogger
    {
        void Trace(string message);
        void Trace(string message, Exception exception);
        void Debug(string message);
        void Debug(string message, Exception exception);
        void Information(string message);
        void Information(string message, Exception exception);
        void Warning(string message);
        void Warning(string message, Exception exception);
        void Error(string message);
        void Error(string message, Exception exception);
        void Fatal(string message);
        void Fatal(string message, Exception exception);
    }
}
