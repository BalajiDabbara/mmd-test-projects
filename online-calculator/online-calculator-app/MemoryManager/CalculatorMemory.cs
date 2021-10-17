using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    public class CalculatorMemory
    {
        public Stack<long> MemoryStack { get; set; }

        public int Level { get; set; } = 1;

        public CalculatorMemory()
        {
            this.MemoryStack = new Stack<long>();
        }

        public CalculatorMemory(int level, Stack<long> memoryStack)
        {
            this.Level = level;
            this.MemoryStack = memoryStack;
        }
    }
}
