using System.ComponentModel.DataAnnotations;

namespace StudentsProject.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Professor { get; set; }
        public string Description { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
