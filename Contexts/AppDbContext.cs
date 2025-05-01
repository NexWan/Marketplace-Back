using Microsoft.EntityFrameworkCore;
using MarketplaceAPI.Models;

namespace MarketplaceAPI.Contexts
{
    /*
     * AppDbContext class represents the database context for the marketplace application.
     * It inherits from DbContext and contains DbSet properties for Product and Category entities.
     */
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}