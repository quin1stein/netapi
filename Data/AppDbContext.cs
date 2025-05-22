using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Task.Models;
namespace NetApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }

    }
}