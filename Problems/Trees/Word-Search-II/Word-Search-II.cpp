#include <iostream>
#include <vector>
#include <functional>
#include <algorithm>

// Using Trie - Time: O(m * n * 4^l)

struct TrieNode
{
    TrieNode *next[26] = {};
    int cnt = 0;
    bool end = false;
};

class Solution {
    TrieNode root;
    void addWord(TrieNode *node, std::string &s)
    {
        for (char c : s)
        {
            if (!node->next[c - 'a'])
                node->next[c - 'a'] = new TrieNode();
            node = node->next[c - 'a'];
            node->cnt++;
        }
        node->end = true;
    }

public:
    std::vector<std::string> findWords(std::vector<std::vector<char>> &board, std::vector<std::string> &words)
    {
        for (auto &s : words)
        {
            addWord(&root, s);
        }

        int m = board.size();
        int n = board[0].size(); 
        int dirs[4][2] = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

        std::vector<std::string> ans;
        std::string tmp;

        std::function<int(int, int, TrieNode *)> dfs = [&](int x, int y, TrieNode *node)
        {
            int c = board[x][y] - 'a';
            int cnt = 0;

            if (!node->next[c] || !node->next[c]->cnt)
            {
                return 0;
            }

            node = node->next[c];
            tmp.push_back(board[x][y]);

            if (node->end)
            {
                ans.push_back(tmp);
                cnt++;
                node->end = false;
            }

            board[x][y] = 0;
            
            for (auto &[dx, dy] : dirs)
            {
                int a = x + dx, b = y + dy;
                if (a < 0 || a >= m || b < 0 || b >= n || board[a][b] == 0)
                {
                    continue;
                }
                cnt += dfs(a, b, node);
            }

            board[x][y] = 'a' + c;
            tmp.pop_back();
            node->cnt -= cnt;

            return cnt;
        };

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dfs(i, j, &root);
            }
        }

        std::reverse(ans.begin(), ans.end());
        return ans;
    }
};

void printBoard(const std::vector<std::vector<char>>& board)
{
    for (const auto& row : board)
    {
        std::cout << "[";
        for (char c : row)
        {
            std::cout << c;
            if (c != row.back())
            {
                std::cout << ", ";
            }
        }
        std::cout << "]";
        if (&row != &board.back())
        {
            std::cout << ", ";
        }
    }
}

void printWords(const std::vector<std::string>& words)
{
    for (const std::string& word : words)
    {
        std::cout << word;
        if (&word != &words.back())
        {
            std::cout << ", ";
        }
    }
}

int main()
{
    std::vector<std::vector<char>> board = {
        {'o', 'a', 'a', 'n'},
        {'e', 't', 'a', 'e'},
        {'i', 'h', 'k', 'r'},
        {'i', 'f', 'l', 'v'}
    };
    std::vector<std::string> words = { "oath", "pea", "eat", "rain" };

    std::cout << "Input: board = [";
    printBoard(board);
    std::cout << "], words = [";
    printWords(words);
    std::cout << "]\n";

    Solution sol;
    std::vector<std::string> ans = sol.findWords(board, words);

    std::cout << "Output: [";
    for (const std::string& word : ans)
    {
        std::cout << word;
        if (&word != &ans.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    return 0;
}