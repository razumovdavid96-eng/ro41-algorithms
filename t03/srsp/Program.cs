using System;

namespace Gcd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число a (>= 0): ");
            string inputA = Console.ReadLine();

            Console.Write("Введите число b (>= 0): ");
            string inputB = Console.ReadLine();

            if (!int.TryParse(inputA, out int a) || !int.TryParse(inputB, out int b) || a < 0 || b < 0 || (a == 0 && b == 0))
            {
                Console.WriteLine("Ошибка: некорректный ввод (числа должны быть целыми, >= 0 и не равны нулю одновременно)!");
                return;
            }

            int origA = a;
            int origB = b;

            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }

            Console.WriteLine($"НОД({origA}, {origB}) = {a}");
        }
    }
}
