using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {
            
        }
        public DbSet<Registrations> Registrations { get; set; }
    }
}
