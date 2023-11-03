using Domain.Infrastructure;
using Domain.Models;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repos
{
    public class EmployeeRepo : GenericRepo<EmployeeDetail>, IEmployeeRepo
    {
        public EmployeeRepo(EmployeeDetailsDbContext context) : base(context)
        {

        }
        public async Task<List<GetAllSP>> GetAllEmployeeFromProceAsync(int id)
        {
            var result = await _context.GetAllSps
            .FromSqlRaw($"EXECUTE spEmployeeDetails_GetAll {id}").ToListAsync().ConfigureAwait(false);
            return result;
        }
    }
}
