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

        /// <summary>
        /// Set up
        /// </summary>
        public ParenthesesValidatorTest()
        {
            parenthesesValidator = new ParenthesesValidator();
            mockLogger  = new Mock<ILogger>();
        }

        /// <summary>
        /// Test for sequential balanced parentheses
        /// </summary>
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

        /// <summary>
        /// Test for inner balanced parentheses
        /// </summary>
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

        /// <summary>
        /// Test for starting with multiple open parentheses
        /// </summary>
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

        /// <summary>
        /// Test for starting closed parentheses
        /// </summary>
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

        /// <summary>
        /// Test for all closed parentheses
        /// </summary>
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


        /// <summary>
        /// Test for all open parentheses
        /// </summary>
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

        /// <summary>
        /// Test for empty string
        /// </summary>
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

        /// <summary>
        /// Test for numbers
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void ValidateLongestLengthOfParanthesesForInvalidCharacters()
        {
            // Setup
            string inputString = "1234)))()";

            // Act
            int actualLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, mockLogger.Object);

        }

        /// <summary>
        /// Test for alphabets
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void ValidateLongestLengthOfParanthesesForAlphabets()
        {
            // Setup
            string inputString = "absd()))()";

            // Act
            int actualLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, mockLogger.Object);

        }

        /// <summary>
        /// Test for brackests
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void ValidateLongestLengthOfParanthesesForInvalidBraces()
        {
            // Setup
            string inputString = "[][][()))()";

            // Act
            int actualLength = parenthesesValidator.GetLengthOfLongestWellFormedParantheses(inputString, mockLogger.Object);

        }
    }
}
