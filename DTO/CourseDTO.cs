using System.ComponentModel.DataAnnotations;

namespace StudentsProject.DTO
{
    public class CourseDTO 
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Professor { get; set; }
        public string Description { get; set; }
    }
}
