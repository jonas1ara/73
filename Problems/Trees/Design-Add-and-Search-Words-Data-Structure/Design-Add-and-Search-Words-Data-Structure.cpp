#include <iostream>
#include <string>
#include <vector>

// Using a Trie - Time: AddWord: O(n) and Search: O(m)

struct TrieNode
{
    TrieNode *next[26] = {};
    bool end = false;
};

class WordDictionary {
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
            
        for (int j = 0; j < 26; j++)
        {
            if (dfs(node->next[j], word, i + 1))
            {
                return true;
            }
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
            {
                node->next[c - 'a'] = new TrieNode();
            }
            node = node->next[c - 'a'];
        }
        node->end = true;
    }

    bool search(std::string word)
    {
        return dfs(&root, word, 0);
    }
};

std::vector<bool> performOperations(const std::vector<std::string> &operations, const std::vector<std::vector<std::string>> &inputs)
{
    WordDictionary *wordDictionary = nullptr;
    std::vector<bool> results;

    for (int i = 0; i < operations.size(); i++)
    {
        if (operations[i] == "WordDictionary")
        {
            wordDictionary = new WordDictionary();
            results.push_back(false);
        }
        else if (operations[i] == "addWord")
        {
            wordDictionary->addWord(inputs[i][0]);
            results.push_back(false);
        }
        else if (operations[i] == "search")
        {
            results.push_back(wordDictionary->search(inputs[i][0]));
        }
    }

    return results;
}

int main()
{
    std::vector<std::string> operations = {"WordDictionary", "addWord", "addWord", "addWord", "search", "search", "search", "search"};
    std::vector<std::vector<std::string>> inputs = {{}, {"bad"}, {"dad"}, {"mad"}, {"pad"}, {"bad"}, {".ad"}, {"b.."}};

    std::vector<bool> results = performOperations(operations, inputs);

    for (int i = 0; i < results.size(); i++)
    {
        std::cout << "Operation: " << operations[i];
        if (!inputs[i].empty())
        {
            std::cout << ", Input: " << inputs[i][0];
        }

        if (operations[i] == "WordDictionary")
        {
            std::cout << ", Result: null" << std::endl;
        }
        else if (operations[i] == "addWord")
        {
            std::cout << ", Result: null" << std::endl;
        }
        else if (operations[i] == "search")
        {
            std::cout << ", Result: " << (results[i] ? "true" : "false") << std::endl;
        }
    }

    return 0;
}