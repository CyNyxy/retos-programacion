using System;

namespace _91_Sumas
{
    internal class Program
    {

        /*
        * Crea una función que encuentre todas las combinaciones de los números
        * de una lista que suman el valor objetivo.
        * - La función recibirá una lista de números enteros positivos
        *   y un valor objetivo.
        * - Para obtener las combinaciones sólo se puede usar
        *   una vez cada elemento de la lista (pero pueden existir
        *   elementos repetidos en ella).
        * - Ejemplo: Lista = [1, 5, 3, 2],  Objetivo = 6
        *   Soluciones: [1, 5] y [1, 3, 2] (ambas combinaciones suman 6)
        *   (Si no existen combinaciones, retornar una lista vacía)
        *   -> Se hará con arrays en vez de listas
        */

        static void Main(string[] args)
        {
            int[] array = { 1, 5, 3, 2 };
            int target = 6;
            int[][] combinations = FindCombinations(array, target);
            if (combinations.Length == 0)
            {
                Console.WriteLine("No existen combinaciones que sumen el valor objetivo.");
            }
            else
            {
                Console.WriteLine("Las siguientes combinaciones suman el valor objetivo:");
                foreach (int[] combination in combinations)
                {
                    Console.WriteLine(string.Join(", ", combination));
                }
            }
        }

        static int[][] FindCombinations(int[] array, int target)
        {
            Array.Sort(array);
            return FindCombinationsHelper(array, target, 0);
        }

        static int[][] FindCombinationsHelper(int[] array, int target, int start)
        {
            if (target == 0)
            {
                return new int[][] { new int[0] };
            }
            else if (target < 0)
            {
                return new int[0][];
            }
            else
            {
                int[][] result = new int[0][];
                for (int i = start; i < array.Length && array[i] <= target; i++)
                {
                    if (i > start && array[i] == array[i - 1])
                    {
                        continue;
                    }
                    if (array[i] > target)
                    {
                        break;
                    }

                    int[][] subResult = FindCombinationsHelper(array, target - array[i], i + 1);

                    for (int j = 0; j < subResult.Length; j++)
                    {
                        int[] combination = new int[subResult[j].Length + 1];
                        combination[0] = array[i];
                        Array.Copy(subResult[j], 0, combination, 1, subResult[j].Length);
                        Array.Resize(ref result, result.Length + 1);
                        result[result.Length - 1] = combination;
                    }
                }
                return result;
            }
        }
    }
}

//////////////////////////////////////////////////////

//// Solución listas
//using System;
//using System.Collections.Generic;

//namespace _91_Sumas
//{ 
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] array = { 1, 5, 3, 2 };
//            int target = 6;
//            List<List<int>> combinations = FindCombinations(array, target);
//            if (combinations.Count == 0)
//            {
//                Console.WriteLine("No existen combinaciones que sumen el valor objetivo.");
//            }
//            else
//            {
//                Console.WriteLine("Las siguientes combinaciones suman el valor objetivo:");
//                foreach (List<int> combination in combinations)
//                {
//                    Console.WriteLine(string.Join(", ", combination));
//                }
//            }
//        }

//        static List<List<int>> FindCombinations(int[] array, int target)
//        {
//            List<List<int>> combinations = new List<List<int>>();
//            List<int> current = new List<int>();
//            Array.Sort(array);
//            FindCombinationsHelper(array, target, 0, current, combinations);
//            return combinations;
//        }

//        static void FindCombinationsHelper(int[] array, int target, int start, List<int> current, List<List<int>> combinations)
//        {
//            if (target == 0)
//            {
//                combinations.Add(new List<int>(current));
//                return;
//            }
//            for (int i = start; i < array.Length && array[i] <= target; i++)
//            {
//                if (i > start && array[i] == array[i - 1])
//                {
//                    continue;
//                }
//                current.Add(array[i]);
//                FindCombinationsHelper(array, target - array[i], i + 1, current, combinations);
//                current.RemoveAt(current.Count - 1);
//            }
//        }
//    }
//}