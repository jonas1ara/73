using System;

public class Solution
{
    public int NumDecodings(string s)
    {
        int pre2 = 0, pre1 = 1;
        for (int i = 0; i < s.Length && pre1 != 0; ++i)
        {
            int cur = 0;
            if (s[i] != '0')
            {
                cur += pre1;
            }
            if (i != 0 && s[i - 1] != '0' && (s[i - 1] - '0') * 10 + s[i] - '0' <= 26)
            {
                cur += pre2;
            }
            pre2 = pre1;
            pre1 = cur;
        }
        return pre1;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string s = "226"; // Reemplaza "226" con tu cadena de entrada
        int result = solution.NumDecodings(s);
        Console.WriteLine("Número de decodificaciones posibles: " + result);
    }
}
