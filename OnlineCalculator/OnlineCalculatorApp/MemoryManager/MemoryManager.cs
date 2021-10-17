using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// Memoery manager class.
    /// </summary>
    public class MemoryManager : IMemoryManager
    {
        /// <summary>
        /// Calculator memory property
        /// </summary>
        public CalculatorMemory calcMemory { get; set; }

        /// <summary>
        /// The MemoryManager contructor
        /// </summary>
        /// <param name="calcMemory"></param>
        public MemoryManager(CalculatorMemory calcMemory)
        {
            this.calcMemory = calcMemory;
        }

        /// <summary>
        /// Recalls the memory.
        /// </summary>
        /// <param name="calcMemory">The calculator memory.</param>
        /// <returns></returns>
        public long RecallMemory(CalculatorMemory calcMemory)
        {
            if(calcMemory != null && calcMemory.MemoryStack != null && calcMemory.MemoryStack.Count > 0)
                return calcMemory.MemoryStack.Pop();
            return 0;
        }

        /// <summary>
        /// Updates the memory stack
        /// </summary>
        /// <param name="result">The calculator memory</param>
        /// <returns></returns>
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
