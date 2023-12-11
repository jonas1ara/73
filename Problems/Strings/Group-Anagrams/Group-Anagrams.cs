using System;
using System.Linq;
using System.Collections.Generic;

// Using hash map - Time complexity: O(NKlogK), where N is the length of strs, and K is the maximum length of a string in strs.
public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, int> m = new Dictionary<string, int>();
        List<IList<string>> ans = new List<IList<string>>();

        for (int i = 0; i < strs.Length; i++)
        {
            string s = strs[i];
            string key = new string(s.ToCharArray());
            char[] keyChars = key.ToCharArray();
            Array.Sort(keyChars);
            key = new string(keyChars);

            if (!m.ContainsKey(key))
            {
                m[key] = ans.Count;
                ans.Add(new List<string>());
            }

            ans[m[key]].Add(s);
        }

        ans.Reverse();
        return ans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        // Ejemplo de uso:
        string[] input = { "eat", "tea", "tan", "ate", "nat", "bat" };
        Console.Write("Input: strs = ["); 
        Console.Write(string.Join(", ", input));
        Console.WriteLine("]");

        Solution sol = new Solution();
        IList<IList<string>> result = sol.GroupAnagrams(input);

        Console.Write("Output: [");
        foreach (var group in result)
        {
            Console.Write("[" + string.Join(", ", group) + "]");
            if (group != result.Last())
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");
    }
}