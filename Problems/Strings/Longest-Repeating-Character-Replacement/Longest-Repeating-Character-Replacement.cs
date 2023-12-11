using System;
using System.Collections.Generic;

// Using sliding window technique - Time: O(n)
public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        int i = 0;
        int j = 0;
        int[] cnt = new int[26];
        int n = s.Length;
        
        while (j < n)
        {
            cnt[s[j] - 'A']++;
            j++;
            
            if (j - i - maxElement(cnt, 26) > k)
            {
                cnt[s[i] - 'A']--;
                i++;
            }
        }
        
        return j - i;
    }
    private int maxElement(int[] arr, int length)
    {
        int max = arr[0];
        for (int i = 1; i < length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string s = "ABAB";
        int k = 2;

        Console.WriteLine("Input: s = " + s + ", k = " + k);

        Solution sol = new Solution();
        int result = sol.CharacterReplacement(s, k);

        Console.WriteLine("Output: " + result);
    }
}
