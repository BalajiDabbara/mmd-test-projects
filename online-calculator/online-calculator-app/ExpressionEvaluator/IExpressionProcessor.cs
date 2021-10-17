using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    public interface IExpressionProcessor
    {
        public string SanitizeExpression(string inputString);
        public bool ValidateExpression(string inputString);
    }
}
