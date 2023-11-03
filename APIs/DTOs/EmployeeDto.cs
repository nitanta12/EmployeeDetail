using System.ComponentModel.DataAnnotations;

namespace APIs.DTOs
{
    public class EmployeeDto
    {
        public int? Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        public string Enrollment { get; set; }

        public int? DId { get; set; }
       
        [Required]
        public DateTime? DateOfBirth { get; set; }

        public IFormFile Files { get; set; }

    }
}
