using System;
using System.Collections.Generic;

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

int[] nums = { 2, 1, 5, 3 };
int target = 4;

//Imprimir  la entrada
Console.WriteLine("Input: nums = [" + String.Join(", ", nums) + "], target = " + target);

int[] result = TwoSum(nums, target);

//Imprimir la salida
Console.WriteLine("Output: [" + String.Join(", ", result) + "]");

