﻿using System;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("List of Books");
        Console.WriteLine("-------------");
        var cadJson = File.ReadAllText("Data/BookStore.json");
        var bookList = JsonConvert.DeserializeObject<Book[]>(cadJson);
        foreach (var item in bookList)
        {
            Console.WriteLine($"{item.Title.PadRight(39, ' ')}" + $"{item.Author.PadRight(15, ' ')} {item.Price}");
        }
        Console.Read();
    }
}
