using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    public class ExpressionProcessor : IExpressionProcessor
    {
        public string SanitizeExpression(string inputExpression)
        {
            inputExpression = inputExpression.Replace(" ", "");
            inputExpression = "(" + inputExpression + ")";
            return inputExpression;
        }

        public bool ValidateExpression(string inputString)
        {
            return true;
        }
    }
}
