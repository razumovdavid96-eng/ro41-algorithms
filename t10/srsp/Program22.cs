namespace ArrayAlgos
{
    internal class Program
    {
        private static void PrintArray(string title, int[] data)
        {
            var sb = new StringBuilder();
            sb.Append("{ ");
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i]);
                if (i < data.Length - 1) sb.Append(", ");
            }
            sb.Append(" }");
            Console.WriteLine($"{title}: {sb}");
        }

        static void Main()
        {
            Console.WriteLine("=== [1] ПРОВЕРКА ПУЗЫРЬКОВОЙ СОРТИРОВКИ ===");
            int[][] sampleData =
            {
                new int[] { },
                new int[] { 5 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 5, 4, 3, 2, 1 },
                new int[] { 3, 1, 3, 2, 3 }
            };

            for (int k = 0; k < sampleData.Length; k++)
            {
                int[] buffer = new int[sampleData[k].Length];
                Array.Copy(sampleData[k], buffer, sampleData[k].Length);

                Console.WriteLine($"--- Тест #{k + 1} ---");
                PrintArray("Начальный", sampleData[k]);

                int comps = ArrayAlgos.BubbleSort(buffer);
                PrintArray("Итоговый ", buffer);

                Console.WriteLine($"Отсортирован: {ArrayAlgos.IsSorted(buffer)} | Всего сравнений: {comps}\n");
            }

            int[] largeSorted = new int[1000];
            for (int idx = 0; idx < largeSorted.Length; idx++) largeSorted[idx] = idx;
            int largeComps = ArrayAlgos.BubbleSort(largeSorted);
            Console.WriteLine($"Проверка 1000 упорядоченных элементов -> Сравнений: {largeComps} (норма: 999)\n");

            Console.WriteLine("=== [2] ПРОВЕРКА COUNTOCCURRENCES ===");
            int[] orderedSeq = { 1, 2, 2, 2, 5, 7 };
            int[] targets = { 2, 1, 7, 3, 9 };

            PrintArray("Рабочий массив", orderedSeq);
            foreach (var val in targets)
            {
                int frequency = ArrayAlgos.CountOccurrences(orderedSeq, val);
                Console.WriteLine($"Число {val} встречается: {frequency} раз(а)");
            }
        }
    }
}
