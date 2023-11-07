using Microsoft.EntityFrameworkCore;

namespace Backendy.Models
{
    public class backendDBContext: DbContext
    {
        public backendDBContext(DbContextOptions<backendDBContext> options):
            base(options)
        {

        }
        public DbSet<moneySystem> money_system { get; set; }
        public DbSet<UserTable> user_table { get; set; }
        public DbSet<CommentTable> comment_table { get; set; }
    }
}
