using Microsoft.EntityFrameworkCore;

namespace Services.Models
{
    public class EmployeeDetailsDbContext:DbContext
    {
        public EmployeeDetailsDbContext(DbContextOptions<EmployeeDetailsDbContext> options): base(options)
        {

        }

        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
    }
}
