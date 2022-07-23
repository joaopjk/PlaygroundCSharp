using Microsoft.EntityFrameworkCore;

namespace GraphQLApi.Data
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
                .HasDiscriminator<string>("Discriminatio")
                .HasValue<Subject>("Subject")
                .HasValue<Assignment>("Assignment");
        }
    }
}
