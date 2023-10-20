using System;
using System.Collections.Generic;

public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        int i = 0;
        int j = 0;
        int[] cnt = new int[26];
        int N = s.Length;
        
        while (j < N)
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
        for (int index = 1; index < length; index++)
        {
            if (arr[index] > max)
            {
                max = arr[index];
            }
        }
        return max;
    }

    public static void Main(string[] args)
    {
        Solution sol = new Solution();
        string s = "ABAB";
        int k = 2;
        int result = sol.CharacterReplacement(s, k);
        Console.WriteLine(result);
    }
}
