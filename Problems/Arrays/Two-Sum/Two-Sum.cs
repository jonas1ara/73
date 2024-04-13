using System;
using System.Collections.Generic;

// Using hash table - Time: O(n)

public class Solution /* Define a public class Solution */
{
	public int[] TwoSum(int[] nums, int target) // Define un metodo llamado Two sum que toma dos parametros int[] nums y int target, retorna un arreglo de enteros 
	{
		var dic = new Dictionary<int, int>(); // Crea un diccionario de enteros, donde la clave sera un numero del areglo nums y el VALOR SERA SU INDICE EN EL ARREGLO, este diccionario se utilizara para realizar un seguimiento de los numeros que se han visto durante la iteracion

		for (int i = 0; i < nums.Length; i++) // Un bucle para recorrer todos los elementos en nums
		{
			int t = target - nums[i]; // Calcula la diferencia entre el target(9) y el numero actual de indice (2), osea que t = 7

			//If the dictionary contains the key t, return the index of t and the current index
			if (dic.ContainsKey(t)) // 2
				return new int[] { dic[t], i }; // {0,1}, hace dos pasadas

			// Verifica si la clave t (7) esta presente en el diccionario, ESTO SIGINIFICA QUE YA SE HA ENCONTRADO UN NUMERO PREVIAMENTE CUYA SUMA CON NUMERO ACTUAL SEA IGUAL AL target

			// Si se encuentra un par de numeros cuya suma sea igual al target, retorna un arreglo que contine los indicies de esos dos numeros en el arreglo

			dic[nums[i]] = i; // Agrega el numero actual del arreglo nums como clave al diccionario, con su valor siendo el indice actual i. Esto permite rastrear que numeros se han visto durante la iteracion, 2 y despues 7
		}

		return new int[] { }; //If the sum has no solution, return the empty array
	}
}

class Program
{
    static void Main(String[] args)
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;

        // Print intput
        Console.Write("Input: nums = [");
        foreach (int n in nums)
        {
            Console.Write(n + "");
            if (n != nums[nums.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("], target = " + target);

        Solution sol = new Solution();
        int[] result = sol.TwoSum(nums, target);

        // Print output
        Console.Write("Output: [");
        foreach (int r in result)
        {
            Console.Write(r + "");
            if (r != result[result.Length - 1])
            {
                Console.Write(", ");
            }
        }
		Console.WriteLine("]");
    }
}





