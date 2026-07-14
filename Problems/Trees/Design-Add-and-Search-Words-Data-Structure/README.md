# Design Add and Search Words Data Structure:

This directory contains an implementation of the "Design Add and Search Words Data Structure" problem in C#. Words are stored in a trie; search supports the wildcard `.` via DFS with temporal complexity `O(n)` for add and up to `O(26^m)` for search with wildcards (`m` = pattern length).

## Problem description

Design a data structure that supports adding new words and finding if a string matches any previously added string.

Implement the `WordDictionary` class:

- `WordDictionary()` Initializes the object
- `void addWord(word)` Adds `word` to the data structure; it can be matched later
- `bool search(word)` Returns `true` if there is any string in the data structure that matches `word`, or `false` otherwise. `word` may contain dots `.` where dots can be matched with any letter

- Example 1:

```
Input
["WordDictionary","addWord","addWord","addWord","search","search","search","search"]
[[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
Output
[null,null,null,null,false,true,true,true]

Explanation
WordDictionary wordDictionary = new WordDictionary();
wordDictionary.addWord("bad");
wordDictionary.addWord("dad");
wordDictionary.addWord("mad");
wordDictionary.search("pad"); // return False
wordDictionary.search("bad"); // return True
wordDictionary.search(".ad"); // return True
wordDictionary.search("b.."); // return True
```

## Solution:

Same trie as prefix tree, plus wildcard search:

- **AddWord:** walk/create nodes for each letter; mark end of word
- **Search (DFS):**
  - If current char is a letter → follow that single child
  - If current char is `.` → try all 26 children
  - When index reaches word length → success only if `End` is true

For pattern `.ad` after inserting `bad`, `dad`, `mad`:

1. `.` branches over all children
2. First matching path is `b` → `a` → `d` with end flag → `true`

## Implementations:

### C# :

```csharp
// Using a Trie - Time: AddWord: O(n) and Search: O(m)

public class TrieNode
{
    public TrieNode[] Next = new TrieNode[26];
    public bool End = false;
}

public class WordDictionary
{
    private TrieNode root;

    public WordDictionary()
    {
        root = new TrieNode();
    }

    public void AddWord(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            if (node.Next[c - 'a'] == null)
                node.Next[c - 'a'] = new TrieNode();
            node = node.Next[c - 'a'];
        }
        node.End = true;
    }

    private bool Dfs(TrieNode node, string word, int i)
    {
        if (node == null)
            return false;
        if (i == word.Length)
            return node.End;
        if (word[i] != '.')
            return Dfs(node.Next[word[i] - 'a'], word, i + 1);

        for (int j = 0; j < 26; j++)
        {
            if (Dfs(node.Next[j], word, i + 1))
            {
                return true;
            }
        }
        return false;
    }

    public bool Search(string word)
    {
        return Dfs(root, word, 0);
    }
}
```

1. Literal characters follow one edge; `.` fans out to all edges.

2. End-of-word check prevents matching proper prefixes as full words.

## Suggested practice 🎯

Same trie with wildcard search pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Replace Words](https://leetcode.com/problems/replace-words/)
- [Map Sum Pairs](https://leetcode.com/problems/map-sum-pairs/)
- [Design Search Autocomplete System](https://leetcode.com/problems/design-search-autocomplete-system/)
