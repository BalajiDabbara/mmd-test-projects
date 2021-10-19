using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parentheses;

namespace Parentheses.Tests
{
    [TestClass]
    public class ParenthesesValidatorTest
    {
        private readonly ParenthesesValidator parenthesesValidator;

        public ParenthesesValidatorTest()
        {
            parenthesesValidator = new ParenthesesValidator();
        }

        [TestMethod]
        public void ValidateLongestLengthOfAllInputWithSequentialBalancedParentheses()
        {
            // Setup
            string inputString = "()()";
            int expectedLength = 4;
            int actualLength = 0;

            // Act
            actualLength = parenthesesValidator.GetLenghtOfLongestWellFormedParantheses(inputString);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }

        [TestMethod]
        public void ValidateLongestLengthOfAllInputWithInnerBalancedParentheses()
        {
            // Setup
            string inputString = "(((())))";
            int expectedLength = 8;
            int actualLength = 0;

            // Act
            actualLength = parenthesesValidator.GetLenghtOfLongestWellFormedParantheses(inputString);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }

        [TestMethod]
        public void ValidateLongestLengthOfParanthesesWithStartingOpenParantheses()
        {
            // Setup
            string inputString = "(((()";
            int expectedLength = 2;
            int actualLength = 0;

            // Act
            actualLength = parenthesesValidator.GetLenghtOfLongestWellFormedParantheses(inputString);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }

        [TestMethod]
        public void ValidateLongestLengthOfParanthesesWithStartingClosedParantheses()
        {
            // Setup
            string inputString = "))(((()";
            int expectedLength = 2;
            int actualLength = 0;

            // Act
            actualLength = parenthesesValidator.GetLenghtOfLongestWellFormedParantheses(inputString);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }

        [TestMethod]
        public void ValidateLongestLengthOfParanthesesWithAllClosedParantheses()
        {
            // Setup
            string inputString = ")))))";
            int expectedLength = 0;
            int actualLength = 0;

            // Act
            actualLength = parenthesesValidator.GetLenghtOfLongestWellFormedParantheses(inputString);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }


        [TestMethod]
        public void ValidateLongestLengthOfParanthesesWithAllOpenParantheses()
        {
            // Setup
            string inputString = "((((((";
            int expectedLength = 0;
            int actualLength = 0;

            // Act
            actualLength = parenthesesValidator.GetLenghtOfLongestWellFormedParantheses(inputString);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);

        }
    }
}
