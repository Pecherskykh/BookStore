using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Common.Interfaces
{
    interface ILogger
    {
        public IDisposable BeginScope<TState>(TState state);
        public bool IsEnabled(LogLevel logLevel);
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter);
    }
}
