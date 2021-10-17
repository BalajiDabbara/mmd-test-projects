using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// Calculator helper calss.
    /// </summary>
    static class CalculatorHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        public static bool IsNumber(char inputChar)
        {
            return inputChar >= Constants.ASCII_ZERO && inputChar <= Constants.ASCII_NINE;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        public static bool IsOpeningParenthesis(char inputChar)
        {
            return inputChar == Constants.OPEN_PARANTHESIS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        public static bool IsClosingParenthesis(char inputChar)
        {
            return inputChar == Constants.CLOSE_PARANTHESIS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        public static int GetNumberFromChar(char inputChar)
        {
            return (int)(inputChar - Constants.ASCII_ZERO);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        public static string GetStringFromChar(char inputChar)
        {
            return inputChar.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        internal static bool IsOperator(char inputChar)
        {
            string operatorString = Constants.OPERATORS_STRING;
            return operatorString.IndexOf(inputChar) >= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        internal static bool IsOpeningWhiteSpace(char inputChar)
        {
            return string.IsNullOrEmpty(inputChar.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        internal static bool IsMemoryRecall(char inputChar)
        {
            return inputChar == 'R';
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        internal static bool IsMemorySave(char inputChar)
        {
            return inputChar == 'S';
        }
    }
}
