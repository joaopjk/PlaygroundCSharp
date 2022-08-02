using Flunt.Notifications;
using IWantApp.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>()
                .HaveMaxLength(100);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<Product>()
                .Property(_ => _.Name).IsRequired();
            modelBuilder.Entity<Product>()
                .Property(_ => _.Description).HasMaxLength(255);

            modelBuilder.Entity<Category>()
                .Property(_ => _.Name).IsRequired();
        }
    }
}
