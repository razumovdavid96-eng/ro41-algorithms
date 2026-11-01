using System;

namespace RecursionTask
{
    public static class Rec
    {
        public static int DigitSum(int n)
        {
            if (n < 10)
            {
                return n;
            }

            int rightmostDigit = n % 10;
            int truncatedNumber = n / 10;

            return rightmostDigit + DigitSum(truncatedNumber);
        }

        public static long Pow(int x, int n)
        {
            if (n <= 0)
            {
                return 1L;
            }

            return (long)x * Pow(x, n - 1);
        }
    }

    internal class Program
    {
        private static void PrintDigitSumResult(int value)
        {
            int answer = Rec.DigitSum(value);
            Console.WriteLine($"DigitSum({value}) = {answer}");
        }

        private static void PrintPowResult(int baseNum, int exponent)
        {
            long answer = Rec.Pow(baseNum, exponent);
            Console.WriteLine($"Pow({baseNum}, {exponent}) = {answer}");
        }

        private static void Main()
        {
            PrintDigitSumResult(0);
            PrintDigitSumResult(7);
            PrintDigitSumResult(12345);
            PrintDigitSumResult(1000);

            Console.WriteLine();

            PrintPowResult(2, 0);
            PrintPowResult(2, 10);
            PrintPowResult(5, 3);
            PrintPowResult(7, 1);
        }
    }
}
