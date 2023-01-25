//Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
//[3 7 22 2 78] -> 76

using System;

namespace VSCode
{
    class Program
    {

        static void Main()
        {


            int[] array = GetRandomArray.GetArray(isRandom: true);

            Console.WriteLine("Сгенерированный массив: ");
            Console.WriteLine(String.Join("\t", array));
            Console.WriteLine("Разница между мин. и макс. элементами равна: ");
            Console.WriteLine(GetDifferenceBetweenMinMaxElements(array));

            int GetDifferenceBetweenMinMaxElements(int[] array)
            {
                int min = array[0];
                int max = array[0];

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < min) min = array[i];
                    if (array[i] > max) max = array[i];
                }

                return max - min;
            }
        }

    }
}

