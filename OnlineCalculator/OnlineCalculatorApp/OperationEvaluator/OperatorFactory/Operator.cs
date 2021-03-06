using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The operator abstract class.
    /// </summary>
    public abstract class Operator
    {
        /// <summary>
        /// The operator character
        /// </summary>
        public abstract char OperatorChar { get; }

        /// <summary>
        /// The operation precedence.
        /// </summary>
        public abstract OperationPrecedence OperatorPrecedence { get; }

        /// <summary>
        /// The operation type.
        /// </summary>
        public abstract OperatorType OperatorType { get; }

        /// <summary>
        /// Execute operation.
        /// </summary>
        /// <returns>The operation result</returns>
        public abstract long ExecuteOperation();
    }
}
