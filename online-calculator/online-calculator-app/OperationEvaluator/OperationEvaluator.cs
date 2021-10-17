using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    class OperationEvaluator : IOperationEvaluator
    {
        public long Add(long operand1, long operand2)
        {
            return operand1 + operand2;
        }

        public long Divide(long operand1, long operand2)
        {
            return operand1 / operand2;
        }

        public long Multiply(long operand1, long operand2)
        {
            return operand1 * operand2;
        }

        public long Subtract(long operand1, long operand2)
        {
            return operand1 - operand2;
        }
    }
}
