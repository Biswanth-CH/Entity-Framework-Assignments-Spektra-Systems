using Microsoft.EntityFrameworkCore;
using Product_Inventory.Models;

namespace Product_Inventory.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions opt) : base(opt)
        {

        }
        public DbSet<product> product { get; set; }
    }
}

