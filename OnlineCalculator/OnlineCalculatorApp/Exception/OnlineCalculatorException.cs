using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// OnlineAppCalculatorException class
    /// </summary>
    public class OnlineCalculatorException : System.Exception
    {
        public static string message;
        public OnlineCalculatorException() : base(message: message)
        {

        }
    }

    /// <summary>
    /// Invalid expression exception
    /// </summary>
    public class InvlalidExpressionException : OnlineCalculatorException
    {

    }
}
