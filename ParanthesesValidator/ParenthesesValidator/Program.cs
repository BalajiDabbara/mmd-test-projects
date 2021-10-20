using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace ParenthesesValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            LongestLengthOfValidParentheses(serviceProvider);
        }

        /// <summary>
        /// Configure required services
        /// </summary>
        /// <returns></returns>
        public static ServiceProvider ConfigureServices()
        {
            ServiceProvider serviceProvider =  new ServiceCollection()
                                        .AddLogging()
                                        .AddSingleton<IParenthesesValidator, ParenthesesValidator>()
                                        .BuildServiceProvider();
            return serviceProvider;
        }

        /// <summary>
        /// Get longest length
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static int LongestLengthOfValidParentheses(ServiceProvider serviceProvider)
        {
            int longestLength = 0;

            using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
            {

                var logger = loggerFactory.CreateLogger<Program>();

                var parenthesesValidator = serviceProvider.GetService<IParenthesesValidator>();

                while (true)
                {
                    try
                    {
                        logger.LogInformation(ErrorMessages.RequestInputString);
                        string inputString = Console.ReadLine();

                        if (inputString.ToUpper() == Constants.EXIT)
                            break;

                        longestLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, logger);
                        logger.LogInformation(ErrorMessages.ResultMessage, inputString, longestLength);
                    }
                    catch(Exception ex)
                    {
                        logger.LogInformation(ErrorMessages.InvallidInputString);
                    }
                }

            }
            return longestLength;
        }
    }
}
