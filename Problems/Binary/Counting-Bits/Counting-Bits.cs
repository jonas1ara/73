using System;

//  Using dynamic programming - Time: O(n)
public class Solution
{
    public int[] CountBits(int n)
    {
        int[] ans = new int[n + 1];

        for (int i = 1; i <= n; i *= 2)
        {
            ans[i] = 1;
            
            for (int j = 1; j < i && i + j <= n; j++)
                ans[i + j] = ans[i] + ans[j];
        }

        return ans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int n = 5;
        Console.WriteLine("Input: n = " + n);

        Solution sol = new Solution();
        int[] ans = sol.CountBits(n);

        Console.WriteLine("Output: [" + string.Join(", ", ans) + "]");
    }
}
