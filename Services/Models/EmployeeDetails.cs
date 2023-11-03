using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Models
{
    [Table("EmployeeDetails")]
    public class EmployeeDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Enrollment { get; set; } = null!;

       
    }
}
