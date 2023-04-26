#include <iostream>
#include <vector>

int lengthOfLongestSubstring(std::string s)
{
    int answer = 0, start = -1; //ans = longitud de la subcadena sin repetir, start = indice del primer caracter de la subcadena sin repetir
        
    std::vector<int> m(128, -1); //m = vector de 128 posiciones, cada una con valor -1

    for (int i = 0; i < s.size(); ++i) //ciclo para recorrer el string, no el vector e i = indice del caracter actual de la cadena
    {
        start = std::max(start, m[s[i]]);   //m[s[i]] = indice del caracter actual de la cadena en el vector m y reconoce cuando un caracter se repite en la cadena, 

        answer = std::max(answer, i - start); 

        m[s[i]] = i;  //Asigna el indice del caracter actual de la cadena en el vector m
    } 
    return answer;
}

int main()
{
    std::string s = "abba";

    std::cout << "Input: '" << s << "'" << std::endl;

    std::cout << "Output: " << lengthOfLongestSubstring(s) << std::endl;

    std::cin.get();
}


