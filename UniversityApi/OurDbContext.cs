using Microsoft.EntityFrameworkCore;

namespace UniversityApi
{
    public class OurDbContext : DbContext
    {
        public OurDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Professor> Professors { get; set;}

        public DbSet<Student> Students { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
