using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// OnlineAppCalculatorException class
    /// </summary>
    /// 
    [Serializable]
    public class OnlineCalculatorException : Exception
    {
        public string ErrorMessage { get; set; }
        public OnlineCalculatorException() : base()
        {
        }
        public OnlineCalculatorException(string message) : base(message: message)
        {
            ErrorMessage = message;
        }
        public OnlineCalculatorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OnlineCalculatorException(System.Runtime.Serialization.SerializationInfo info,
           System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


}
