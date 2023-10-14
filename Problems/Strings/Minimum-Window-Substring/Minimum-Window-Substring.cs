using System;
using System.Collections.Generic;
public class Solution {
    public string MinWindow(string s, string t) {
        int[] cnt = new int[128];
        foreach (char c in t) {
            cnt[c]++;
        }

        int N = s.Length;
        int i = 0, j = 0, start = -1, minLen = int.MaxValue, matched = 0;

        while (j < N) {
            if (cnt[s[j]] > 0) {
                matched++;
            }
            cnt[s[j]]--;
            j++;

            while (matched == t.Length) {
                if (j - i < minLen) {
                    minLen = j - i;
                    start = i;
                }

                if (cnt[s[i]] == 0) {
                    matched--;
                }
                cnt[s[i]]++;
                i++;
            }
        }

        return start == -1 ? "" : s.Substring(start, minLen);
    }
    public static void Main(string[] args) {
        Solution solution = new Solution();

        string s = "ADOBECODEBANC";
        string t = "ABC";

        string result = solution.MinWindow(s, t);

        Console.WriteLine("Ventana mínima: " + result);
    }
}
