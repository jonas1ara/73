using System;
using System.Collections.Generic;
using System.Linq;
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

        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string[] input = { "eat", "tea", "tan", "ate", "nat", "bat" }; // Cambia las cadenas de entrada según tus necesidades

        IList<IList<string>> result = solution.GroupAnagrams(input);

        Console.WriteLine("Grupos de anagramas:");

        foreach (IList<string> group in result)
        {
            Console.Write("[ ");
            foreach (string word in group)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine("]");
        }
    }
}