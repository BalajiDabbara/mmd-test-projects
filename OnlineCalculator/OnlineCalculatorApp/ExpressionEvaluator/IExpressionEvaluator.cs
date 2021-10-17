using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// Expression evaluator interface.
    /// </summary>
    interface IExpressionEvaluator
    {
        /// <summary>
        /// To evaluate infix expressions
        /// </summary>
        /// <param name="postFixExpression">The post fix expression</param>
        /// <param name="memoryResult">The memory result</param>
        /// <returns>Result</returns>
        public long EvaluateInfixExpression(string postFixExpression, long memoryResult);
    }
}
