# Problema

Dado un arreglo de números enteros llamado `nums` y un objetivo entero llamado `target`, devuelve índices de los dos números de modo que sumen el objetivo.
Puede suponer que cada entrada tendría exactamente una solución, no puede usar el mismo elemento dos veces y puede devolver la respuesta en cualquier orden.

Restricciones:
- `2 <= nums.length <= 10⁴`
- `10⁹ <= nums[i] <= 10⁹`
- `10⁹ <= target <= 10⁹`
- Solo hay una respuesta para cada entrada

Para la solución de este problema tenemos dos enfoques uno es el de **fuerza bruta** y el otro es el de usar una **tabla de hash**.

## Lenguaje C++

### Solución con tabla de hash O(n)

En este código, además de la biblioteca `vector` se utiliza la biblioteca `map` que nos permite utilizar `std::map` para almacenar los elementos del vector `nums` y sus respectivos índices.

En el bucle for, se itera a través de los elementos del vector `nums`. Para cada elemento, se calcula el complemento `t` necesario para alcanzar el objetivo target. Luego, se verifica si el complemento `t` ya está presente en el mapa utilizando la función `map.count()`. Si se encuentra, significa que hemos encontrado una pareja de números que suma el objetivo, por lo que se devuelve un nuevo vector que contiene los índices del complemento y del elemento actual.

Si no se encuentra ninguna pareja de números, se agrega el elemento actual al mapa con su índice correspondiente para futuras comprobaciones. Al final del bucle, si no se ha encontrado ninguna pareja, se devuelve un vector vacío `return {}`.

Este enfoque tiene una complejidad de tiempo de **O(n)**, ya que se realiza solo un recorrido lineal del vector `nums`. Además, utiliza una tabla de hash `std::map` para realizar búsquedas eficientes en tiempo constante.

```cpp
std::vector<int> twoSum(std::vector<int> &nums, int target)
{
    std::map<int, int> map;
    for (int i = 0; i < nums.size(); ++i)
    {
        int t = target - nums[i];
        if (map.count(t))
            return {map[t], i}; // Devolvemos el índice del complemento y el índice actual
        map[nums[i]] = i; // Agregamos el elemento actual a la tabla hash
    }
    return {}; // En caso de que no se encuentre retornar un array vacío
}
```
