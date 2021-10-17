using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The SimpleOnlineCalculator
    /// </summary>
    internal class SimpleOnlineCalculator : OnlineCalculatorBase
    {
        private readonly CalculatorType calculatorType;
        private IExpressionEvaluator expressionEvaluator;
        private ISessionManager sessionManager;
        private IMemoryManager memoryManager;
        private IUserContext userContext;

        /// <summary>
        /// The CalculatorType
        /// </summary>
        public override CalculatorType CalculatorType 
        {
            get
            {
                return calculatorType;
            }
        }

        /// <summary>
        /// The ExpressionEvaluator
        /// </summary>
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

        /// <summary>
        /// The SessionManager
        /// </summary>
        public override ISessionManager SessionManager
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

        /// <summary>
        /// The MemoryManager
        /// </summary>
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

        /// <summary>
        /// The UserContext
        /// </summary>
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

        /// <summary>
        /// The SimpleOnlineCalculator constructor
        /// </summary>
        /// <param name="expressionEval">Teh expression evaluator.</param>
        /// <param name="memoryManager">The memory manager.</param>
        /// <param name="sessionManager">The session manager</param>
        /// <param name="userContext">The user context</param>
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

        /// <summary>
        /// Evaluates the expression
        /// </summary>
        /// <param name="infixExpression">The input infix expression.</param>
        /// <returns></returns>
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
