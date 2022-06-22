using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    public static async Task<int> Methos1()
    {
        int count = 0;
        await Task.Run(() =>
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Method1");
                count += 1;
            }
        });
        return count;
    }

    public static void Method2()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Method 02");
        }
    }

    public static void Method3(int count)
    {
        Console.WriteLine("Method 3 is called.");
        Console.WriteLine($"Total count is {count}");
    }

    public static async Task callMethod()
    {
        Method2();
        var count = await Methos1();
        Method3(count);
    }

    static async Task Main(string[] args)
    {
        await callMethod();
        Console.ReadKey();
    }
}
