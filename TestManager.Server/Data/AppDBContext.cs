using Microsoft.EntityFrameworkCore;
using TestManager.Server.Data.Models;

namespace TestManager.Server.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
    {
        public DbSet<Test> Tests { get; set; }
    }
}
