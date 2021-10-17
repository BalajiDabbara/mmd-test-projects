using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    class ExprTreeNode
    {
        public string data;
        public ExprTreeNode left, right;

        public ExprTreeNode(string data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
}
