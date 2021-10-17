using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    public class Addition : Operator
    {
        public override char OperatorChar
        {
            get
            {
                return Constants.PLUS;
            }
        }
        public override int OperatorPrecedence
        {
            get
            {
                return (int)OperationPrecedence.Addition;
            }
        }
        public long LeftOperand { get; set; }

        public long RightOperand { get; set; }

        public long Result { get; set; }

        public Addition()
        {
        }
        public Addition(long leftOperand, long rightOperand)
        {
            this.LeftOperand = leftOperand;
            this.RightOperand = rightOperand;
        }

        public override long ExecuteOperation()
        {
            return (LeftOperand + RightOperand);
        }
    }
}
