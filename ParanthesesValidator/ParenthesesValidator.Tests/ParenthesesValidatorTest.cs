using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ParenthesesValidator.Tests
{
    [TestClass]
    public class ParenthesesValidatorTest
    {
        private readonly ParenthesesValidator parenthesesValidator;
        Mock<ILogger> mockLogger;


        public ParenthesesValidatorTest()
        {
            parenthesesValidator = new ParenthesesValidator();
            mockLogger  = new Mock<ILogger>();
        }

        [TestMethod]
        public void ValidateLongestLengthOfAllInputWithSequentialBalancedParentheses()
        {
            // Setup
            string inputString = "()()";
            int expectedLength = 4;

            // Act
            int actualLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, mockLogger.Object);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }

        [TestMethod]
        public void ValidateLongestLengthOfAllInputWithInnerBalancedParentheses()
        {
            // Setup
            string inputString = "(((())))";
            int expectedLength = 8;

            // Act
            int actualLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, mockLogger.Object);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }

        [TestMethod]
        public void ValidateLongestLengthOfParanthesesWithStartingOpenParantheses()
        {
            // Setup
            string inputString = "(((()";
            int expectedLength = 2;

            // Act
            int actualLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, mockLogger.Object);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }

        [TestMethod]
        public void ValidateLongestLengthOfParanthesesWithStartingClosedParantheses()
        {
            // Setup
            string inputString = "))(((()";
            int expectedLength = 2;

            // Act
            int actualLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, mockLogger.Object);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }

        [TestMethod]
        public void ValidateLongestLengthOfParanthesesWithAllClosedParantheses()
        {
            // Setup
            string inputString = ")))))";
            int expectedLength = 0;

            // Act
            int actualLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, mockLogger.Object);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }


        [TestMethod]
        public void ValidateLongestLengthOfParanthesesWithAllOpenParantheses()
        {
            // Setup
            string inputString = "((((((";
            int expectedLength = 0;

            // Act
            int actualLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, mockLogger.Object);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }

        [TestMethod]
        public void ValidateLongestLengthOfParanthesesForEmptyStringIsZero()
        {
            // Setup
            string inputString = " ";
            int expectedLength = 0;

            // Act
            int actualLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, mockLogger.Object);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }


        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void ValidateLongestLengthOfParanthesesForInvalidCharacters()
        {
            // Setup
            string inputString = "1234)))()";

            // Act
            int actualLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, mockLogger.Object);

        }
    }
}
