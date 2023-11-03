namespace Domain.Infrastructure
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
