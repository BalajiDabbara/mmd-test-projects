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
    public static class OnlineCalculator
    {
        [FunctionName("OnlineCalculator_Evaluate")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string UserName = null;
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

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
                responseMessage = string.Format(ErrorMessages.ExpressionEvaluationFailedWithException, UserName); 
            }



            return new OkObjectResult(responseMessage);
        }

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
                    break;
            }

            return onlineCalculatorFactory.GetCalculator();
        }
    }
}
