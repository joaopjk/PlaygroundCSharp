using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Context
{
    public class ManagerContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public ManagerContext() { }
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=USERMANAGERAPI;user id=SA;Password=Root@123root");
        }
    }
}
