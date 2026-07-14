# Implement Trie (Prefix Tree):

This directory contains an implementation of the "Implement Trie (Prefix Tree)" problem in C#. Each operation runs in `O(w)` time where `w` is the length of the word or prefix.

## Problem description

A trie (pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings.

Implement the `Trie` class:

- `Trie()` Initializes the trie object
- `void insert(String word)` Inserts the string `word` into the trie
- `boolean search(String word)` Returns `true` if `word` is in the trie (i.e., was inserted before), and `false` otherwise
- `boolean startsWith(String prefix)` Returns `true` if there is a previously inserted string `word` that has the prefix `prefix`, and `false` otherwise

- Example 1:

```
Input
["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
[[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
Output
[null, null, true, false, true, null, true]

Explanation
Trie trie = new Trie();
trie.insert("apple");
trie.search("apple");   // return True
trie.search("app");     // return False
trie.startsWith("app"); // return True
trie.insert("app");
trie.search("app");     // return True
```

## Solution:

Each `TrieNode` holds:

- `Next[26]` — children for letters `a`–`z`
- `Word` / `word` — whether a complete word ends at this node

**Insert:** walk character by character; create missing nodes; mark the final node as a word end.

**Find:** walk the path for a string; return the terminal node or `null` if a link is missing.

**Search:** `Find(word) != null` and the end flag is set.

**StartsWith:** `Find(prefix) != null` (end flag not required).

## Implementations:

### C# :

```csharp
// Using a Trie - Time O(w) for insert, search and startsWith

public class TrieNode
{
    public TrieNode[] Next { get; } = new TrieNode[26];
    public bool Word { get; set; }
}

public class Trie
{
    private TrieNode root = new TrieNode();

    private TrieNode Find(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            if (node.Next[c - 'a'] == null)
            {
                return null;
            }
            node = node.Next[c - 'a'];
        }
        return node;
    }

    public void Insert(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            if (node.Next[c - 'a'] == null)
            {
                node.Next[c - 'a'] = new TrieNode();
            }
            node = node.Next[c - 'a'];
        }
        node.Word = true;
    }

    public bool Search(string word)
    {
        var node = Find(word);
        return node != null && node.Word;
    }

    public bool StartsWith(string prefix)
    {
        return Find(prefix) != null;
    }
}
```

1. Index children with `c - 'a'`.

2. Shared `Find` powers both `Search` and `StartsWith`.
