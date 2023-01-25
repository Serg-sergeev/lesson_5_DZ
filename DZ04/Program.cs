//Найдите произведение пар чисел в одномерном массиве. Парой считаем первый и последний элемент, второй и предпоследний и т.д. 
//Результат запишите в новом массиве.

using InitClasses;

int length = UserInput.GetNumber("Введите длинну массива: ");
int minValue = UserInput.GetNumber("Введити минимальное значение генирации массива: ");
int maxValue = UserInput.GetNumber("Введити максимальное значение генирации массива: ");

int[] array = RandomArray.Get(length, minValue, maxValue);
RandomArray.Print(array);
int[] convertArray = ConvertingArrays.GetPairsOfNumbers(array);
RandomArray.Print(convertArray, "Преобразованный массив: ");