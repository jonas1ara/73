using System;
using System.Collections.Generic;
using System.Linq;

IList<IList<string>> GroupAnagrams(string[] strs)
{
    var mapping = new Dictionary<string, IList<string>>();

    var key = string.Empty;
    char[] ch;
    foreach (var str in strs)
    {
        ch = str.ToCharArray();
        Array.Sort(ch);
        key = new string(ch);
        if (!mapping.ContainsKey(key))
        {
            mapping.Add(key, new List<string>());
        }
        mapping[key].Add(str);
    }

    var result = new List<IList<string>>();
    foreach (var pair in mapping)
    {
        result.Add(pair.Value.OrderBy(s => s).ToList());
    }
    return result;
}