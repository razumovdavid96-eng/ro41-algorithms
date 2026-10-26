using System;

const int Max = 5;
const int Stop = 0;

int count = 0;
int sum = 0;
int fives = 0;

while (true)
{
    int grade = Grades.Read();

    if (grade == Stop)
    {
        break;
    }

    if (Grades.IsValid(grade))
    {
        count++;
        sum += grade;
        if (grade == Max)
        {
            fives++;
        }
    }
    else
    {
        Console.WriteLine("Ошибка: некорректная оценка (ожидается число от 2 до 5, либо 0 для выхода).");
    }
}


Grades.PrintStats(count, sum, fives);

static class Grades
{
    const int Min = 2;
    const int Max = 5;

    public static int Read()
    {
        Console.Write("Введите оценку (или 0 для завершения): ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        return -1;
    }

    public static bool IsValid(int g)
    {
        return g >= Min && g <= Max;
    }

    public static void PrintStats(int count, int sum, int fives)
    {
        if (count == 0)
        {
            Console.WriteLine("Оценок нет");
            return;
        }

        double avg = (double)sum / count;
        Console.WriteLine($"Количество оценок: {count}");
        Console.WriteLine($"Сумма оценок: {sum}");
        Console.WriteLine($"Средний балл: {avg:F2}");
        Console.WriteLine($"Количество пятерок: {fives}");
    }
}
