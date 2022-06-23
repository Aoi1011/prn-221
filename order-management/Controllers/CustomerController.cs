using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace order_management.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    [HttpPost]
    public static async void InsertCustomer(int id, string name, string address, string city, string postal_code)
    {
        var connString = "Host=postgressql_database;Username=admin;Password=admin;Database=SampleDatabase";
        var command = "INSERT INTO customer (customer_id, customer_name, customer_address, city, state, postal_code) VALUES (@p)";

        await using var conn = new NpgsqlConnection(connString);
        await conn.OpenAsync();

        var customer = new Customer {
            CustomerId: id,

    CustomerName

    public int CustomerAddress { get; set; }

    public int City { get; set; }

    public int State { get; set; }

    public int Postal_Code { get; set; }
};

// Insert some data
await using (var cmd = new NpgsqlCommand(command, conn))
        {
            cmd.Parameters.AddWithValue("p", customer);
            await cmd.ExecuteNonQueryAsync();
        }

    }

    private readonly ILogger<WeatherForecastController> _logger;

public CustomerController(ILogger<WeatherForecastController> logger)
{
    _logger = logger;
}

[HttpGet]
public IEnumerable<WeatherForecast> Get()
{
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    })
    .ToArray();
}
}
