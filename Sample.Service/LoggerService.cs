using Sample.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Service
{
    public class LoggerService : ILoggerService
    {
        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message)
        {
            throw new NotImplementedException();
        }
    }
}
