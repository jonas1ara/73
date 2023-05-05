#include <iostream>
#include <string>
#include <vector>

int M, N;
std::vector<std::vector<int>> m;
int dfs(std::string &s, std::string &p, int i, int j)
{
    if (m[i][j] != 0)
        return m[i][j];
    while (i < M && j < N)
    {
        if (j + 1 < N && p[j + 1] == '*')
        {
            do
            {
                m[i][j] = dfs(s, p, i, j + 2);
                if (m[i][j] == 1)
                    return 1;
                if (p[j] == '.' || s[i] == p[j])
                    ++i;
                else
                    return m[i][j] = -1;
            } while (i < M);
        }
        else
        {
            if (p[j] != '.' && s[i] != p[j])
                return m[i][j] = -1;
            ++i, ++j;
        }
    }
    if (i == M)
    {
        while (j + 1 < N && p[j + 1] == '*')
            j += 2;
    }
    return i == M && j == N ? 1 : -1;
}

bool isMatch(std::string s, std::string p)
{
    M = s.size(), N = p.size();
    m.assign(M + 1, std::vector<int>(N + 1));
    return dfs(s, p, 0, 0) == 1;
}

int main()
{
    std::string s = "aa";
    std::string p = "a";

    std::cout << "Input: s = " << s << ", p = " << p << std::endl;

    std::cout << "Output: " << (isMatch(s, p) ? "true" : "false") << std::endl;

    return 0;
}