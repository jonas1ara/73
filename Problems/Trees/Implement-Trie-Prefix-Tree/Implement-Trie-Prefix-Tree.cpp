struct TrieNode {
    TrieNode *next[26] = {};
    bool word = false;
};
class Trie {
    TrieNode root;
    TrieNode *find(string &word) {
        auto node = &root;
        for (char c : word) {
            if (!node->next[c - 'a']) return NULL;
            node = node->next[c - 'a'];
        }
        return node;
    }
public:
    void insert(string word) {
        auto node = &root;
        for (char c : word) {
            if (!node->next[c - 'a']) node->next[c - 'a'] = new TrieNode();
            node = node->next[c - 'a'];
        }
        node->word = true;
    }
    bool search(string word) {
        auto node = find(word);
        return node && node->word;
    }
    bool startsWith(string prefix) {
        return find(prefix);
    }
};