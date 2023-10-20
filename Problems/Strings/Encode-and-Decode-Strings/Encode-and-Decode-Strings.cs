using System;
using System.Collections.Generic;

public class Solution
{
    public string Encode(List<string> strs)
    {
        string ans = string.Empty;
        foreach (string str in strs)
        {
            foreach (char c in str)
            {
                if (c == '$')
                    ans += c;
                ans += c;
            }
            ans += '$';
            ans += 'x';
        }
        return ans;
    }

    public List<string> Decode(string s)
    {
        List<string> ans = new List<string>();
        int i = 0;
        int N = s.Length;

        while (i < N)
        {
            string str = string.Empty;

            for (; i < N; ++i)
            {
                if (s[i] != '$')
                {
                    str += s[i];
                }
                else if (i + 1 < N && s[i + 1] == '$')
                {
                    str += s[i++];
                }
                else
                {
                    i += 2;
                    break;
                }
            }
            ans.Add(str);
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        List<string> originalStrings = new List<string> { "lint", "code", "love", "you" };

        // Codificar las cadenas
        string encoded = solution.Encode(originalStrings);
        Console.WriteLine("Cadena codificada: " + encoded);

        // Decodificar la cadena codificada
        List<string> decodedStrings = solution.Decode(encoded);

        // Imprimir las cadenas decodificadas
        Console.WriteLine("Cadenas decodificadas:");
        foreach (string str in decodedStrings)
        {
            Console.WriteLine(str);
        }
    }
}
