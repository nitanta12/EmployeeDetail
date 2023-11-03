using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace ServiceLayer
{
    public interface IEmployeeServiceLayer
    {
        //Task<bool> GetEmployeeDetailAsync();
        Task<EmployeeDetail> AddEmployeeAsync(EmployeeDetail edt,IFormFile Files);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<bool> EditEmployeeAsync(EmployeeDetail edt);
        
        Task<EmployeeDetail> GetEmployeeByIdAsync(int id);

        Task<GetAllSP> DetailByIdAsync(int id);
        Task<List<GetAllSP>> GetEmployeeDetailAsync();

        Task<List<EmployeeDetail>> GetEmployees();
        Task<string> UploadFiles( IFormFile FileUp);

            //Task<bool> DetailAsync(int id);
        }
}
