using System;

namespace Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            ParenthesesValidator parenthesesValidator = new ParenthesesValidator();
            int longestLength = 0;
            string inputString = "(()";
            inputString = "())))(((()";
            inputString = ")))()()";
            inputString = ")))()()(()()()()()";
            inputString = "((()))";
            inputString = "((((";
            inputString = ")))";

            longestLength = parenthesesValidator.GetLenghtOfLongestWellFormedParantheses(inputString);
            Console.WriteLine($"The longest valid parentheses length in {inputString} is {longestLength} ");

            #region Continuous input testing.
            //while (inputString != "Exit")
            //{
            //    Console.WriteLine("Please enter your input string");
            //    inputString = Console.ReadLine();

            //    switch (inputString)
            //    {
            //        case "Exit":
            //            break;

            //        case "Clear":
            //            Console.Clear();
            //            break;

            //        default:
            //            {
            //                longestLength = parenthesesValidator.GetLenghtOfLongestWellFormedParantheses(inputString);
            //                Console.WriteLine($"The longest valid parentheses lenght in {inputString} is {longestLength} ");
            //                break;
            //            }
            //    }

            //}
        #endregion

            Console.WriteLine("End");
        }
    }
}
