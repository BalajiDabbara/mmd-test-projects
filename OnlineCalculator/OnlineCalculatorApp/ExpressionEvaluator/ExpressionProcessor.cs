using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OnlineCalculatorApp
{

    /// <summary>
    /// The ExpressionProcessor class
    /// </summary>
    public class ExpressionProcessor : IExpressionProcessor
    {
        /// <summary>
        /// Is valid numbers 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool IsInputStringHasInValidChars(string input)
        {
            string alloweCharRegEx = Environment.GetEnvironmentVariable("ALLOWED_INPUT_CHARACTERS");

            // For unit tests purpose, keeping regular expression ([^[0-9-/*+R()]]*) in constants.
            alloweCharRegEx = string.IsNullOrEmpty(alloweCharRegEx) ? Constants.ALLOWED_INPUTCHARS : alloweCharRegEx;
            return Regex.IsMatch(input, alloweCharRegEx);
        }
        /// <summary>
        /// Validate whether the input expression has balanced paranthesis.
        /// </summary>
        /// <param name="inputString">The input infix string</param>
        /// <returns>Returns true if expression is balanced otherwise false.</returns>
        private bool AreParanthesisBalanced(string inputString)
        {
            Stack<char> openParenthesesStack = new Stack<char>();
            bool isExpressionBalanced = true;

            if (IsInputStringHasInValidChars(inputString))
                return false;

            for (int i = 0; i < inputString.Length; i++)
            {
                switch (inputString[i])
                {
                    case Constants.OPEN_PARANTHESIS:
                        openParenthesesStack.Push(inputString[i]);
                        break;
                    case Constants.CLOSE_PARANTHESIS:
                        {
                            if (openParenthesesStack.Count == 0)
                                isExpressionBalanced = false;
                            else
                                openParenthesesStack.Pop();
                            break;
                        }
                }

                if (!isExpressionBalanced)
                    return false;
            }

            return isExpressionBalanced;
        }

        /// <summary>
        /// Sanitizes the input expression
        /// </summary>
        /// <param name="inputExpression">The input expression</param>
        /// <returns>The sanitized expression</returns>
        public string SanitizeExpression(string inputExpression)
        {
            inputExpression = inputExpression.Replace(" ", "");
            if (inputExpression[0] == Constants.MINUS)
                inputExpression = "0" + inputExpression;
            inputExpression = "(" + inputExpression + ")";
            return inputExpression;
        }

        /// <summary>
        /// Validates expression string.
        /// </summary>
        /// <param name="inputString">The input expression string</param>
        /// <returns>Returns true if expression is valid otherwise false.</returns>
        public bool ValidateExpression(string inputString)
        {
            return string.IsNullOrEmpty(inputString) || !AreParanthesisBalanced(inputString) ? false : true;
        }
    }
}
