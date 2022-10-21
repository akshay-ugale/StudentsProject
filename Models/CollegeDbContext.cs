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
        public DbSet<Student_Course> Student_Courses { get; set; } = null;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student_Course>()
        //        .HasOne(m => m.Students)
        //        .WithMany(ma => ma.Movie_Actors)
        //        .HasForeignKey(m => m.MovieId);

        //    modelBuilder.Entity<Student_Course>()
        //        .HasOne(a => a.Actor)
        //        .WithMany(am => am.Movie_Actors)
        //        .HasForeignKey(a => a.ActorId);
        //}
    }
}
