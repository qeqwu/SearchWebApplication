using Microsoft.EntityFrameworkCore;



namespace WebApplicationTestWeb.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Item> Item { get; set; }
    }
}
