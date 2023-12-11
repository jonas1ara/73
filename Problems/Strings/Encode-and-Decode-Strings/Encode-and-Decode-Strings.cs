using System;
using System.Collections.Generic;

// Using string manipulation - Time: O(n)
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

    public List<string> Decode(string str)
    {
        List<string> ans = new List<string>();
        int i = 0;
        int n = str.Length;

        while (i < n)
        {
            string s = string.Empty;

            for (; i < n; i++)
            {
                if (str[i] != '$')
                {
                    s += str[i];
                }
                else if (i + 1 < n && str[i + 1] == '$')
                {
                    s += str[i++];
                }
                else
                {
                    i += 2;
                    break;
                }
            }
            ans.Add(s);
        }

        return ans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<string> strs = new List<string> { "lint", "code", "love", "you" };

        Console.Write("Input: [");
        foreach (string str in strs)
        {
            Console.Write(str + " ");
            if (str != strs[strs.Count - 1])
                Console.Write(", ");
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        string encoded = sol.Encode(strs);

        // Console.WriteLine("Encoded String: " + encoded);
        
        List<string> decodedStrings = sol.Decode(encoded);

        Console.Write("Output: [");
        foreach (string dstr in decodedStrings)
        {
            Console.Write(dstr + " ");
            if (dstr != decodedStrings[decodedStrings.Count - 1])
                Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}
