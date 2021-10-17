using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// OnlineCalculatorFactory class.
    /// </summary>
    abstract class OnlineCalculatorFactory
    {
        /// <summary>
        /// Return online calculator.
        /// </summary>
        /// <returns></returns>
        public abstract OnlineCalculatorBase GetCalculator();
    }
}
