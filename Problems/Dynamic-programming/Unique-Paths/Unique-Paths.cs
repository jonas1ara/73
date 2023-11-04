using System;

// Dp
public class Solution
{
    public int UniquePaths(int m, int n)
    {
        int[] dp = new int[n + 1];
        dp[n - 1] = 1;
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                dp[j] += dp[j + 1];
            }
        }
        return dp[0];
    }
}

// Math

// public class Solution {
//     public int UniquePaths(int m, int n) {
//         long ans = 1;
//         for (int i = 1; i <= n - 1; i++) {
//             ans = ans * (m - 1 + i) / i;
//         }
//         return (int)ans; // Asegurarse de devolver un entero en lugar de un long.
//     }
// }

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int result = solution.UniquePaths(3, 3); // Llamando al método UniquePaths
        Console.WriteLine("El número de rutas únicas es: " + result);
    }
}