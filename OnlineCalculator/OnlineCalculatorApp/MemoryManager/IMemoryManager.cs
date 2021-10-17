using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// Memoery manager interface.
    /// </summary>
    public interface IMemoryManager
    {
        /// <summary>
        /// Updates the memory stack
        /// </summary>
        /// <param name="result">The calculator memory</param>
        /// <returns></returns>
        public CalculatorMemory UpdateMemory(long result);

        /// <summary>
        /// Recalls the memory.
        /// </summary>
        /// <param name="calcMemory">The calculator memory.</param>
        /// <returns></returns>
        public long RecallMemory(CalculatorMemory calcMemory);
    }
}
