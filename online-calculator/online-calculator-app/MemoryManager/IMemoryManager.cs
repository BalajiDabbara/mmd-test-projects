using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    public interface IMemoryManager
    {
        public CalculatorMemory UpdateMemory(long result);

        public long RecallMemory(CalculatorMemory calcMemory);
    }
}
