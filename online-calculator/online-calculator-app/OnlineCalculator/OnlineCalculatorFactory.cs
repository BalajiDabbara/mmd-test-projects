using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    abstract class OnlineCalculatorFactory
    {
        public abstract OnlineCalculatorBase GetCalculator();
    }
}
