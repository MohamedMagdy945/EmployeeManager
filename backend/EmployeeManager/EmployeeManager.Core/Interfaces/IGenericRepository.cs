
using System.Linq.Expressions;

namespace EmployeeManager.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task UpdateAsync(T entity);
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<int> CountAsync();
    }
}
