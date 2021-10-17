using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    interface IExpressionEvaluator
    {
        public long EvaluateInfixExpression(string postFixExpression, long memoryResult);
    }
}
