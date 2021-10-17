using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// ExpressionProcessor interface.
    /// </summary>
    public interface IExpressionProcessor
    {
        /// <summary>
        /// Sanitizes the input expression
        /// </summary>
        /// <param name="inputExpression">The input expression</param>
        /// <returns>The sanitized expression</returns>
        public string SanitizeExpression(string inputString);

        /// <summary>
        /// Validates expression string.
        /// </summary>
        /// <param name="inputString">The input expression string</param>
        /// <returns>Returns true if expression is valid otherwise false.</returns>
        public bool ValidateExpression(string inputString);
    }
}
