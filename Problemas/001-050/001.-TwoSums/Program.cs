using System;
using System.Collections.Generic;

namespace TwoSums
{
    class Program
    {
        static int[] TwoSum(int[] nums, int target)
        {
            // Crear un diccionario para almacenar los valores y sus indices **Diccionario sirve para almacenar datos en forma de clave y valor**
            var dic = new Dictionary<int, int>();

            // Recorrer el arreglo
            for (int i = 0; i < nums.Length; i++)
            {
                int t = target - nums[i]; //4 - 2 = 2, 4 - 1 = 3, 4 - 5 = -1, 4 - 3 = 1
                if (dic.ContainsKey(t)) return new int[] { dic[t], i }; //Si el diccionario contiene la clave t, retornar el indice de t y el indice actual
                dic[nums[i]] = i; //Si no, agregar el valor actual y su indice al diccionario
            }
            return new int[] { }; //Si no se encuentra una solucion retornar un arreglo vacio
        }
    
        static void Main(string[] args)
        {
            int[] nums = { 2, 1, 5, 3 };
            int target = 4;
            
            //Imprimir  la entrada
            Console.WriteLine("Input: nums = [" + String.Join(", ", nums) + "], target = " + target);

            int[] result = TwoSum(nums, target);	

            //Imprimir la salida
            Console.WriteLine("Output: [" + String.Join(", ",result) + "]");
        }
    }
}
