using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Infrastructure
{
    public interface IEmployeeRepo : IGenericRepo<EmployeeDetail>
    {

        Task<List<GetAllSP>> GetAllEmployeeFromProceAsync(int id);
    }
}
