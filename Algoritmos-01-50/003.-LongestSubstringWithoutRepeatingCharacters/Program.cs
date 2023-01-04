using System;
using System.Collections.Generic;

int LengthOfLongestSubstring(string s)
{
        if (string.IsNullOrEmpty(s)) return 0;

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

string s = "abcabcbb";
Console.WriteLine("Input: s = \"{0}\"", s);
Console.WriteLine("Longest Substring Without Repeating Characters: " + LengthOfLongestSubstring(s));
