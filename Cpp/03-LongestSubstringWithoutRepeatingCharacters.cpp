#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

int lengthOfLongestSubstring(std::string s)
{
    int ans = 0;                 // Variable para almacenar la longitud de la subcadena más larga sin caracteres repetidos
    int start = -1;              // Índice del inicio de la subcadena actual
    std::vector<int> m(128, -1); // Vector para almacenar el índice más reciente de cada carácter ASCII en la cadena

    for (int i = 0; i < s.size(); i++)
    {
        start = std::max(start, m[s[i]]); // Actualiza el inicio de la subcadena si se encuentra un carácter repetido

        ans = std::max(ans, i - start); // Calcula la longitud de la subcadena actual y la compara con la longitud máxima anterior

        m[s[i]] = i; // Actualiza el índice más reciente del carácter en el vector
    }

    return ans; // Devuelve la longitud de la subcadena más larga sin caracteres repetidos
}

int main()
{
    std::string s = "abcabcbb";
    std::cout << "Input: '" << s << "'" << std::endl;

    std::cout << "Output: " << lengthOfLongestSubstring(s) << std::endl;

    std::cin.get();
}
