using Rigel.Core.Models;

namespace Rigel.Core.Repositories
{
    public interface IBaseRepository<T, ID> where T : BaseModel<ID>
    {
        Task<List<T>> FindAll();
        Task<T?> FindById(ID id);
        Task<T> Create(T entity);
        Task<T?> Update(T entity);
        Task<T?> Delete(T entity);
    }
}