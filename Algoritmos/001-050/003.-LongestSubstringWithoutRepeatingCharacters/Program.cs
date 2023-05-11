using System;
using System.Collections.Generic;

namespace LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        public static int LengthOfLongestSubstring(string s)
        {
            // Comprueba si la cadena es nula o vacía
            if (string.IsNullOrEmpty(s)) return 0;

            // Crea un diccionario para almacenar los caracteres y su última posición en la cadena
            var dic = new Dictionary<int, int>();

            // Inicializa la longitud de la subcadena más larga sin caracteres repetidos en 0
            var maxLen = 0;

            // Inicializa la última posición de un carácter repetido en -1
            var lastRepeatPos = -1;

            // Recorre cada carácter en la cadena
            for (int i = 0; i < s.Length; i++)
            {
                // Comprueba si el carácter actual ya está en el diccionario y si su última posición es mayor que lastRepeatPos
                if (dic.ContainsKey(s[i]) && lastRepeatPos < dic[s[i]])
                    // Actualiza lastRepeatPos con la última posición del carácter actual en el diccionario
                    lastRepeatPos = dic[s[i]];

                // Comprueba si la longitud de la subcadena actual sin caracteres repetidos es mayor que maxLen
                if (maxLen < i - lastRepeatPos)
                    // Actualiza maxLen con la longitud de la subcadena actual sin caracteres repetidos
                    maxLen = i - lastRepeatPos;

                // Actualiza el diccionario con el carácter actual y su posición actual en la cadena
                dic[s[i]] = i;
            }

            // Devuelve maxLen, que es la longitud de la subcadena más larga sin caracteres repetidos
            return maxLen;
        }
        static void Main(string[] args)
        {
            string s = " ";
            Console.WriteLine("Input: s = \"{0}\"", s);
            Console.WriteLine("Output: " + LengthOfLongestSubstring(s));
        }
    }
}