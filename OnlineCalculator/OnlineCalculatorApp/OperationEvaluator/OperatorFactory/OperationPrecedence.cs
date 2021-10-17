using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The Operation precedence.
    /// </summary>
    public enum OperationPrecedence
    {
        Default = 0,
        Addition = 0,
        Subtraction = 0,
        Multiplication = 1,
        Division = 1
    }
}
