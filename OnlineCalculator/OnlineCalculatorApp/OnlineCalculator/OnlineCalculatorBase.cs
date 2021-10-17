using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// Online calculator abstract base class
    /// </summary>
    abstract class OnlineCalculatorBase
    {
        public abstract CalculatorType CalculatorType { get; }
        public abstract IExpressionEvaluator ExpressionEvaluator { get; set; }
        public abstract ISessionManager SessionManager { get; set; }
        public abstract IMemoryManager MemoryManager { get; set; }
        public abstract IUserContext UserContext { get; set; }
        public abstract long Eval(string infixExpression);
    }
}
