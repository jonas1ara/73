# Two Sum

Dado un arreglo de números enteros llamado `nums` y un objetivo entero llamado `target`, devuelve índices de los dos números de modo que sumen el objetivo.
Puede suponer que cada entrada tendría exactamente una solución, no puede usar el mismo elemento dos veces y puede devolver la respuesta en cualquier orden.

Restricciones:
- `2 <= nums.length <= 10⁴`
- `10⁹ <= nums[i] <= 10⁹`
- `10⁹ <= target <= 10⁹`
- Solo hay una respuesta para cada entrada

Para la solución de este problema tenemos dos enfoques uno es el de **fuerza bruta** y el otro es el de usar una **tabla de hash**.

## Lenguaje C

### Solución con fuerza bruta O(n²)

Para esta implementación se utilizan dos bucles anidados para probar todas las combinaciones posibles de dos números del arreglo `nums`. Si se encuentra una pareja de números que suma el objetivo, se devuelve un arreglo dinámico con los índices de esos números. En caso contrario, se devuelve `NULL` para indicar que no se encontró ninguna pareja.

```c
int* twoSum(int* nums, int numsSize, int target, int* returnSize) 
{
    for (int i = 0; i < numsSize - 1; i++) 
    {
        for (int j = i + 1; j < numsSize; j++) 
        {
            if (nums[i] + nums[j] == target) 
            {
                int* result = (int*) malloc(2 * sizeof(int));
                result[0] = i;
                result[1] = j;
                *returnSize = 2;
                return result;
            }
        }
    }
    *returnSize = 0;

    return NULL;
}
```

### Solución con tabla de hash O(n)

```c
#define SIZE 10000

typedef struct
{
    int key;
    int value;
} HashNode;

typedef struct
{
    HashNode **array;
} HashMap;

HashMap *createHashMap()
{
    HashMap *map = (HashMap *)malloc(sizeof(HashMap));
    map->array = (HashNode **)calloc(SIZE, sizeof(HashNode *));
    return map;
}

void insert(HashMap *map, int key, int value)
{
    int index = abs(key) % SIZE;
    while (map->array[index] != NULL && map->array[index]->key != key)
    {
        index = (index + 1) % SIZE;
    }
    if (map->array[index] == NULL)
    {
        map->array[index] = (HashNode *)malloc(sizeof(HashNode));
    }
    map->array[index]->key = key;
    map->array[index]->value = value;
}

int search(HashMap *map, int key)
{
    int index = abs(key) % SIZE;
    while (map->array[index] != NULL)
    {
        if (map->array[index]->key == key)
        {
            return map->array[index]->value;
        }
        index = (index + 1) % SIZE;
    }
    return -1;
}

int *twoSum(int *nums, int numsSize, int target, int *returnSize)
{
    HashMap *map = createHashMap();
    for (int i = 0; i < numsSize; i++)
    {
        int complement = target - nums[i];
        int complementIndex = search(map, complement);
        if (complementIndex != -1)
        {
            int *result = (int *)malloc(2 * sizeof(int));
            result[0] = complementIndex;
            result[1] = i;
            *returnSize = 2;
            return result;
        }
        insert(map, nums[i], i);
    }
    *returnSize = 0;
    return NULL;
}
```

## Lenguaje C++

### Solución con fuerza bruta O(n²)

Podemos ver la primera diferencia de implementar algoritmos usando C++, en este código utilizamos la biblioteca `vector` de C++ para trabajar con arreglos dinámicos. La función `twoSum` toma un `std::vector` de enteros `nums` y el objetivo `target`. Luego, se utilizan dos bucles anidados para probar todas las combinaciones posibles de dos números del vector. Si se encuentra una pareja de números que suma el objetivo, se devuelve un nuevo vector con los índices de esos números. En caso contrario, se devuelve un vector vacío.

```cpp
class Solution {
public:
    std::vector<int> twoSum(std::vector<int> &nums, int target)
    {
        int n = nums.size();
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return {i, j}; // Devolvemos el índice del elemento actual y el índice del complemento
                }
            }
        }
        return {}; // Si no se encuentra ninguna pareja, se devuelve un vector vacío
    }
};
```

### Solución con tabla de hash O(n)

En este código, además de la biblioteca `vector` se utiliza la biblioteca `map` que nos permite utilizar `std::map` para almacenar los elementos del vector `nums` y sus respectivos índices.

En el bucle for, se itera a través de los elementos del vector `nums`. Para cada elemento, se calcula el complemento `t` necesario para alcanzar el objetivo target. Luego, se verifica si el complemento `t` ya está presente en el mapa utilizando la función `map.count()`. Si se encuentra, significa que hemos encontrado una pareja de números que suma el objetivo, por lo que se devuelve un nuevo vector que contiene los índices del complemento y del elemento actual.

Si no se encuentra ninguna pareja de números, se agrega el elemento actual al mapa con su índice correspondiente para futuras comprobaciones. Al final del bucle, si no se ha encontrado ninguna pareja, se devuelve un vector vacío `return {}`.

Este enfoque tiene una complejidad de tiempo de **O(n)**, ya que se realiza solo un recorrido lineal del vector `nums`. Además, utiliza una tabla de hash `std::map` para realizar búsquedas eficientes en tiempo constante.

```cpp
class Solution {
public:
    std::vector<int> twoSum(std::vector<int> &nums, int target)
    {
        std::map<int, int> map;
        for (int i = 0; i < nums.size(); ++i)
        {
            int t = target - nums[i]; // t(7) = 9 - 2, t(2) = 9 - 7
            if (map.count(t))
                return {map[t], i}; // map[t] = 0(donde se encontro el 2) e i = 1(donde se encuentra actualmente)
            map[nums[i]] = i;       // Recorremos una posición la tabla 0 --> 1
        }
        return {}; // En caso de que no se encuentre
    }
};
```

