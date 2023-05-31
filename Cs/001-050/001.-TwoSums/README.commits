Dada un array de números enteros llamado `nums` y un objetivo entero llamado `target`, devuelve índices de los dos números de modo que sumen el objetivo.

Puede suponer que cada entrada tendría exactamente una solución y no puede usar el mismo elemento dos veces.

Puede devolver la respuesta en cualquier orden.


Para la solución de este problema tenemos dos enfoques uno es el de fuerza bruta y el otro es el de usar una tabla de hash.

## Solución de fuerza bruta

Recorrer el arreglo con dos ciclos for anidados y comparar cada elemento con los demás hasta encontrar la suma del objetivo, esta es una solución de complejidad O(n^2) y no es optima

## Solución con tabla de hash

En .NET podemos usar una implementación de la biblioteca `System.Collections.Generic` llamada `Dictionary<TKey,TValue>` que es una tabla hash que nos permite almacenar pares de valores clave-valor, en este caso la clave será el valor del elemento del arreglo y el valor será el índice del elemento en el arreglo.

Esta solución es de complejidad O(n) ya que solo recorremos el arreglo una vez y en cada iteración buscamos en la tabla hash si existe el complemento de la suma del objetivo con el elemento actual, si existe entonces devolvemos el índice del elemento actual y el índice del complemento, si no existe entonces agregamos el elemento actual a la tabla hash.

Para saber si existe el objetivo dentro del diccionario ocupamos la función `ContainsKey` que nos devuelve un valor booleano indicando si existe o no la clave dentro del diccionario.