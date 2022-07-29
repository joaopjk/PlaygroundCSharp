using Microsoft.EntityFrameworkCore;

namespace GraphQL.Api.Data
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Course> Course { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Lecture> Lecture { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lecture>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Subject>("Subject")
                .HasValue<Assignment>("Assignment");
        }
    }
}
