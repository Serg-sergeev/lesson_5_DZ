// Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на чётных позициях.

public class Program
{
    private static void Main(string[] args)
    {
        int length, minValue, maxValue, dischargeNumber;
        bool isLength, isMinValue, isMaxValue, isDischargeNumber;
        int[] getArray;

        GetUserInputNumber.PrintText("Желаете указать размер массива? ");
        if (GetUserInputNumber.GetUserConfirm())
        {
            length = GetUserInputNumber.GetUserInput();
            isLength = true;
        }
        else
        {
            isLength = false;
            length = 10;
        }

        GetUserInputNumber.PrintText("Желаете указать количество цифр в чиселе? ");
        if (GetUserInputNumber.GetUserConfirm())
        {
            dischargeNumber = GetUserInputNumber.GetUserInput();
            isDischargeNumber = true;
            isMaxValue = false;
            isMinValue = false;
            minValue = maxValue = 1;
            if (isLength) getArray = GetRandomArray.GetArray(length: length, dischargeNumber: dischargeNumber);
            else getArray = GetRandomArray.GetArray(dischargeNumber: dischargeNumber);
        }
        else
        {
            GetUserInputNumber.PrintText("Желаете указать границы генерации? ");
            if (GetUserInputNumber.GetUserConfirm())
            {
                GetUserInputNumber.PrintText("Задайте минимальное значение генерации. ");
                minValue = GetUserInputNumber.GetUserInput();
                GetUserInputNumber.PrintText("Задайте максимальное значение генерации. ");
                maxValue = GetUserInputNumber.GetUserInput();
                isMaxValue = isMinValue = true;
                isDischargeNumber = false;
                dischargeNumber = 0;
                if (isLength) getArray = GetRandomArray.GetArray(length: length, maxValue: maxValue, minValue: minValue);
                else getArray = GetRandomArray.GetArray(maxValue: maxValue, minValue: minValue);
            }
            else
            {
                isMinValue = isMaxValue = isDischargeNumber = false;
                minValue = maxValue = dischargeNumber = 0;
                if (isLength) getArray = GetRandomArray.GetArray(length: length);
                else getArray = GetRandomArray.GetArray();
            }
        }

        GetUserInputNumber.PrintText("Переменные:");
        GetUserInputNumber.PrintText($"{length}\t{minValue}\t{maxValue}\t{dischargeNumber}" +
                                $"\n{isLength}\t{isMinValue}\t{isMaxValue}\t{isDischargeNumber}");

        GetUserInputNumber.PrintText("Сгенерированный массив: ");
        Console.WriteLine(string.Join(" ", getArray));
        Console.WriteLine($"Сумма элементов, стоящих на чётных позициях: {GetSumEvenElementsOfArray(getArray)}");

        // Получает сумму элементов, стоящих на чётных позициях.
        int GetSumEvenElementsOfArray(int[] array)
        {
            int sum = 0;
            for (int i = 1; i < array.Length; i += 2)
            {
                sum += array[i];
            }
            return sum;
        }
    }
}


class GetUserInputNumber
{

    //Возвращает true если согласен - false если не согласен.
    public static bool GetUserConfirm()
    {
        ConsoleKeyInfo keyUser;
        do
        {
            Console.WriteLine($"Нажмите 'Enter' подтверждения или 'Esc' для выхода/отмены");
            keyUser = Console.ReadKey();
            if (keyUser.Key == ConsoleKey.Enter) return true;
            if (keyUser.Key == ConsoleKey.Escape) return false;
            Console.WriteLine();

        }
        while (true);
    }

    public static int GetUserInput()
    {
        int userInput;
        string? input;

        do
        {
            Console.Write("Введите число: ");
            input = Console.ReadLine();
        }
        while (!int.TryParse(input, out userInput));

        return userInput;
    }

    public static void PrintText(string text)
    {
        Console.WriteLine(text + " ");
    }
}

class GetRandomArray
{
    public static int[] GetArray(int length = 10, int minValue = 1, int maxValue = 1, int dischargeNumber = 0, bool isRandom = false)
    {
        int[] array = new int[length];
        Random rnd = new Random();

        if (isRandom)
        {
            return RandomArray(minValue * 100, maxValue * 100);
        }
        else
        {
            if (dischargeNumber != 0)
            {
                if (dischargeNumber < 0) dischargeNumber *= -1;
                int count = 1;

                for (int i = 0; i < dischargeNumber; i++)
                {
                    count *= 10;
                }

                return RandomArray(count / 10, count);
            }
            else
            {
                if (minValue == 1) minValue = -100;
                if (maxValue == 1) maxValue = 100;

                return RandomArray(minValue, maxValue);
            }

        }

        int[] RandomArray(int minValue, int maxValue)
        {

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(minValue, maxValue + 1);
            }
            return array;
        }
    }
}
