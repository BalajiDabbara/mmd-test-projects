using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// Calcualtor memory class
    /// </summary>
    public class CalculatorMemory
    {
        /// <summary>
        /// Memory stack.
        /// </summary>
        public Stack<long> MemoryStack { get; set; }

        /// <summary>
        /// Memory level
        /// </summary>
        public int Level { get; set; } = 1;

        /// <summary>
        /// Constructor
        /// </summary>
        public CalculatorMemory()
        {
            this.MemoryStack = new Stack<long>();
        }

        /// <summary>
        /// PArameterized contructor
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="memoryStack">The moery stack.</param>
        public CalculatorMemory(int level, Stack<long> memoryStack)
        {
            this.Level = level;
            this.MemoryStack = memoryStack;
        }
    }
}
