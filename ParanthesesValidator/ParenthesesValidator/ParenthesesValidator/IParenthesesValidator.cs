using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParenthesesValidator
{/// <summary>
/// 
/// </summary>
    interface IParenthesesValidator
    {
        /// <summary>
        /// Get the longest length of valid parentheses
        /// </summary>
        /// <param name="paranthesesString"></param>
        /// <returns></returns>
        public int GetLengthOfLongestWellFormedParantheses(string paranthesesString, ILogger logger);

        /// <summary>
        /// Validate input string
        /// </summary>
        /// <param name="paranthesesString"></param>
        /// <returns></returns>
        public bool IsValidInputString(string paranthesesString);
    }
}
