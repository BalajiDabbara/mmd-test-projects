using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// Error messages.
    /// </summary>
    public static class ErrorMessages
    {
        public static string ExpressionEvaluationSuccess = "Hello, {0}. Your input expression is successfully evaluated. Result of {1} is : {2}";
        public static string ExpressionEvaluationFailedWithException = "Hello, {0}. Your input expression evaluation is failed. Please ensure that your expression is valid. Exception details : {1}";
        public static string ExpressionEvaluationFailedWithoutException = "Hello, {0}. Your input expression evaluation is failed. Please ensure that your expression is valid.";
        public static string UserNameEmpty = "Please provide valid UserName...!!:(";
    }
}
