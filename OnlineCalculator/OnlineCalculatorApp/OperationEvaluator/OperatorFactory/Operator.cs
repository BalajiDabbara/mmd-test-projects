using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    public abstract class Operator
    {
        public abstract char OperatorChar { get; }
        public abstract int OperatorPrecedence { get; }
        public abstract long ExecuteOperation();
    }
}
