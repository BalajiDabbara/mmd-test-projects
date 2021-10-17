using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    class SimpleOnlineCalculatorFactory : OnlineCalculatorFactory
    {
        private IExpressionEvaluator expressionEvaluator;
        private ISessionManager sessionManager;
        private IMemoryManager memoryManager;
        private IUserContext userContext;

        public SimpleOnlineCalculatorFactory
               (IExpressionEvaluator expressionEval,
               IMemoryManager memoryManager,
               ISessionManager sessionManager,
               IUserContext userContext)
        {
            this.expressionEvaluator = expressionEval;
            this.sessionManager = sessionManager;
            this.memoryManager = memoryManager;
            this.userContext = userContext;
        }


        public override OnlineCalculatorBase GetCalculator()
        {
            return new SimpleOnlineCalculator(this.expressionEvaluator, this.memoryManager, this.sessionManager, this.userContext);
        }
    }
}
