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

                logger.LogInformation("Please enter your input string");

                string inputString = Console.ReadLine();

                longestLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, logger);
                logger.LogInformation($"The longest valid parentheses length in {inputString} is {longestLength} ");

            }
            return longestLength;
        }
    }
}
