public static class TextTools
{
    public static int CountWords(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return 0;

        char[] separators = new char[] { ' ', '\t', '\r', '\n' };
        string[] words = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    public static bool IsPalindrome(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return true;

        int nonSpaceCount = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (!char.IsWhiteSpace(s[i]))
                nonSpaceCount++;
        }

        char[] cleanChars = new char[nonSpaceCount];
        int index = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (!char.IsWhiteSpace(s[i]))
            {
                cleanChars[index++] = char.ToLowerInvariant(s[i]);
            }
        }

        for (int i = 0; i < cleanChars.Length / 2; i++)
        {
            if (cleanChars[i] != cleanChars[cleanChars.Length - 1 - i])
                return false;
        }

        return true;
    }

    public static string Initials(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return string.Empty;

        string[] parts = fullName.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
            return string.Empty;

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < parts.Length; i++)
        {
            char firstLetter = char.ToUpper(parts[i][0]);
            result.Append(firstLetter);
            result.Append(".");
            if (i < parts.Length - 1)
            {
                result.Append(" ");
            }
        }

        return result.ToString();
    }

    public static string Repeat(string s, int n)
    {
        if (string.IsNullOrEmpty(s) || n <= 0)
            return string.Empty;

        StringBuilder builder = new StringBuilder();
        int counter = 0;
        while (counter < n)
        {
            builder.Append(s);
            counter++;
        }

        return builder.ToString();
    }
}

class Program
{
    static void Main()
    {
        string[] inputs = new string[]
        {
            "",
            "   ",
            " a b ",
            "А роза упала на лапу Азора",
            "Ахметов Ерлан"
        };

        Console.WriteLine("--- Проверка метода CountWords ---");
        int[] expectedWords = { 0, 0, 2, 6, 2 };
        for (int i = 0; i < inputs.Length; i++)
        {
            int actual = TextTools.CountWords(inputs[i]);
            PrintResult(inputs[i], expectedWords[i].ToString(), actual.ToString());
        }

        Console.WriteLine("\n--- Проверка метода IsPalindrome ---");
        bool[] expectedPali = { true, true, false, true, false };
        for (int i = 0; i < inputs.Length; i++)
        {
            bool actual = TextTools.IsPalindrome(inputs[i]);
            PrintResult(inputs[i], expectedPali[i].ToString(), actual.ToString());
        }

        Console.WriteLine("\n--- Проверка метода Initials ---");
        string[] expectedInitials = { "", "", "A. B.", "А. Р. У. Н. Л. А.", "А. Е." };
        for (int i = 0; i < inputs.Length; i++)
        {
            string actual = TextTools.Initials(inputs[i]);
            PrintResult(inputs[i], expectedInitials[i], actual);
        }

        Console.WriteLine("\n--- Проверка метода Repeat (n = 2) ---");
        string[] expectedRepeat = { "", "      ", " a b  a b ", "А роза упала на лапу АзораА роза упала на лапу Азора", "Ахметов ЕрланАхметов Ерлан" };
        for (int i = 0; i < inputs.Length; i++)
        {
            string actual = TextTools.Repeat(inputs[i], 2);
            PrintResult(inputs[i], expectedRepeat[i], actual);
        }
    }

    static void PrintResult(string input, string expected, string actual)
    {
        bool isOk = expected.Equals(actual);
        string verdict = isOk ? "OK" : "FAIL";
        Console.WriteLine($"Вход: \"{input}\" | Ожидание: \"{expected}\" | Факт: \"{actual}\" | Статус: {verdict}");
    }
}
