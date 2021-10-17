using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    public interface IExpressionProcessor
    {
        public string SanitizeExpression(string inputString);
        public bool ValidateExpression(string inputString);
    }
}
