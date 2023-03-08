/* Hash Map*/

#include <iostream>
#include <vector>

int lengthOfLongestSubstring(std::string s);

int main()
{
    std::string s = "bbbac";

    std::cout << "Input: '" << s << "'" << std::endl;

    std::cout << "Output: " << lengthOfLongestSubstring(s) << std::endl;

    std::cin.get();
}

int lengthOfLongestSubstring(std::string s)
{
    int ans = 0, start = -1; //start es el indice del primer caracter de la subcadena sin repetir
    //Crear un vector de 128 posiciones con el valor -1 que servira para almacenar el indice de la ultima ocurrencia de cada caracter
    std::vector<int> m(128, -1);

    for (int i = 0; i < s.size(); ++i)
    {
        //Si el caracter actual se ha repetido, actualizar el indice del primer caracter de la subcadena sin repetir
        start = std::max(start, m[s[i]]); 

        //Actualizar el indice de la ultima ocurrencia del caracter actual
        m[s[i]] = i;        

        //Actualizar el valor de la longitud de la subcadena sin repetir
        ans = std::max(ans, i - start); 
    } 
    return ans;
}
