# Container With Most Water

Se le da una `altura` de un arreglo de enteros de longitud `n`. Hay `n` líneas verticales dibujadas de manera que los dos extremos de la `i-ésima` línea son `(i, 0)` y `(i, altura[i])`.

Encuentra dos rectas que junto con el eje x formen un recipiente, tal que el recipiente contenga la mayor cantidad de agua.

Devolver la máxima cantidad de agua que puede almacenar un recipiente.

**Tenga en cuenta que no puede inclinar el contenedor.**

![Container with Most Water](/Sources/Arreglos/CwMW.jpg)

Para la solución de este problema tenemos dos enfoques uno es el de **fuerza bruta** y el otro es usar la estrategía de **dos punteros**.

## Lenguaje C++

### Solución con fuerza bruta O(n²)

```cpp
class Solution {
public:
    int maxArea(std::vector<int> &A)
    {
        int N = A.size(), ans = 0;
        for (int i = 0; i < N; ++i)
        {
            if (!A[i])
                continue;
            for (int j = i + 1 + ans / A[i]; j < N; ++j)
            {
                ans = std::max(ans, std::min(A[i], A[j]) * (j - i));
            }
        }
        return ans;
    }
};
```

### Solución con dos punteros O(n)


```cpp
class Solution {
public:
    int maxArea(std::vector<int> &A)
    {
        int ans = 0, L = 0, R = A.size() - 1;
        while (L < R)
        {
            ans = std::max(ans, (R - L) * std::min(A[L], A[R]));
            if (A[L] < A[R])
                ++L; // Mover el borde más pequeño
            else
                --R;
        }
        return ans;
    }
};
```
