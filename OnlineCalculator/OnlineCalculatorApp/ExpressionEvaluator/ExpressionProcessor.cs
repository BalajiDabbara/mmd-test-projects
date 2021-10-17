using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{

    /// <summary>
    /// The ExpressionProcessor class
    /// </summary>
    public class ExpressionProcessor : IExpressionProcessor
    {
        /// <summary>
        /// Validate whether the input expression has balanced paranthesis.
        /// </summary>
        /// <param name="inputString">The input infix string</param>
        /// <returns>Returns true if expression is balanced otherwise false.</returns>
        private bool AreParanthesisBalanced(string inputString)
        {
            int openCount = 0;
            int closedCount = 0;

            for (int i = 0; i < inputString.Length; i++)
            {
                if(CalculatorHelper.IsOpeningParenthesis(inputString[i]))
                {
                    openCount++;
                }
                else if (CalculatorHelper.IsClosingParenthesis(inputString[i]))
                {
                    closedCount++;
                }
            }

            return (openCount == closedCount)  ? true : false;
        }

        /// <summary>
        /// Sanitizes the input expression
        /// </summary>
        /// <param name="inputExpression">The input expression</param>
        /// <returns>The sanitized expression</returns>
        public string SanitizeExpression(string inputExpression)
        {
            inputExpression = inputExpression.Replace(" ", "");
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

            if (string.IsNullOrEmpty(inputString))
            {
                return false;
            }
            else if (!AreParanthesisBalanced(inputString))
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
