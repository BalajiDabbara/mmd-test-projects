using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace online_calculator_app.Telemetry
{
    /// <summary>
    /// The OnlineCalculatorLoggerProvider
    /// </summary>
    class OnlineCalculatorLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
