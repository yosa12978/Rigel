namespace Rigel.EFCore.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
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
            builder.Entity<Message>().HasKey(x => x.id);
            builder.Entity<Category>().HasKey(x => x.id);

            builder.Entity<Post>().Navigation(x => x.author).AutoInclude();
            builder.Entity<Post>().Navigation(x => x.category).AutoInclude();
            builder.Entity<Message>().Navigation(x => x.author).AutoInclude();
            builder.Entity<Message>().Navigation(x => x.parent).AutoInclude();
            builder.Entity<Message>().Navigation(x => x.post).AutoInclude();

            builder.Entity<User>()
                .HasMany<Post>(x => x.posts)
                .WithOne(x => x.author)
                .HasForeignKey(x => x.authorId);
            builder.Entity<User>()
                .HasMany(x => x.messages)
                .WithOne(x => x.author)
                .HasForeignKey(x => x.authorId);

            builder.Entity<Post>()
                .HasMany(x => x.messages)
                .WithOne(x => x.post)
                .HasForeignKey(x => x.postId);
            builder.Entity<Post>()
                .HasOne(x => x.author)
                .WithMany(x => x.posts)
                .HasForeignKey(x => x.authorId);
            builder.Entity<Post>()
                .HasOne(x => x.category)
                .WithMany(x => x.posts)
                .HasForeignKey(x => x.categoryId);

            builder.Entity<Message>()
                .HasOne(x => x.author)
                .WithMany(x => x.messages)
                .HasForeignKey(x => x.authorId);
            builder.Entity<Message>()
                .HasOne(x => x.parent)
                .WithMany(x => x.replies)
                .HasForeignKey(x => x.parentId);
            builder.Entity<Message>()
                .HasOne(x => x.post)
                .WithMany(x => x.messages)
                .HasForeignKey(x => x.postId);
        }

        public DbSet<User> users { get; set; } = default!;
        public DbSet<Category> categories { get; set; } = default!;
        public DbSet<Post> posts { get; set; } = default!;
        public DbSet<Message> messages { get; set; } = default!;
    }
}