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
    public class OnlineCalculatorAppTestFactory
    {
        private static Dictionary<string, StringValues> CreateDictionary(string key, string value)
        {
            var qs = new Dictionary<string, StringValues>
            {
                { key, value }
            };
            return qs;
        }

        private static MemoryStream GetRequestBodyStream(string body)
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            sw.Write(body);
            sw.Flush();
            ms.Position = 0;
            return ms;
        }

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
