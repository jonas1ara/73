using System;

namespace LeetCode
{
    class Program
    {
        public  static bool IsPalindrome(int x)
        {
            if (x < 0) { return false; }
            if (x < 10) { return true; }

            var temp = x;
            var y = 0;
            var digit = 0;
            while (temp != 0)
            {
                digit = temp % 10;
                y = y * 10 + digit;
                temp /= 10;
            }

            return x == y;
        }

        static void Main (string[] args)
        {

            var x = 121;
            Console.WriteLine("Input: " + x);
            var result = IsPalindrome(x);
            Console.WriteLine("Output: " + result);
        }
    }
}
