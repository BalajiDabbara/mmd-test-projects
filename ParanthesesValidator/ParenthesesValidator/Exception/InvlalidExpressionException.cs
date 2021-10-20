using System;

namespace ParenthesesValidator
{
    /// <summary>
    /// Invalid input exception
    /// </summary>
    /// 
    [Serializable]
    public class InvalidInputException : ParenthesesValidatorException
    {

        public InvalidInputException(): base()
        {
        }
        public InvalidInputException(string message) : base(message: message)
        {
            ErrorMessage = message;
        }

        public InvalidInputException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidInputException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
