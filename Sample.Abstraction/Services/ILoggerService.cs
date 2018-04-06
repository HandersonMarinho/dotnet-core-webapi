using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Abstraction.Services
{
    public interface ILoggerService
    {
        void Error(string message);
        void Info(string message);
        void Warning(string message);
    }
}
