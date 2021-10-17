using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    abstract class OnlineCalculatorBase
    {
        public abstract CalculatorType CalculatorType { get; }
        public abstract IExpressionEvaluator ExpressionEvaluator { get; set; }
        public abstract ISessionManager EessionManager { get; set; }
        public abstract IMemoryManager MemoryManager { get; set; }
        public abstract IUserContext UserContext { get; set; }
        public abstract long Eval(string infixExpression);
    }
}
