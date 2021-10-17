using System;
using System.Collections.Generic;
using System.Text;

namespace online_calculator_app.Exception
{
    public class OnlineCalculatorException : System.Exception
    {
        public static string message;
        public OnlineCalculatorException() : base(message: message)
        {

        }
    }

    public class InvlalidExpressionException : OnlineCalculatorException
    {

    }
}
