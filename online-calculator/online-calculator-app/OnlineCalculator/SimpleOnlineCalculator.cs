using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    internal class SimpleOnlineCalculator : OnlineCalculatorBase
    {
        private readonly CalculatorType calculatorType;
        private IExpressionEvaluator expressionEvaluator;
        private ISessionManager sessionManager;
        private IMemoryManager memoryManager;
        private IUserContext userContext;

        public override CalculatorType CalculatorType 
        {
            get
            {
                return calculatorType;
            }
        }

        public override IExpressionEvaluator ExpressionEvaluator 
        {
            get
            {
                return expressionEvaluator;
            }
                 
            set
            {
                value = expressionEvaluator;
            }
        }
        public override ISessionManager EessionManager
        {
            get
            {
                return sessionManager;
            }

            set
            {
                value = sessionManager;
            }
        }
        public override IMemoryManager MemoryManager
        {
            get
            {
                return memoryManager;
            }

            set
            {
                value = memoryManager;
            }
        }
        public override IUserContext UserContext
        {
            get
            {
                return userContext;
            }

            set
            {
                value = userContext;
            }
        }

        //private IExpressionEvaluator expressionEvaluator;
        //private ISessionManager sessionManager;
        //private IMemoryManager memoryManager;
        //private IUserContext userContext;

        public SimpleOnlineCalculator
                (IExpressionEvaluator expressionEval,
                IMemoryManager memoryManager,
                ISessionManager sessionManager,
                IUserContext userContext)
        {
            this.calculatorType = CalculatorType.Simple;
            this.expressionEvaluator = expressionEval;
            this.sessionManager = sessionManager;
            this.memoryManager = memoryManager;
            this.userContext = userContext;
        }

        //public long Eval()
        //{
        //    string userId = userContext.UserName;
        //    CalculatorMemory calcMemory = sessionManager.GetSessionData(userId);
        //    long memoryResult = memoryManager.RecallMemory(calcMemory);
        //    long result = expressionEvaluator.EvaluateInfixExpression(this.InfixExpression, memoryResult);
        //    calcMemory = memoryManager.UpdateMemory(result);
        //    sessionManager.UpdateSessionData(userId, calcMemory);
        //    return result;
        //}

        public override long Eval(string infixExpression)
        {
            string userId = userContext.UserName;
            CalculatorMemory calcMemory = sessionManager.GetSessionData(userId);
            long memoryResult = memoryManager.RecallMemory(calcMemory);
            long result = expressionEvaluator.EvaluateInfixExpression(infixExpression, memoryResult);
            calcMemory = memoryManager.UpdateMemory(result);
            sessionManager.UpdateSessionData(userId, calcMemory);
            return result;
        }
    }
}
