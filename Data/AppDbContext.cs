using CommentSchema.Models;
using Microsoft.EntityFrameworkCore;
using PostSchema.Models;
using UserSchema.Models;
namespace NetApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Post> Post { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = Guid.Parse("d2b1b5c3-cc47-4f64-bb9b-f3b4b32f9eaf"),
                    Name = "Test User",
                    Password = "testpassword"
                }
            );

            // User -> Post
            modelBuilder.Entity<User>()
            .HasMany(u => u.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            // User -> Comment
            modelBuilder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            // Post -> Comment
            modelBuilder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);

            // CommentedAt set default configs
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(c => c.CommentedAt)
                .HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}