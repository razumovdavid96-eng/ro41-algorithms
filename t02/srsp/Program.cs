using System;

namespace Srsp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое неотрицательное число: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int n) || n < 0)
            {
                Console.WriteLine("Ошибка: некорректный ввод (ожидается целое число >= 0)!");
                return;
            }

            int count = 0;
            int sum = 0;
            int temp = n;

            do
            {
                int digit = temp % 10;
                sum += digit;
                count++;
                temp /= 10;
            } 
            while (temp > 0);

            Console.WriteLine($"Число {n}: цифр = {count}, сумма = {sum}");
        }
    }
}
