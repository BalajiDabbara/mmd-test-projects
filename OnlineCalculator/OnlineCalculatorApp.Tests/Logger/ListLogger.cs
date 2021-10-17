using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp.Tests
{
    /// <summary>
    /// The ListLogger class
    /// </summary>
    public class ListLogger : ILogger
    {
        public IList<string> Logs;

        public IDisposable BeginScope<TState>(TState state) => NullScope.Instance;

        public bool IsEnabled(LogLevel logLevel) => false;

        /// <summary>
        /// ListLogger contructor
        /// </summary>
        public ListLogger()
        {
            this.Logs = new List<string>();
        }

        /// <summary>
        /// Addes log message to the logs list
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
            string message = formatter(state, exception);
            this.Logs.Add(message);
        }
    }
}
