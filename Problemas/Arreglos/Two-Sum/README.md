# Two sums

Dado un arreglo de números enteros llamado `nums` y un objetivo entero llamado `target`, devuelve índices de los dos números de modo que sumen el objetivo.

- Puede suponer que cada entrada tendría exactamente una solución
- No puede usar el mismo elemento dos veces.
- Puede devolver la respuesta en cualquier orden.

Para la solución de este problema tenemos dos enfoques uno es el de **fuerza bruta** y el otro es el de usar una **tabla de hash**.

## Solución de fuerza bruta O (n²)

Recorrer el arreglo con dos ciclos for anidados y comparar cada elemento con los demás hasta encontrar la suma del objetivo, esta es una solución con complejidad O(n²) que no es muy eficiente pero es la más sencilla de implementar

```csharp
int[] TwoSum(int[] nums, int target)
{
    int[] result = new int[2];
    int n = nums.Length;

    for (int i =0; i <= n; i++ )
    {
        for (int j = i+1; j <= n; j++)
        {
            if (nums[i] + nums[j] == target)
            {
                result[0] = i;
                result[1] = j;

                return result;
            }
        }
    }
    return new int[] { };
}
```

## Solución con tabla de hash O (n)

En .NET podemos usar una implementación de la biblioteca `System.Collections.Generic` llamada `Dictionary<TKey,TValue>` que es una tabla hash que nos permite almacenar pares de valores clave-valor, en este caso la clave será el valor del elemento del arreglo y el valor será el índice del elemento en el arreglo

Esta solución es de complejidad O(n) ya que solo recorremos el arreglo una vez y en cada iteración buscamos en la tabla hash si existe el complemento de la suma del objetivo con el elemento actual, si existe entonces devolvemos el índice del elemento actual y el índice del complemento, si no existe entonces agregamos el elemento actual a la tabla hash

Para saber si existe el objetivo dentro del diccionario ocupamos la función `ContainsKey` que nos devuelve un valor booleano indicando si existe o no la clave dentro del diccionario y una vez que sabemos que existe podemos devolver los valores en un nuevo arreglo `return new int[] { dic[t], i };` donde `dic[t]` es el índice del complemento y `i` es el índice del elemento actual

```csharp
using System.Collections.Generic;

int[] TwoSum(int[] nums, int target)
{
    var dic = new Dictionary<int, int>();

    for (int i = 0; i < nums.Length; i++)
    {
        //Calcular el complemento de la suma del objetivo con el elemento actual
        int t = target - nums[i]; 

        //Si el diccionario contiene la clave t, retornar el indice de t y el indice actual
        if (dic.ContainsKey(t)) return new int[] { dic[t], i }; 

        dic[nums[i]] = i; //Si no, agregar el valor actual y su indice al diccionario
    }
    return new int[] { }; 
}
```