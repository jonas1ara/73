#include <iostream>
#include <string>

struct TrieNode {
    TrieNode* next[26] = {};
    bool word = false;
};

class Trie {
private:
    TrieNode root;

    TrieNode* find(std::string& word) {
        auto node = &root;
        for (char c : word) {
            if (!node->next[c - 'a'])
                return nullptr;
            node = node->next[c - 'a'];
        }
        return node;
    }

public:
    void insert(std::string word) {
        auto node = &root;
        for (char c : word) {
            if (!node->next[c - 'a'])
                node->next[c - 'a'] = new TrieNode();
            node = node->next[c - 'a'];
        }
        node->word = true;
    }

    bool search(std::string word) {
        auto node = find(word);
        return node && node->word;
    }

    bool startsWith(std::string prefix) {
        return find(prefix) != nullptr;
    }
};

int main() {
    // Ejemplo de uso
    Trie obj;
    obj.insert("apple");
    bool param_2 = obj.search("apple");
    bool param_3 = obj.startsWith("app");

    // Mostrar resultados
    std::cout << "Search('apple'): " << param_2 << std::endl; // Debería ser true
    std::cout << "StartsWith('app'): " << param_3 << std::endl; // Debería ser true

    return 0;
}
