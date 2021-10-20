using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParenthesesValidator
{
    /// <summary>
    /// ParenthesesValidator Class
    /// </summary>
    public class ParenthesesValidator : IParenthesesValidator
    {
        /// <summary>
        /// To get the length of the longest well formed parantheses
        /// Runs in O(n) time complexity with O(n) space.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>The logest length of valid parentheses</returns>
        public int GetLengthOfLongestWellFormedParantheses(string inputString, ILogger logger)
        {

            int maxLength = 0;

            logger.LogInformation("GetLengthOfLongestWellFormedParantheses() : Start");

            inputString = SanitizeInputString(inputString);

            if(inputString.Length == 0)
            {
                return maxLength;
            }

            if (!this.IsValidInputString(inputString))
            {
                string errorMessage = string.Format(ErrorMessages.InvallidInputString, inputString);
                logger.LogError(errorMessage);
                throw new InvalidInputException(errorMessage);
            }

            Stack<char> parenthesesStack = new Stack<char>();

            for (int idx = 0; idx < inputString.Length; idx++)
            {
                int currentLength = 0;

                switch (inputString[idx])
                {
                    case Constants.OPEN_PARANTHESIS:
                        {
                            // To count the length of sequence of parenthese like ()()()()
                            while (idx < inputString.Length - 1 &&
                                   inputString[idx] == Constants.OPEN_PARANTHESIS &&
                                   inputString[idx + 1] == Constants.CLOSE_PARANTHESIS)
                            {
                                currentLength += 2;
                                idx += 2;
                            }

                            // If there is no immidiate closing parentheses after open parenthese then
                            // push it to stack and search for corresponding closing one.
                            // For e.g. ((((())))
                            if (idx < inputString.Length)
                                parenthesesStack.Push(inputString[idx]);

                            break;
                        }

                    case Constants.CLOSE_PARANTHESIS:
                        {
                            // Pop all openinig parentheses for every closing one and cout lenght
                            while (parenthesesStack.Count != 0)
                            {
                                currentLength += 2;
                                parenthesesStack.Pop();
                            }

                            break;
                        }

                }
                // Get maximum length till now
                maxLength = Math.Max(currentLength, maxLength);
            }

            logger.LogInformation("GetLengthOfLongestWellFormedParantheses() : End");

            return maxLength;
        }

        /// <summary>
        /// Sanitize input string for white spaces
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private string  SanitizeInputString(string inputString)
        {
            return inputString.Replace(Constants.WHITE_SPACES, "");
        }

        /// <summary>
        /// Validate input string.
        /// </summary>
        /// <param name="paranthesesString"></param>
        /// <returns>true or false</returns>
        public bool IsValidInputString(string paranthesesString)
        {
            bool isInputStringValid = true;

            for (int idx = 0; idx < paranthesesString.Length; idx++)
            {
                if (paranthesesString[idx] != Constants.OPEN_PARANTHESIS)
                {
                    if (paranthesesString[idx] != Constants.CLOSE_PARANTHESIS)
                    {
                        isInputStringValid = false;
                        break;
                    }
                }

            }

            return isInputStringValid;
        }
    }
}
