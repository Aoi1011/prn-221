using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    private static bool IsPrime(int number)
    {
        bool result = true;
        if (number < 2)
        {
            return false;
        }
        for (var divisor = 2; divisor <= Math.Sqrt(number) && result == true; divisor++)
        {
            if (number % divisor == 0)
            {
                result = false;
            }
        }

        return result;
    }

    private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();

    private static IList<int> GetPrimeListWithParallel(IList<int> numbers)
    {
        var prime_numbers = new ConcurrentBag<int>();
        Parallel.ForEach(numbers, number =>
        {
            if (IsPrime(number))
            {
                prime_numbers.Add(number);
            }
        });
        return prime_numbers.ToList();
    }

    static void Main()
    {
        var limit = 2_000_000;
        var numbers = Enumerable.Range(0, limit).ToList();

        var watch = Stopwatch.StartNew();
        var prime_numbers_from_foreach = GetPrimeList(numbers);
        watch.Stop();

        var watch_for_parallel = Stopwatch.StartNew();
        var prime_numbers_from_parallel_for_each = GetPrimeListWithParallel(numbers);
        watch_for_parallel.Stop();

        Console.WriteLine($"Classical foreach loop | Total prime numbers :" + $"{prime_numbers_from_foreach.Count} | Time Taken: " + $"{watch.ElapsedMilliseconds}ms");
        Console.WriteLine($"Parallel foreach loop | Total prime numbers :" + $"{prime_numbers_from_parallel_for_each.Count} | Time Taken: " + $"{watch_for_parallel.ElapsedMilliseconds}ms");

        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
    }
}