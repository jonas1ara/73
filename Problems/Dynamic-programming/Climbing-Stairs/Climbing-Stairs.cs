using System;

// Using bottom-up approach - Time: O(n)

public class Solution
{
    public int ClimbStairs(int n)
    {
        int ans = 1;
        int prev = 1;

        while (--n > 0)
        {
            int temp = ans;
            ans += prev;
            prev = temp;
        }

        return ans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int n = 5;

        Console.WriteLine("Input: " + n);

        Solution sol = new Solution();
        int result = sol.ClimbStairs(n);

        Console.WriteLine("Output: " + result);
    }
}