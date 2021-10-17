using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    interface IOperationEvaluator
    {
        long Add(long operand1, long operand2);
        long Subtract(long operand1, long operand2);
        long Multiply(long operand1, long operand2);
        long Divide(long operand1, long operand2);
    }
}
