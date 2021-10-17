using System;

namespace Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            
            string parantesesString = "()";

            int longestLength = FindLogestParanthesesLength(parantesesString);

            Console.WriteLine($"Longest paranthese lenght {longestLength}");
            Console.WriteLine("End");
        }

        private static int FindLogestParanthesesLength(string paranthesesString)
        {
            return 0;
        }
    }
}
