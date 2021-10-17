using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    public class MemoryManager : IMemoryManager
    {
        public CalculatorMemory calcMemory { get; set; }

        public MemoryManager(CalculatorMemory calcMemory)
        {
            this.calcMemory = calcMemory;
        }
        public long RecallMemory(CalculatorMemory calcMemory)
        {
            if(calcMemory != null && calcMemory.MemoryStack != null && calcMemory.MemoryStack.Count > 0)
                return calcMemory.MemoryStack.Pop();
            return 0;
        }

        public CalculatorMemory UpdateMemory(long result)
        {
            if (calcMemory.MemoryStack == null)
            {
                calcMemory.MemoryStack = new Stack<long>();
                calcMemory.MemoryStack.Push(result);
            }
            else
            {
                calcMemory.MemoryStack.Push(result);
            }
            return calcMemory;
        }
    }
}
