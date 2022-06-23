using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace order_management2.Models
{
    public class OrderManagementContext : DbContext
    {
        public OrderManagementContext(DbContextOptions<OrderManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
        public DbSet<OrderLine> OrderLine { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
    }
}