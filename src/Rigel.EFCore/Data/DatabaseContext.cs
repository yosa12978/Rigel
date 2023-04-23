using Microsoft.EntityFrameworkCore;
using Rigel.Core;

namespace Rigel.EFCore
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) 
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(x => x.id);
            builder.Entity<Post>().HasKey(x => x.id);
            builder.Entity<Core.Thread>().HasKey(x => x.id);
            builder.Entity<Category>().HasKey(x => x.id);

            //TODO: add relations
            //TODO: also rename Core.Thread to Post and Core.Post to Message
        }

        public DbSet<User> users { get; set; } = default!;
        public DbSet<Category> categories { get; set; } = default!;
        public DbSet<Core.Thread> threads { get; set; } = default!;
        public DbSet<Post> posts { get; set; } = default!;
    }
}