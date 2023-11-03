namespace Domain.Models
{
    public class GetAllSP
    {
       public int Id { get; set; }

       public string FullName { get; set; }

       public string Address { get; set; }
       public DateTime? DateOfBirth { get; set; }

        public int? Age { get; set; }

        public string Department { get; set; }

        public string FileUrl { get; set; }
    }
}
