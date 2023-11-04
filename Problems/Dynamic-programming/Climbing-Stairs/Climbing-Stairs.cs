
using System;
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

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int n = 5; // Puedes cambiar este valor a la cantidad de escaleras que desees calcular.
        int result = solution.ClimbStairs(n);
        Console.WriteLine("Número de formas de subir " + n + " escaleras: " + result);
    }
}
