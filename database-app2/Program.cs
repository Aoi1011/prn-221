// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddRazorPages();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// app.UseHttpsRedirection();
// app.UseStaticFiles();

// app.UseRouting();

// app.UseAuthorization();

// app.MapRazorPages();

// app.Run();
using System;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        TestData testData = new TestData() { Id = 1, Test = "FirstPostgresData" };
        var connString = "Host=postgressql_database;Username=admin;Password=admin;Database=SampleDatabase";

        try
        {
            using (IDbConnection con = new NpgsqlConnection())
            {
                string sqlInsert = "INSERT INTO TestData VALUES(@Id, @Test)";
                con.Open();
                con.Execute(sqlInsert, testData);

                con
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }

        Console.WriteLine("Hello World!");
    }

    

    public class TestData
    {
        public int Id { get; set; }

        public string Test { get; set; }
    }


}