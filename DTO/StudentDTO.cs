using System.ComponentModel.DataAnnotations;

namespace StudentsProject.DTO
{
    public class StudentDTO
    {
        [Required]
        public string Name { get; set; }

        [Required] 
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
