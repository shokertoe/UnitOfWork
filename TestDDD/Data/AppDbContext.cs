using Microsoft.EntityFrameworkCore;

namespace TestDDD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(x=> x.Login).IsUnique();

            builder.Entity<User>()
                .HasIndex(x => x.Email).IsUnique();
        }

        public DbSet<User> Users { get; set; }
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }
}
