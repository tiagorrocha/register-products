using Microsoft.EntityFrameworkCore;
using RegisterProducts.Models;

namespace RegisterProducts.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
            {
            }
        public DbSet<Product> Product { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}