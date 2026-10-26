using System;

void Test(int a, int b, int c)
{
    int origA = a;
    int origB = b;
    int origC = c;

    Order.Sort3(ref a, ref b, ref c);

    Console.WriteLine($"{origA} {origB} {origC} -> {a} {b} {c}");
}

Test(3, 1, 2);
Test(1, 2, 3);
Test(3, 2, 1);
Test(2, 2, 1);
Test(5, 5, 5);

static class Order
{
    public static void Swap(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }

    public static void Sort3(ref int a, ref int b, ref int c)
    {
        if (a > b)
        {
            Swap(ref a, ref b);
        }
        if (b > c)
        {
            Swap(ref b, ref c);
        }
        if (a > b)
        {
            Swap(ref a, ref b);
        }
    }
}
