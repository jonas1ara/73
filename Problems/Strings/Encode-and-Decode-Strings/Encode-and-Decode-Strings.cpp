#include <iostream>
#include <vector>
#include <string>

class Solution
{
public:
    std::string encode(std::vector<std::string> &strs)
    {
        std::string ans;
        for (std::string &str : strs)
        {
            for (char c : str)
            {
                if (c == '$')
                    ans.push_back(c);
                ans.push_back(c);
            }
            ans.push_back('$');
            ans.push_back('x');
        }
        return ans;
    }
    std::vector<std::string> decode(std::string s)
    {
        std::vector<std::string> ans;
        int i = 0, N = s.size();
        while (i < N)
        {
            std::string str;
            for (; i < N; ++i)
            {
                if (s[i] != '$')
                    str.push_back(s[i]);
                else if (i + 1 < N && s[i + 1] == '$')
                    str.push_back(s[i++]);
                else
                {
                    i += 2;
                    break;
                }
            }
            ans.push_back(str);
        }
        return ans;
    }
};

int main()
{
    Solution solution;
    std::vector<std::string> originalStrings = {"lint", "code", "love", "you"};

    // Codificar las cadenas
    std::string encoded = solution.encode(originalStrings);
    std::cout << "Cadena codificada: " << encoded << std::endl;

    // Decodificar la cadena codificada
    std::vector<std::string> decodedStrings = solution.decode(encoded);

    // Imprimir las cadenas decodificadas
    std::cout << "Cadenas decodificadas:" << std::endl;
    for (const std::string &str : decodedStrings)
    {
        std::cout << str;
    }
    std::cout << std::endl;

    return 0;
}
