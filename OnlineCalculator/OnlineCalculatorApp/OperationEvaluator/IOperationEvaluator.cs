using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The operation evaluator interface.
    /// </summary>
    interface IOperationEvaluator
    {
        long Add(long operand1, long operand2);
        long Subtract(long operand1, long operand2);
        long Multiply(long operand1, long operand2);
        long Divide(long operand1, long operand2);
    }
}
