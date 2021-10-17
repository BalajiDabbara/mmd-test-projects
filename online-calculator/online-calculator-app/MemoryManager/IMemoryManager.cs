using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    public interface IMemoryManager
    {
        public CalculatorMemory UpdateMemory(long result);

        public long RecallMemory(CalculatorMemory calcMemory);
    }
}
