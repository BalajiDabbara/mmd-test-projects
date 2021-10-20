using System;
using System.Collections.Generic;
using System.Text;

namespace ParenthesesValidator
{
    /// <summary>
    /// ParenthesesValidatorException class
    /// </summary>
    /// 
    [Serializable]
    public class ParenthesesValidatorException : Exception
    {
        public string ErrorMessage { get; set; }
        public ParenthesesValidatorException() : base()
        {
        }
        public ParenthesesValidatorException(string message) : base(message: message)
        {
            ErrorMessage = message;
        }
        public ParenthesesValidatorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParenthesesValidatorException(System.Runtime.Serialization.SerializationInfo info,
           System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


}
