using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    public class Multiplication : Operator
    {
        public override char OperatorChar
        {
            get
            {
                return Constants.MULTIPLICATION;
            }
        }
        public override int OperatorPrecedence
        {
            get
            {
                return (int)OperationPrecedence.Multiplication;
            }
        }
        public long LeftOperand { get; set; }

        public long RightOperand { get; set; }

        public long Result { get; set; }

        public Multiplication()
        {
        }
        public Multiplication(long leftOperand, long rightOperand)
        {
            this.LeftOperand = leftOperand;
            this.RightOperand = rightOperand;
        }

        public override long ExecuteOperation()
        {
            return (LeftOperand * RightOperand);
        }
    }
}
