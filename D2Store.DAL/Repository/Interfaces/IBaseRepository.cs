using D2Store.Domain.Entities;

namespace D2Store.DAL.Repository.Interfaces
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> GetById(int id);

        Task<bool> RemoveByIdAsync(int id);

    }
}
