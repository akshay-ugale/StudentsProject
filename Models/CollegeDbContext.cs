using Microsoft.EntityFrameworkCore;

namespace StudentsProject.Models
{
    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> opt) 
            : base(opt)
        {

        }

        public DbSet<Student> Students { get; set; } = null;
        public DbSet<Course> Courses { get; set; } = null;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Course>()
        //        .HasKey(cs => new { cs.CourseId, cs.StudentId });
        //}
    }
}
