using GoDAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GoDAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Battle> Battles { get; set; }
    }
}