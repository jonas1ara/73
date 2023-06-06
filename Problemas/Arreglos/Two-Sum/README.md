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

Recorrer el arreglo con dos ciclos for anidados y comparar cada elemento con los demás hasta encontrar la suma del objetivo, esta es una solución con complejidad O(n²) que no es muy eficiente pero es la más sencilla de implementar

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

Recorrer el arreglo con dos ciclos for anidados y comparar cada elemento con los demás hasta encontrar la suma del objetivo, esta es una solución con complejidad O(n²) que no es muy eficiente pero es la más sencilla de implementar

```cpp
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
```

### Solución con tabla de hash O(n)

En .NET podemos usar una implementación de la biblioteca `System.Collections.Generic` llamada `Dictionary<TKey,TValue>` que es una tabla hash que nos permite almacenar pares de valores clave-valor, en este caso la clave será el valor del elemento del arreglo y el valor será el índice del elemento en el arreglo

Esta solución es de complejidad O(n) ya que solo recorremos el arreglo una vez y en cada iteración buscamos en la tabla hash si existe el complemento de la suma del objetivo con el elemento actual, si existe entonces devolvemos el índice del elemento actual y el índice del complemento, si no existe entonces agregamos el elemento actual a la tabla hash

Para saber si existe el objetivo dentro del diccionario ocupamos la función `ContainsKey` que nos devuelve un valor booleano indicando si existe o no la clave dentro del diccionario y una vez que sabemos que existe podemos devolver los valores en un nuevo arreglo `return new int[] { dic[t], i };` donde `dic[t]` es el índice del complemento y `i` es el índice del elemento actual

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