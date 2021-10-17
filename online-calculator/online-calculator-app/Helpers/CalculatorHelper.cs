using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    static class CalculatorHelper
    {
        public static bool IsNumber(char inputChar)
        {
            return inputChar >= Constants.ASCII_ZERO && inputChar <= Constants.ASCII_NINE;
        }
        public static bool IsOpeningParenthesis(char inputChar)
        {
            return inputChar == Constants.OPEN_PARANTHESIS;
        }

        public static bool IsClosingParenthesis(char inputChar)
        {
            return inputChar == Constants.CLOSE_PARANTHESIS;
        }

        public static int GetNumberFromChar(char inputChar)
        {
            return (int)(inputChar - Constants.ASCII_ZERO);
        }
        public static string GetStringFromChar(char inputChar)
        {
            return inputChar.ToString();
        }

        internal static bool IsOperator(char inputChar)
        {
            string operatorString = Constants.OPERATORS_STRING;
            return operatorString.IndexOf(inputChar) >= 0;
        }

        internal static bool IsOpeningWhiteSpace(char inputChar)
        {
            return string.IsNullOrEmpty(inputChar.ToString());
        }

        internal static bool IsMemoryRecall(char inputChar)
        {
            return inputChar == 'R';
        }
        internal static bool IsMemorySave(char inputChar)
        {
            return inputChar == 'S';
        }
    }
}
