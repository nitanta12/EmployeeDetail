using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class EmployeeDetailsDbContext:DbContext
    {
        public EmployeeDetailsDbContext(DbContextOptions<EmployeeDetailsDbContext> options): base(options)
        {

        }

        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<GetAllSP> GetAllSps { get; set; }

    }
}
