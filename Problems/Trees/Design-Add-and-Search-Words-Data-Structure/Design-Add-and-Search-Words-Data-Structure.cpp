#include <iostream>
#include <string>

struct TrieNode
{
    TrieNode *next[26] = {};
    bool end = false;
};

class WordDictionary
{
private:
    TrieNode root;

    bool dfs(TrieNode *node, std::string &word, int i)
    {
        if (!node)
            return false;
        if (i == word.size())
            return node->end;
        if (word[i] != '.')
            return dfs(node->next[word[i] - 'a'], word, i + 1);
        for (int j = 0; j < 26; ++j)
        {
            if (dfs(node->next[j], word, i + 1))
                return true;
        }
        return false;
    }

public:
    void addWord(std::string word)
    {
        auto node = &root;
        for (char c : word)
        {
            if (!node->next[c - 'a'])
                node->next[c - 'a'] = new TrieNode();
            node = node->next[c - 'a'];
        }
        node->end = true;
    }

    bool search(std::string word)
    {
        return dfs(&root, word, 0);
    }
};

int main()
{
    // Ejemplo de uso
    WordDictionary wordDictionary;
    wordDictionary.addWord("bad");
    wordDictionary.addWord("dad");
    wordDictionary.addWord("mad");

    bool param_1 = wordDictionary.search("pad"); // Debería ser false
    bool param_2 = wordDictionary.search("bad"); // Debería ser true
    bool param_3 = wordDictionary.search(".ad"); // Debería ser true
    bool param_4 = wordDictionary.search("b.."); // Debería ser true

    // Mostrar resultados
    std::cout << "Search('pad'): " << param_1 << std::endl;
    std::cout << "Search('bad'): " << param_2 << std::endl;
    std::cout << "Search('.ad'): " << param_3 << std::endl;
    std::cout << "Search('b..'): " << param_4 << std::endl;

    return 0;
}
