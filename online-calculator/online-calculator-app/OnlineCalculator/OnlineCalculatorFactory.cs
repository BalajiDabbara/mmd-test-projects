using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    abstract class OnlineCalculatorFactory
    {
        public abstract OnlineCalculatorBase GetCalculator();
    }
}
