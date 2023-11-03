using Domain.Infrastructure;
using Domain.Models;

namespace Domain.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly EmployeeDetailsDbContext _context;
        public GenericRepo(EmployeeDetailsDbContext context)
        {
            _context = context;
        }
        public void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return  await _context.Set<T>().FindAsync(id);
        }

        public async Task Insert(T obj)
        {
            await _context.Set<T>().AddAsync(obj).ConfigureAwait(false);
        }

        public void  Update(T obj)
        {
            _context.Set<T>().Update(obj);
        }
    }
}
