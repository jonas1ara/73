using System;

// Using hash map - Time: O(n)
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        var map = new Dictionary<int, int>();
        var maxLen = 0;
        var lastRepeatPos = -1;

        for (int i = 0; i < s.Length; i++)
        {
            if (map.ContainsKey(s[i]) && lastRepeatPos < map[s[i]])
                lastRepeatPos = map[s[i]];
            if (maxLen < i - lastRepeatPos)
                maxLen = i - lastRepeatPos;
            map[s[i]] = i;
        }

        return maxLen;
    }
}

class Program
{
    static void Main(string[] args)
    {

        string input = "abcabcbb";
        Console.WriteLine("Input: " + input);

        Solution solution = new Solution();
        int result = solution.LengthOfLongestSubstring(input);

        Console.WriteLine("Output: " + result);
    }
}

