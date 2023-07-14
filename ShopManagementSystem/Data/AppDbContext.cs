using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext>options) :base(options)
        {
            
        }
        public DbSet<Item>Items { get; set; }
    }
    
}
