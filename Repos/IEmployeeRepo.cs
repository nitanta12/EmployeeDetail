using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Repos
{
    public interface IEmployeeRepo
    {
        Task<List<EmployeeDetail>> GetEmployeeDetailAsync();
        Task<EmployeeDetail> GetEmployeeByIdAsync(int id);

        Task<EmployeeDetail> EditEmployeeAsync(EmployeeDetail edt);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<EmployeeDetail> AddEmployeeAsync(EmployeeDetail edt);

        Task<bool> DetailAsync(int id);


    }
}
