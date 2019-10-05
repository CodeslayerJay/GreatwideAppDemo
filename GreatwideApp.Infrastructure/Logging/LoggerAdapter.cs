using GreatwideApp.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatwideApp.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogMessage(string message = null, int level = 0, params object[] args)
        {
            if (String.IsNullOrEmpty(message))
                message = $"Something occured while processing the request.";

            switch (level)
            {
                case 0:
                    LogInformation(message, args);
                    break;
                case 1:
                    LogWarning(message, args);
                    break;
                case 2:
                    LogError(message, args);
                    break;
                default:
                    LogInformation(message, args);
                    break;
            }
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}
