using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace OnlineCalculator
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
            long result = 0;
            string responseMessage = string.Empty;



            dynamic data = JsonConvert.DeserializeObject(requestBody);
            UserName = UserName ?? data?.UserName;
            string inputInfixExpression = data?.InfixExpression;
            IExpressionProcessor expressionProcessor = new ExpressionProcessor();
            inputInfixExpression = expressionProcessor.SanitizeExpression(inputInfixExpression);

            if (expressionProcessor.ValidateExpression(inputInfixExpression))
            {
                try
                {
                    OnlineCalculatorBase onlineCalculator = GetCalculator(CalculatorType.Simple, UserName, string.Empty);
                    result = onlineCalculator.Eval(inputInfixExpression);
                    responseMessage = string.IsNullOrEmpty(UserName)
                   ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                   : $"Hello, {UserName}. Your input expression {inputInfixExpression} has been evaluated to : {result}.";
                }
                catch(Exception exception)
                {
                    responseMessage = $"Hello, {UserName}. Unable to evaluate your expression. Please ensure that your expression is valid {exception.Message}";
                }
            }
            else
            {
                responseMessage = $"Hello, {UserName}. Unable to evaluate your expression. Please ensure that your expression is valid.";
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
