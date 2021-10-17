using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace OnlineCalculatorApp.Tests
{
    /// <summary>
    /// OnlineCalculatorAppTests class
    /// </summary>
    public class OnlineCalculatorAppTests
    {
        private readonly ILogger logger = OnlineCalculatorAppTestFactory.CreateLogger();

        /// <summary>
        /// Validate the valid infix expression with success message
        /// </summary>
        [Fact]
        public async void ValidateInfixExpressionEvaluationSuccess()
        {
            // Setup
            string userName = "Balaji";
            string infixExpression = "(2+2)";
            long expectedResult = 4;

            // Act
            var request = OnlineCalculatorAppTestFactory.CreateHttpRequest(userName, infixExpression);
            var response = (OkObjectResult)await OnlineCalculatorApp.OnlineCalculator.Run(request, logger);

            // Assert
            Assert.Equal(string.Format(ErrorMessages.ExpressionEvaluationSuccess, userName, infixExpression, expectedResult), response.Value);
        }

        /// <summary>
        /// Validate the invalid infix expression with failure message
        /// </summary>
        [Fact]
        public async void ValidateInfixExpressionEvaluationFailedOnInvalidInput()
        {
            // Setup
            string userName = "Dabbara";
            string infixExpression = "";

            // Act
            var request = OnlineCalculatorAppTestFactory.CreateHttpRequest(userName, infixExpression);
            var response = (OkObjectResult)await OnlineCalculatorApp.OnlineCalculator.Run(request, logger);

            // Assert
            string responseString = response.Value.ToString();
            Assert.Contains(string.Format(ErrorMessages.ExpressionEvaluationFailedWithoutException, userName), responseString);
        }

        /// <summary>
        /// Validate the valid infix expressionwith all operators
        /// </summary>
        [Fact]
        public async void ValidateInfixExpressionEvaluationSuccesssOnAllOperators()
        {
            // Setup
            string userName = "Balaji";
            string infixExpression = "(4+2)*4/2-2";
            long expectedResult = 10;

            // Act
            var request = OnlineCalculatorAppTestFactory.CreateHttpRequest(userName, infixExpression);
            var response = (OkObjectResult)await OnlineCalculatorApp.OnlineCalculator.Run(request, logger);

            // Assert
            Assert.Equal(string.Format(ErrorMessages.ExpressionEvaluationSuccess, userName, infixExpression, expectedResult), response.Value);
        }

        /// <summary>
        /// Validate the valid infix expression and empty user for failure.
        /// </summary>
        [Fact]
        public async void ValidateEmptyUserNameThrowsAnError()
        {
            // Setup
            string userName = "";
            string infixExpression = "(4+2)*4/2-2";
            // Act
            var request = OnlineCalculatorAppTestFactory.CreateHttpRequest(userName, infixExpression);
            var response = (OkObjectResult)await OnlineCalculatorApp.OnlineCalculator.Run(request, logger);

            // Assert
            Assert.Equal(string.Format(ErrorMessages.UserNameEmpty, userName), response.Value);
        }

        /// <summary>
        /// Validate the memory recall functionality.
        /// </summary>
        [Fact]
        public async void ValidateMemoryRecall()
        {
            // Setup
            string userName = "Balaji";
            string infixExpression = "(4+2)*4/2-2";
            long expectedResult = 10;

            // Act
            var request = OnlineCalculatorAppTestFactory.CreateHttpRequest(userName, infixExpression);
            var response = (OkObjectResult)await OnlineCalculatorApp.OnlineCalculator.Run(request, logger);

            // Assert
            Assert.Equal(string.Format(ErrorMessages.ExpressionEvaluationSuccess, userName, infixExpression, expectedResult), response.Value);

            // Validate memory recall

            infixExpression = "(R)";

            // Act
            request = OnlineCalculatorAppTestFactory.CreateHttpRequest(userName, infixExpression);
            response = (OkObjectResult)await OnlineCalculatorApp.OnlineCalculator.Run(request, logger);

            // Assert
            Assert.Equal(string.Format(ErrorMessages.ExpressionEvaluationSuccess, userName, infixExpression, expectedResult), response.Value);

        }

        /// <summary>
        /// Validate the operation on memory recall functionality.
        /// </summary>
        [Fact]
        public async void ValidateOperationOnMemoryRecall()
        {
            // Setup
            string userName = "Balaji";
            string infixExpression = "(4+2)*4/2-2";
            long expectedResult = 10;

            // Act
            var request = OnlineCalculatorAppTestFactory.CreateHttpRequest(userName, infixExpression);
            var response = (OkObjectResult)await OnlineCalculatorApp.OnlineCalculator.Run(request, logger);

            // Assert
            Assert.Equal(string.Format(ErrorMessages.ExpressionEvaluationSuccess, userName, infixExpression, expectedResult), response.Value);

            // Validate operation on memory recall
            infixExpression = "( R*2 + 80)";
            expectedResult = 100;

            // Act
            request = OnlineCalculatorAppTestFactory.CreateHttpRequest(userName, infixExpression);
            response = (OkObjectResult)await OnlineCalculatorApp.OnlineCalculator.Run(request, logger);

            // Assert
            Assert.Equal(string.Format(ErrorMessages.ExpressionEvaluationSuccess, userName, infixExpression, expectedResult), response.Value);

        }

        /// <summary>
        /// Validate the memory recall functionality for different users.
        /// </summary>
        [Fact]
        public async void ValidateMemoryRecallForDifferentUsers()
        {
            // Setup
            string userName = "Balaji";
            string infixExpression = "(4+2)*4/2-2";
            long firstUserExpectedResult = 10;

            // Act
            var request = OnlineCalculatorAppTestFactory.CreateHttpRequest(userName, infixExpression);
            var response = (OkObjectResult)await OnlineCalculatorApp.OnlineCalculator.Run(request, logger);

            // Assert
            Assert.Equal(string.Format(ErrorMessages.ExpressionEvaluationSuccess, userName, infixExpression, firstUserExpectedResult), response.Value);

            // Validate operation on memory recall
            userName = "Dabbara";
            infixExpression = "(10*2 + 80)";
            long secondUserExpectedResult = 100;

            // Act
            request = OnlineCalculatorAppTestFactory.CreateHttpRequest(userName, infixExpression);
            response = (OkObjectResult)await OnlineCalculatorApp.OnlineCalculator.Run(request, logger);

            // Assert
            Assert.Equal(string.Format(ErrorMessages.ExpressionEvaluationSuccess, userName, infixExpression, secondUserExpectedResult), response.Value);

            // Validate operation on memory recall user1
            userName = "Balaji";
            infixExpression = "(R)";
            long firstUserExpectedMemoryRecallResult = 10;

            // Act
            request = OnlineCalculatorAppTestFactory.CreateHttpRequest(userName, infixExpression);
            response = (OkObjectResult)await OnlineCalculatorApp.OnlineCalculator.Run(request, logger);

            // Assert
            Assert.Equal(string.Format(ErrorMessages.ExpressionEvaluationSuccess, userName, infixExpression, firstUserExpectedMemoryRecallResult), response.Value);


            // Validate operation on memory recall on user2
            userName = "Dabbara";
            infixExpression = "(R)";
            long secondUserExpectedMemoryRecallResult = 100;

            // Act
            request = OnlineCalculatorAppTestFactory.CreateHttpRequest(userName, infixExpression);
            response = (OkObjectResult)await OnlineCalculatorApp.OnlineCalculator.Run(request, logger);

            // Assert
            Assert.Equal(string.Format(ErrorMessages.ExpressionEvaluationSuccess, userName, infixExpression, secondUserExpectedMemoryRecallResult), response.Value);



        }
    }
}
