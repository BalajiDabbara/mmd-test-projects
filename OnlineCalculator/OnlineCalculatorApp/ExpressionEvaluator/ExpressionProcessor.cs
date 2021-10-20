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
        private bool IsValidCharatersWithParentheses(string input)
        {
            return Regex.IsMatch(input, @"^[0-9R()]+$");
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

            if (!IsValidCharatersWithParentheses(inputString))
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

            if (string.IsNullOrEmpty(inputString) ||
                !AreParanthesisBalanced(inputString))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
