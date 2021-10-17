using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The Subtraction operator.
    /// </summary>
    public class Subtraction : Operator
    {
        public override char OperatorChar
        {
            get
            {
                return Constants.MINUS;
            }
        }
        public override int OperatorPrecedence
        {
            get
            {
                return (int)OperationPrecedence.Subtraction;
            }
        }
        public long LeftOperand { get; set; }

        public long RightOperand { get; set; }

        public long Result { get; set; }

        public Subtraction()
        {
        }
        public Subtraction(long leftOperand, long rightOperand)
        {
            this.LeftOperand = leftOperand;
            this.RightOperand = rightOperand;
        }

        public override long ExecuteOperation()
        {
            return (LeftOperand - RightOperand);
        }
    }
}
