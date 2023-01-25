namespace InitClasses
{

    public static class RandomArray
    {

        public static int[] Get(int length, int minValue, int maxValue)
        {

            Random rnd = new Random();
            int[] array = new int[length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(minValue, maxValue);
            }

            return array;
        }

        public static void Print(int[] array, string text = "Сгенерированный массив: ")
        {
            Console.WriteLine(text);
            Console.WriteLine(String.Join("\t", array));
        }

    }

    public static class UserInput
    {
        public static int GetNumber(string text = "Введите число: ")
        {
            int userInput;
            string? input;

            do
            {
                Console.Write(text);
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out userInput));

            return userInput;
        }
    }

    public static class ConvertingArrays
    {

        public static int[] GetPairsOfNumbers(int[] array)
        {
            int length;

            if (array.Length % 2 == 0)
            {
                length = array.Length / 2;
            }
            else
            {
                length = array.Length / 2 + 1;
            }

            int[] result = new int[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = array[i] * array[array.Length - i - 1];
            }

            return result;
        }

    }

}
