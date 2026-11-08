namespace ArrayAlgos
{
    public static class ArrayAlgos
    {
        public static bool IsSorted(int[] array)
        {
            if (array == null || array.Length < 2)
                return true;

            int ptr = 0;
            while (ptr < array.Length - 1)
            {
                if (array[ptr] > array[ptr + 1])
                    return false;
                ptr++;
            }

            return true;
        }

        public static int BubbleSort(int[] array)
        {
            if (array == null || array.Length < 2)
                return 0;

            int totalComparisons = 0;
            int length = array.Length;
            bool hasSwapped;

            for (int pass = 0; pass < length - 1; pass++)
            {
                hasSwapped = false;
                int limit = length - 1 - pass;

                for (int curr = 0; curr < limit; curr++)
                {
                    totalComparisons++;
                    if (array[curr] > array[curr + 1])
                    {
                        (array[curr], array[curr + 1]) = (array[curr + 1], array[curr]);
                        hasSwapped = true;
                    }
                }

                if (!hasSwapped)
                    break;
            }

            return totalComparisons;
        }

        private static int FindFirstGreaterOrEqual(int[] source, int target)
        {
            int left = 0;
            int right = source.Length - 1;
            int resultIndex = source.Length;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (source[middle] >= target)
                {
                    resultIndex = middle;
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return resultIndex;
        }

        private static int FindFirstStrictlyGreater(int[] source, int target)
        {
            int left = 0;
            int right = source.Length - 1;
            int resultIndex = source.Length;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (source[middle] > target)
                {
                    resultIndex = middle;
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return resultIndex;
        }

        public static int CountOccurrences(int[] sortedA, int x)
        {
            if (sortedA == null || sortedA.Length == 0)
                return 0;

            int leftIdx = FindFirstGreaterOrEqual(sortedA, x);
            int rightIdx = FindFirstStrictlyGreater(sortedA, x);

            return rightIdx - leftIdx;
        }
    }
}
