using System;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static List<Book> bookList;
    static void Main(string[] args)
    {
        // SingleResponsibilityDemo();
        OpenClosedPrincipleDemo();
    }

    static void SingleResponsibilityDemo()
    {
        Console.WriteLine("List of Books");
        Console.WriteLine("-------------");
        var cadJson = File.ReadAllText("Data/BookStore_01.json");
        var bookList = JsonConvert.DeserializeObject<Book[]>(cadJson);
        foreach (var item in bookList)
        {
            Console.WriteLine($"{item.Title.PadRight(39, ' ')}" + $"{item.Author.PadRight(15, ' ')} {item.Price}");
        }
        Console.Read();
    }

    static void OpenClosedPrincipleDemo()
    {
        Console.WriteLine("Please, press 'yes' to read an extra file, ");
        Console.WriteLine("or any other key for a single file");
        var ans = Console.ReadLine();
        bookList = (ans.ToLower() != "yes") ? Utilities.ReadData() : Utilities.ReadDataExtra();
        PrintBooks(bookList);
    }

    static void PrintBooks(List<Book> books)
    {
        Console.WriteLine("List of Books");
        Console.WriteLine("-------------");
        var cadJson = File.ReadAllText("Data/BookStore_01.json");
        var bookList = JsonConvert.DeserializeObject<Book[]>(cadJson);
        foreach (var item in bookList)
        {
            Console.WriteLine($"{item.Title.PadRight(39, ' ')}" + $"{item.Author.PadRight(20, ' ')} {item.Price}");
        }
        Console.ReadLine();
    }
}
