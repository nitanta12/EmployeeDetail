using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("EmployeeDetails")]
    public class EmployeeDetail
    {
       public int Id { get; set; }
        [Required]
        
        public string FirstName { get; set; }
        [Required]
       
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        
        public string Enrollment { get; set; }
       
        [Required]
        public DateTime? DateOfBirth { get; set; }
      
        public int? DId { get; set; }
        public Guid? CreateBy { get; set; } 
        public DateTime? CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string FileUrl { get; set; }
       
    }
}
