using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class EmployeeDetailsDbContext:DbContext
    {
        public EmployeeDetailsDbContext(DbContextOptions<EmployeeDetailsDbContext> options): base(options)
        {

        }

        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
    }
}
