using System.ComponentModel.DataAnnotations;

namespace StudentsProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required] //Add Regular expression to check valid email
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public ICollection<Course> courses { get; set; }
    }
}
