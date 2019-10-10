using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookStore.BusinessLogic.Common
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
                throw new Exception();
            }
            catch (Exception exception)
            {
                try
                {
                    _logger.LogError(0, exception, "Error");
                }
                catch (Exception innerException)
                {
                    _logger.LogError(0, innerException, "Ошибка обработки исключения");
                }
                throw;
            }
        }
    }
}
