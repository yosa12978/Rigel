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

            builder.Entity<User>().HasData(
                new User {
                    id = "Ul524hmF82",
                    username = "admin",
                    nickname = "master",
                    password = "c73d82322484717cb277b3146a968928",
                    salt = "adminsalt",
                    avatar = "https://cdn-6.motorsport.com/images/mgl/Y99JQRbY/s8/red-bull-racing-logo-1.jpg"
                }
            );

            builder.Entity<User>().HasData(
                new User {
                    id = "h80G46mN5p",
                    username = "user",
                    nickname = "slave",
                    password = "22b1f2494b8b75f069b5b00cc29e07ef",
                    salt = "usersalt",
                    avatar = "https://cdn.gpblog.com/news/2023/05/07/v2_large_7daff622d2093db14e6e82ff5810c16d444b8a8a.jpeg"
                }
            );

            builder.Entity<Category>().HasData(
                new Category {
                    id = "aS2Fg5J77o",
                    name = "test"
                }
            );

            builder.Entity<Post>().HasData(
                new Post {
                    id = "sdgweruhiq",
                    subject = "test subject 1",
                    categoryId = "aS2Fg5J77o",
                    authorId = "h80G46mN5p"
                }
            );

            builder.Entity<Message>().HasData(
                new Message {
                    id = "1234567890",
                    content = "test content 123",
                    authorId = "Ul524hmF82",
                    postId = "sdgweruhiq"
                }
            );

            builder.Entity<Message>().HasData(
                new Message {
                    id = "0987654321",
                    content = "test reply 1",
                    authorId = "h80G46mN5p",
                    postId = "sdgweruhiq",
                    parentId = "1234567890"
                }
            );
        }

        public DbSet<User> users { get; set; } = default!;
        public DbSet<Category> categories { get; set; } = default!;
        public DbSet<Post> posts { get; set; } = default!;
        public DbSet<Message> messages { get; set; } = default!;
    }
}