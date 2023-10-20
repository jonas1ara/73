public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        int[] cnt = new int[26];
        foreach (char c in s)
        {
            cnt[c - 'a']++;
        }

        foreach (char c in t)
        {
            cnt[c - 'a']--;
        }

        foreach (int n in cnt)
        {
            if (n != 0)
            {
                return false;
            }
        }

        return true;
    }
}
