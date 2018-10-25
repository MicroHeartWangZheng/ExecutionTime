using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ExecutionTime
{
    public class CalculateExecutionTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        private DateTime startTime;
        private DateTime endTime;
        public CalculateExecutionTimeMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            this._next = next;
            _logger = loggerFactory.CreateLogger<CalculateExecutionTimeMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            startTime = DateTime.Now;
            await _next.Invoke(context);

            endTime = DateTime.Now;
            _logger.LogWarning($@"接口:{context.Request.Path} 耗时:{(int)((endTime - startTime).Milliseconds)}ms");
        }
    }
}
