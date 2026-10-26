using System;

namespace Srsp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество секунд: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int totalSeconds) || totalSeconds < 0)
            {
                Console.WriteLine("Ошибка: некорректный ввод (ожидается целое число >= 0)!");
                return;
            }

            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;

            Console.WriteLine($"{hours} ч. {minutes} мин. {seconds} сек.");
        }
    }
}
