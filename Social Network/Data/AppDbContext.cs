using Microsoft.EntityFrameworkCore;
using Social_Network.Models;
namespace Social_Network.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Social_Network.Models.Newsfeed> Newsfeed { get; set; } = default!;
    }
}
