using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// Teh Expression tree node class
    /// </summary>
    class ExprTreeNode
    {
        public string data;
        public ExprTreeNode left, right;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">Node data</param>
        public ExprTreeNode(string data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
}
