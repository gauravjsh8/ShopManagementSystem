using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext>options) :base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShopManagementSystem.Models.ShopInformation> ShopInformation { get; set; } = default!;
    }
    
}
