namespace ArrayOperationsTask
{
    public static class ArrayOps
    {
        public static int Sum(int[] a)
        {
            int accumulator = 0;
            foreach (int number in a)
            {
                accumulator += number;
            }
            return accumulator;
        }

        public static int IndexOfMin(int[] a)
        {
            int smallestValue = a[0];
            int smallestIndex = 0;

            for (int idx = 1; idx < a.Length; idx++)
            {
                if (a[idx] < smallestValue)
                {
                    smallestValue = a[idx];
                    smallestIndex = idx;
                }
            }

            return smallestIndex;
        }

        public static int CountGreater(int[] a, int x)
        {
            int matchedCount = 0;
            for (int idx = 0; idx < a.Length; idx++)
            {
                if (a[idx] > x)
                {
                    matchedCount++;
                }
            }
            return matchedCount;
        }

        public static void Reverse(int[] a)
        {
            int length = a.Length;
            int half = length / 2;

            for (int i = 0; i < half; i++)
            {
                int oppositeIndex = length - 1 - i;
                int buffer = a[i];
                a[i] = a[oppositeIndex];
                a[oppositeIndex] = buffer;
            }
        }
    }

    internal class Program
    {
        private static string ArrayToText(int[] data)
        {
            if (data.Length == 0) return "{}";

            string result = "{" + data[0];
            for (int i = 1; i < data.Length; i++)
            {
                result += ", " + data[i];
            }
            result += "}";
            return result;
        }

        private static void InspectArray(int[] numbers)
        {
            string before = ArrayToText(numbers);
            int totalSum = ArrayOps.Sum(numbers);
            int minPos = ArrayOps.IndexOfMin(numbers);
            int greaterThanTwo = ArrayOps.CountGreater(numbers, 2);

            ArrayOps.Reverse(numbers);
            string after = ArrayToText(numbers);

            Console.WriteLine($"Массив: {before} | Сумма = {totalSum} | Индекс мин. = {minPos} | Больше (x=2): {greaterThanTwo} | Разворот: {after}");
        }

        private static void Main()
        {
            int[] first = { 4, 1, 7, 3, 9 };
            int[] second = { 5 };
            int[] third = { -2, -7, -4 };
            int[] fourth = { 2, 2, 2 };

            InspectArray(first);
            InspectArray(second);
            InspectArray(third);
            InspectArray(fourth);
        }
    }
}
