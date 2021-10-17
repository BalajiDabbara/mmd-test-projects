using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The Division operator
    /// </summary>
    public class Division : Operator
    {
        public override char OperatorChar
        {
            get
            {
                return Constants.DIVISION;
            }
        }
        public override int OperatorPrecedence
        {
            get
            {
                return (int)OperationPrecedence.Division;
            }
        }
        public long LeftOperand { get; set; }

        public long RightOperand { get; set; }

        public long Result { get; set; }

        public Division()
        {
        }
        public Division(long leftOperand, long rightOperand)
        {
            this.LeftOperand = leftOperand;
            this.RightOperand = rightOperand;
        }

        public override long ExecuteOperation()
        {
            return (LeftOperand / RightOperand);
        }
    }
}
