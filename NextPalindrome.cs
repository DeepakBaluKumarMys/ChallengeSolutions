using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter the first Palindrome:");
                Console.WriteLine(nextPalindrome(Convert.ToInt64(Console.ReadLine())));
            }
            Console.Read();
        }

        private static long nextPalindrome(long firstPalindrome)
        {
            long result = 0;
            int length = firstPalindrome.ToString().Length;
            bool isEven = false;

            if (length / 2 == 0)
            {
                return 11;
            }

            int lhs;

            if (length % 2 == 0) isEven = true;

            if (isEven) { lhs = Convert.ToInt32(firstPalindrome.ToString().Substring(0, (length / 2))); }
            else { lhs = Convert.ToInt32(firstPalindrome.ToString().Substring(0, (length / 2) + 1)); }

            List<char> strLhsArr = lhs.ToString().ToList();
            strLhsArr.Reverse();
            //for odd
            if (!isEven)
            {
                strLhsArr.RemoveAt(0);
            }
            result = Convert.ToInt64(string.Concat(lhs.ToString(), new string(strLhsArr.ToArray())));
            if (result <= firstPalindrome)
            {

                int newLhs = lhs + 1;

                List<char> strArr = newLhs.ToString().ToList();
                strArr.Reverse();

                //for odd
                if (!isEven || (newLhs.ToString().Length > lhs.ToString().Length))
                {
                    strArr.RemoveAt(0);
                }
                result = Convert.ToInt64(string.Concat(newLhs.ToString(), new string(strArr.ToArray())));
            }
            return result;
        }
    }
}
