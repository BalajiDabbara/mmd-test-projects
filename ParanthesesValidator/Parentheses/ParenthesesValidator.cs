using System;
using System.Collections.Generic;
using System.Text;

namespace Parentheses
{
    public class ParenthesesValidator : IParenthesesValidator
    {
        public int GetLenghtOfLongestWellFormedParantheses(string inputString)
        {
            int maxLength = 0;
            Stack<char> parenthesesStack = new Stack<char>();

            for (int idx = 0; idx < inputString.Length; idx++)
            {
                int currentLength = 0;

                if (inputString[idx] == Constants.OPEN_PARANTHESIS)
                {
                    while (idx < inputString.Length - 1 &&
                        inputString[idx] == Constants.OPEN_PARANTHESIS &&
                        inputString[idx + 1] == Constants.CLOSE_PARANTHESIS)
                    {
                        currentLength += 2;
                        idx += 2;
                    }
                    
                    if(idx < inputString.Length)
                        parenthesesStack.Push(inputString[idx]);
                }
                else if (inputString[idx] == Constants.CLOSE_PARANTHESIS)
                {
                    while (parenthesesStack.Count != 0)
                    {
                        currentLength += 2;
                        parenthesesStack.Pop();
                    }
                }
                maxLength = Math.Max(currentLength, maxLength);
            }

            return maxLength;
        }

        public bool IsParenthesesValid()
        {
            throw new NotImplementedException();
        }

        public void ValidateParentheses()
        {
            throw new NotImplementedException();
        }
    }
}
