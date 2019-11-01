using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookStore.BusinessLogic.Common
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;
        private object _lock = new object();
        public FileLogger(string path)
        {
            _filePath = path;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter == null)
            {
                return;
            }
            lock (_lock)
            {
                try
                {
                    File.AppendAllText(_filePath, state + Environment.NewLine);
                }
                catch { }
            }
        }
    }
}
