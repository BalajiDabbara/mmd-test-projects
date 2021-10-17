using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace OnlineCalculatorApp.Tests
{
    /// <summary>
    /// OnlineCalculatorAppTestFactory class
    /// </summary>
    public class OnlineCalculatorAppTestFactory
    {
        /// <summary>
        /// Get request body memory stream from json body.
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        private static MemoryStream GetRequestBodyStream(string body)
        {
            MemoryStream mmemoryStream = new MemoryStream();
            StreamWriter streamWriter = new StreamWriter(mmemoryStream);
            streamWriter.Write(body);
            streamWriter.Flush();
            mmemoryStream.Position = 0;
            return mmemoryStream;
        }

        /// <summary>
        /// Create the HttpRequest for test methods.
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="infixExpression">The infic expression</param>
        /// <returns>The HttpRequest</returns>
        public static HttpRequest CreateHttpRequest(string userName = "Test", string infixExpression = "(1)")
        {
            Dictionary<string, string> jsonData = new Dictionary<string, string>();
            jsonData.Add("UserName", userName);
            jsonData.Add("InfixExpression", infixExpression);
            var context = new DefaultHttpContext();
            var request = context.Request;
            request.Body = GetRequestBodyStream(JsonConvert.SerializeObject(jsonData));
            return request;
        }

        /// <summary>
        /// Create loggers
        /// </summary>
        /// <param name="type">LoggerType</param>
        /// <returns>Logger object</returns>
        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            ILogger logger;

            if (type == LoggerTypes.List)
            {
                logger = new ListLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            }

            return logger;
        }
    }
}
