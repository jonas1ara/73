#include <iostream>
#include <string>
#include <vector>

// Using a Trie - Time O(w) for insert, search and startsWith, where w is the length of the word

struct TrieNode
{
    TrieNode *next[26] = {};
    bool word = false;
};

class Trie {
private:
    TrieNode root;

    TrieNode *find(std::string &word)
    {
        auto node = &root;
        for (char c : word)
        {
            if (!node->next[c - 'a'])
            {
                return nullptr;
            }

            node = node->next[c - 'a'];
        }
        
        return node;
    }

public:
    void insert(std::string word)
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

        node->word = true;
    }

    bool search(std::string word)
    {
        auto node = find(word);
        return node && node->word;
    }

    bool startsWith(std::string prefix)
    {
        return find(prefix) != nullptr;
    }
};

std::vector<bool> performOperations(const std::vector<std::string> &operations, const std::vector<std::vector<std::string>> &inputs)
{
    Trie obj;
    std::vector<bool> results;

    for (size_t i = 0; i < operations.size(); ++i)
    {
        if (operations[i] == "Trie")
        {
            obj = Trie(); 
            results.push_back(false); 
        }
        else if (operations[i] == "insert")
        {
            obj.insert(inputs[i][0]);
            results.push_back(false); 
        }
        else if (operations[i] == "search")
        {
            results.push_back(obj.search(inputs[i][0]));
        }
        else if (operations[i] == "startsWith")
        {
            results.push_back(obj.startsWith(inputs[i][0]));
        }
    }

    return results;
}


int main()
{
    std::vector<std::string> operations = {"Trie", "insert", "search", "search", "startsWith", "insert", "search"};
    std::vector<std::vector<std::string>> inputs = {{}, {"apple"}, {"apple"}, {"app"}, {"app"}, {"app"}, {"app"}};

    std::vector<bool> results = performOperations(operations, inputs);

    for (size_t i = 0; i < results.size(); i++)
    {
        std::cout << "Operation: " << operations[i];
        if (!inputs[i].empty())
        {
            std::cout << ", Input: " << inputs[i][0];
        }

        if (operations[i] == "Trie")
        {
            std::cout << ", Result: Trie initialized." << std::endl;
        }
        else if (operations[i] == "insert")
        {
            std::cout << ", Result: null" << std::endl;
        }
        else if (operations[i] == "search")
        {
            std::cout << ", Result: " << (results[i] ? "True" : "False") << std::endl;
        }
        else if (operations[i] == "startsWith")
        {
            std::cout << ", Result: " << (results[i] ? "True" : "False") << std::endl;
        }
    }

    return 0;
}
