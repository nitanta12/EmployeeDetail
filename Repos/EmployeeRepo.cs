using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeDetailsDbContext _context;

        public EmployeeRepo(EmployeeDetailsDbContext context) 
        {
            _context = context;
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var result = await GetEmployeeByIdAsync(id);
            if (result == null)
            {
                return false;
            }
           
            _context.EmployeeDetails.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> DetailAsync(int id)
        {
            throw new NotImplementedException();
        }
         public async Task<EmployeeDetail> AddEmployeeAsync(EmployeeDetail edt)
        {
            _context.EmployeeDetails.Add(edt);
            await _context.SaveChangesAsync();
            return edt;
        } 

        public async Task<EmployeeDetail> EditEmployeeAsync(EmployeeDetail edt)
        {
             _context.EmployeeDetails.Update(edt);
            await _context.SaveChangesAsync();
            return edt;
        }

        public async Task<EmployeeDetail> GetEmployeeByIdAsync(int id)
        {
            if(id == null || _context.EmployeeDetails == null)
            {
                return null;
            }
            var result = await _context.EmployeeDetails.FindAsync(id);
           if(result == null)
            {
                return null;
            }
           return result;
        }

        public async Task<List<EmployeeDetail>> GetEmployeeDetailAsync()
        {
            var data=await _context.EmployeeDetails.ToListAsync();
            return data;
            
        }
    }
}
