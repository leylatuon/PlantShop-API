using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using PlantShop.Models;
namespace PlantShop.Models
{
    public class PlantShopDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public PlantShopDBContext(DbContextOptions<PlantShopDBContext> options, IConfiguration configuration) : base(options) { Configuration = configuration; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("PlantShopConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;


    }
}
