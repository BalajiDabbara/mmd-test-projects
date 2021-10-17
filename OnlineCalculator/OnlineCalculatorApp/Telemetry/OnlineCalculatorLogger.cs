using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The OnlineCalculatorLogger class
    /// </summary>
    class OnlineCalculatorLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => false;

        /// <summary>
        /// Adds log message to the logs list
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="logLevel">The log level</param>
        /// <param name="eventId">The event id</param>
        /// <param name="state">The state</param>
        /// <param name="exception">The exception</param>
        /// <param name="formatter">The formatter</param>
        public void Log<TState>(LogLevel logLevel,
                                EventId eventId,
                                TState state,
                                Exception exception,
                                Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
        }
    }
}
