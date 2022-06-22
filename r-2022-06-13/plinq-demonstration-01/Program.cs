using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        var range = Enumerable.Range(1, 1000_000);
        var result_list = range.Where(i => i % 3 == 0).ToList();
        Console.WriteLine($"Sequential: Total items are {result_list.Count}");

        result_list = range.AsParallel().Where(i => i % 3 == 0).ToList();
        Console.WriteLine($"Parallel: Total items are {result_list.Count}");
        result_list = (from i in range.AsParallel() where i % 3 == 0 select i).ToList();

        Console.WriteLine($"Parallel: Total items are {result_list.Count}");
        Console.ReadLine();
    }
}