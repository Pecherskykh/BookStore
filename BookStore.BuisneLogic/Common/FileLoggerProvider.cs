using Microsoft.Extensions.Logging;

namespace BookStore.BusinessLogic.Common
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string path;
        public FileLoggerProvider(string _path)
        {
            path = _path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(path);
        }

        public void Dispose()
        {
        }
    }
}
