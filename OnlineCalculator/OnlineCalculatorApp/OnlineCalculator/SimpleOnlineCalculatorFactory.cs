using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The SimpleOnlineCalculatorFactory class
    /// </summary>
    internal class SimpleOnlineCalculatorFactory : OnlineCalculatorFactory
    {
        private IExpressionEvaluator expressionEvaluator;
        private ISessionManager sessionManager;
        private IMemoryManager memoryManager;
        private IUserContext userContext;
        private ILogger logger;


        /// <summary>
        /// SimpleOnlineCalculatorFactory constructor
        /// </summary>
        /// <param name="expressionEval">Teh expression evaluator.</param>
        /// <param name="memoryManager">The memory manager.</param>
        /// <param name="sessionManager">The session manager</param>
        /// <param name="userContext">The user context</param>
        public SimpleOnlineCalculatorFactory
               (IExpressionEvaluator expressionEval,
               IMemoryManager memoryManager,
               ISessionManager sessionManager,
               IUserContext userContext,
               ILogger logger)
        {
            this.expressionEvaluator = expressionEval;
            this.sessionManager = sessionManager;
            this.memoryManager = memoryManager;
            this.userContext = userContext;
            this.logger = logger;
        }


        /// <summary>
        /// Return SimpleOnlineCalculator object.
        /// </summary>
        /// <returns></returns>
        public override OnlineCalculatorBase GetCalculator()
        {
            return new SimpleOnlineCalculator(this.expressionEvaluator, this.memoryManager, this.sessionManager, this.userContext, this.logger);
        }
    }
}
