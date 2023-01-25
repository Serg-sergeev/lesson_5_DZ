// Задайте массив заполненный случайными положительными трёхзначными числами. 
// Напишите программу, которая покажет количество чётных чисел в массиве.


int length = -1;
int dischargeNumber = 0;
int minValue = -1;
int maxValue = -1;

Console.WriteLine("Предлагаем сгенерировать случайный массив!");

Console.Write("Желаете указать размер массива? ");
if (GetUserComfirmation())
{
    GetUserInputNumber("Введите размер массива", out length);
}

Console.Write("Желаете указать количество цифр в чиселе?");
if (GetUserComfirmation())
{
    GetUserInputNumber("Введите количество цифр в чиселе (1, 2, 3 и тд.): ", out dischargeNumber);
}
else
{   
    Console.Write("Желаете указать диапозон значений случайных чисел? ");
    if (GetUserComfirmation())
    {
        GetUserInputNumber("Введите диапозон значений случайных чисел: от - ", out minValue);
        GetUserInputNumber("Введите диапозон значений случайных чисел: до - ", out maxValue);
    }
}

int[] getArray = GetRandomArray(ref length, ref minValue, ref maxValue, ref dischargeNumber);
Console.WriteLine(string.Join(" ", getArray));
Console.WriteLine($"Количество четных чисел в массиве: {GetQuantityEvenNumbersOfArray(getArray)}");


//Возвращает true если согласен - false если не согласен.
bool GetUserComfirmation()
{
    do
    {
        Console.Write(" Y/N ");
        ConsoleKeyInfo keyUser = Console.ReadKey();
        Console.Clear();

        if (keyUser.Key == ConsoleKey.Enter
         || keyUser.Key == ConsoleKey.Y) return true;
        if (keyUser.Key == ConsoleKey.Escape
         || keyUser.Key == ConsoleKey.N) return false;

        Console.WriteLine("Попробуйте ввести еще раз: ");
    } while (true);
}

// Отображает переданнай текс для ввода числа. Если ввели число - записывает результат в переменную inputUser.
// Если от ввода отказались - выходная переменная равно -1.
void GetUserInputNumber(string? text, out int inputUser)
{
    while (true)
    {
        Console.Write(text + " ");
        string? input = Console.ReadLine();
        bool result = int.TryParse(input, out inputUser);
        if (result == true)
        {
            return; // inputUser;
        }
        else
        {
            Console.WriteLine("Вы ввели не число или число слишком большое!");
            Console.Write("Хотите ввести число еще раз?");
            if (GetUserComfirmation())
            {
                continue;
            }
            else
            {
                inputUser = -1;
                return;
            }
        }
    }
}

// Генерирует случайный массив.
// dischargeNumber - количество цифр в числе, если не задан использует числа от -1000 до 1000.
int[] GetRandomArray(ref int length, ref int minValue, ref int maxValue,ref int dischargeNumber)
{
    if (length == -1) length = 10;
    if (minValue == -1) minValue = -1000;
    if (maxValue == -1) maxValue = 1000;
    if (dischargeNumber < 0) dischargeNumber *= -1;     // Избавляемся от отрицательного ввода.
    int[] array = new int[length];
    Random rnd = new Random();

    if (dischargeNumber == 0)                           // Генерирум случайный массив с параметрами по умолчанию
    {
        for (int i = 0; i < length; i++)
        {
            array[i] = rnd.Next(minValue, maxValue + 1);
        }
    }
    else                                                // Генерируем массив в соответствии с параметром dischargeNumber
    {
        int count = 1;
        for (int i = 0; i < dischargeNumber; i++, count *= 10) ;

        minValue = count / 10;
        if (dischargeNumber == 1) minValue = 0;
        maxValue = count;

        for (int i = 0; i < length; i++)
        {
            array[i] = rnd.Next(minValue, maxValue);
        }

    }

    return array;
}

int GetQuantityEvenNumbersOfArray(int[] array)
{
    int count = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] % 2 == 0) count++;
    }
    return count;
}