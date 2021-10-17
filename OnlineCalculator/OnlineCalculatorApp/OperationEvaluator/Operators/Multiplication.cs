using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The Multiplication operator.
    /// </summary>
    public class Multiplication : Operator
    {
        public override char OperatorChar
        {
            get
            {
                return Constants.MULTIPLICATION;
            }
        }
        public override OperationPrecedence OperatorPrecedence
        {
            get
            {
                return OperationPrecedence.Multiplication;
            }
        }

        public override OperatorType OperatorType
        {
            get
            {
                return OperatorType.Binary;
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
