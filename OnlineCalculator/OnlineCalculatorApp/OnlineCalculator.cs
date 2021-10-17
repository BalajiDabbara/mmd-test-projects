using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The online calculator function app class.
    /// </summary>
    public static class OnlineCalculator
    {
        /// <summary>
        /// The function app runner
        /// </summary>
        /// <param name="req">The http request.</param>
        /// <param name="log">The logger.</param>
        /// <returns>Action result</returns>
        [FunctionName("OnlineCalculator_Evaluate")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("OnlineCalculatorApp function started processiong the request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            return EvaluateUserExpression(requestBody);
        }

        /// <summary>
        /// Evaluates the user input expression and return the result.
        /// </summary>
        /// <param name="requestBody">The http request body.</param>
        /// <returns>Action result</returns>
        private static IActionResult EvaluateUserExpression(string requestBody)
        {
            string UserName = null;
            dynamic requestBodyObject = JsonConvert.DeserializeObject(requestBody);
            UserName = UserName ?? requestBodyObject?.UserName;
            string inputInfixExpression = requestBodyObject?.InfixExpression;
            IExpressionProcessor expressionProcessor = new ExpressionProcessor();
            string sanitizedInputInfixExpression = expressionProcessor.SanitizeExpression(inputInfixExpression);

            string responseMessage;

            if (string.IsNullOrEmpty(UserName))
            {
                responseMessage = ErrorMessages.UserNameEmpty;
                return new OkObjectResult(responseMessage);
            }

            if (expressionProcessor.ValidateExpression(sanitizedInputInfixExpression))
            {
                try
                {
                    OnlineCalculatorBase onlineCalculator = GetCalculator(CalculatorType.Simple, UserName, string.Empty);
                    long result = onlineCalculator.Eval(sanitizedInputInfixExpression);
                    responseMessage = string.Format(ErrorMessages.ExpressionEvaluationSuccess, UserName, inputInfixExpression, result);
                }
                catch (Exception exception)
                {
                    responseMessage = string.Format(ErrorMessages.ExpressionEvaluationFailedWithException, UserName, exception.Message);
                }
            }
            else
            {
                responseMessage = string.Format(ErrorMessages.ExpressionEvaluationFailedWithoutException, UserName);
            }


            return new OkObjectResult(responseMessage);
        }

        /// <summary>
        /// Returns the calculator object.
        /// </summary>
        /// <param name="calculatorType">The calculator type.</param>
        /// <param name="userName">The user name.</param>
        /// <param name="sessionId">The session id</param>
        /// <returns>The SimpleCalculator object</returns>
        private static OnlineCalculatorBase GetCalculator(CalculatorType calculatorType, string userName, string sessionId)
        {
            CalculatorMemory calcMemory = new CalculatorMemory();
            SessionManager sessionManager = SessionManager.Instance;
            IExpressionEvaluator expressionEvaluator = new ExpressionEvaluator();
            IMemoryManager memoryManager = new MemoryManager(calcMemory);
            IUserContext userContext = new UserContext(userName, sessionId);

            OnlineCalculatorFactory onlineCalculatorFactory = null;

            switch(calculatorType)
            {
                case CalculatorType.Simple:
                    onlineCalculatorFactory = new SimpleOnlineCalculatorFactory(expressionEvaluator, memoryManager, sessionManager, userContext);
                    break;
                case CalculatorType.Advanced:
                    // To be extended for advanced operations.
                    break;
            }

            return onlineCalculatorFactory.GetCalculator();
        }
    }
}
