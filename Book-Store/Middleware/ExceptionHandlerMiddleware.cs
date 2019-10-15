using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Common;

namespace Book_Store.Middlewaren
{
    public sealed class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            loggerFactory.AddProvider(new FileLoggerProvider("logger.txt"));
            _logger = loggerFactory.CreateLogger("FileLogger");
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(0, exception, "Error");
            }
        }
    }
}
