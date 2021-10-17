using System;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// Invalid expression exception
    /// </summary>
    /// 
    [Serializable]
    public class InvlalidExpressionException : OnlineCalculatorException
    {

        public InvlalidExpressionException(): base()
        {
        }
        public InvlalidExpressionException(string message) : base(message: message)
        {
            ErrorMessage = message;
        }

        public InvlalidExpressionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvlalidExpressionException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
