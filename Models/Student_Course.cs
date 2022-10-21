namespace StudentsProject.Models
{
    public class Student_Course
    {
        public int Id { get; set; }

        public int studentId { get; set; }
        public Student student { get; set; }

        public int CourseId { get; set; }
        public Course course { get; set; }
    }
}
