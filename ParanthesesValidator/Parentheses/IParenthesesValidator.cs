using System;
using System.Collections.Generic;
using System.Text;

namespace Parentheses
{
    interface IParenthesesValidator
    {
        public bool IsParenthesesValid();

        public void ValidateParentheses();

        public int GetLenghtOfLongestWellFormedParantheses(string paranthesesString);
    }
}
