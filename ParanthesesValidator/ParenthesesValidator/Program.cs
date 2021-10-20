using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace ParenthesesValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build dependency service provider with all services (objects)
            var serviceProvider = new ServiceCollection()
                                        .AddLogging()
                                        .AddSingleton<IParenthesesValidator, ParenthesesValidator>()
                                        .BuildServiceProvider();


            using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
            {

                var logger = loggerFactory.CreateLogger<Program>();

                var parenthesesValidator = serviceProvider.GetService<IParenthesesValidator>();

                logger.LogInformation("Please enter your input string");

                string inputString = Console.ReadLine();

                int longestLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, logger);
                logger.LogInformation($"The longest valid parentheses length in {inputString} is {longestLength} ");

            }

        }
    }
}
