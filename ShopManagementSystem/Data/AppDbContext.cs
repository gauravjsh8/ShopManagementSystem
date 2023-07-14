using Microsoft.EntityFrameworkCore;

namespace ShopManagementSystem.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext>options) :base(options)
        {
            
        }
    }
    
}
