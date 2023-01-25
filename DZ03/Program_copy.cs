namespace VSCode
{


    public class GetUserInputNumber
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

    public class GetRandomArray
    {
        public static int[] GetArray(int length = 10, int minValue = 1, int maxValue = 1, int dischargeNumber = 0, bool isRandom = false)
        {
            int[] array = new int[length];
            Random rnd = new Random();

            if (isRandom)
            {
                return RandomArray(minValue, maxValue * 100 + 1);
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
}