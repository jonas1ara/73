#include <stdio.h>
#include <string.h>

int lengthOfLongestSubstring(char *s)
{
    if (s == NULL || *s == '\0')
        return 0;

    int map[256];
    memset(map, -1, sizeof(map));

    int maxLen = 0;
    int lastRepeatPos = -1;
    for (int i = 0; i < strlen(s); i++)
    {
        if (map[s[i]] != -1 && lastRepeatPos < map[s[i]])
            lastRepeatPos = map[s[i]];
        if (maxLen < i - lastRepeatPos)
            maxLen = i - lastRepeatPos;
        map[s[i]] = i;
    }

    return maxLen;
}

int main()
{
    char *input = "abcabcbb"; // Cambia la cadena de entrada según tus necesidades

    int result = lengthOfLongestSubstring(input);

    printf("Longitud de la subcadena más larga sin caracteres repetidos: %d\n", result);

    return 0;
}
