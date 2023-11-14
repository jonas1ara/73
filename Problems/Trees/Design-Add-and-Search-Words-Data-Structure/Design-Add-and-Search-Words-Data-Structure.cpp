struct TrieNode {
    TrieNode *next[26] = {};
    bool end = false;
};
class WordDictionary {
    TrieNode root;
    bool dfs(TrieNode *node, string &word, int i) {
        if (!node) return false;
        if (i == word.size()) return node->end;
        if (word[i] != '.') return dfs(node->next[word[i] - 'a'], word, i + 1);
        for (int j = 0; j < 26; ++j) {
            if (dfs(node->next[j], word, i + 1)) return true;
        }
        return false;
    }
public:
    void addWord(string word) {
        auto node = &root;
        for (char c : word) {
            if (!node->next[c - 'a']) node->next[c - 'a'] = new TrieNode();
            node = node->next[c - 'a'];
        }
        node->end = true;
    }
    bool search(string word) {
        return dfs(&root, word, 0);
    }
};

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary* obj = new WordDictionary();
 * obj->addWord(word);
 * bool param_2 = obj->search(word);
 */