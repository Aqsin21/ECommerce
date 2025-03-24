using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;


namespace ECommerce.Infrastructure.EfCore.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-L886DE2;Database=ECommerce;Trusted_Connection=True;TrustServerCertificate=true");
        }



    }
}
