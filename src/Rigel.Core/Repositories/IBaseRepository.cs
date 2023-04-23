namespace Rigel.Core
{
    public interface IBaseRepository<T, ID> where T : BaseModel<ID>
    {
        Task<List<T>> GetAll();
        Task<T> FindById(ID id);
        Task<T> Create(T entity);
        Task<T> Update(ID id, T entity);
        Task<T> Delete(ID id);
    }
}