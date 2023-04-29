using Rigel.EFCore.Data;

namespace Rigel.EFCore.Repositories
{
    public class BaseRepository<T, ID> : IBaseRepository<T, ID> where T : BaseModel<ID>
    {
        protected readonly DatabaseContext _db;
        public BaseRepository(DatabaseContext db) 
        {
            _db = db;
        }
        public virtual async Task<T> Create(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T?> Delete(T entity)
        {
            // T? entity = await _db.Set<T>().FindAsync(id);
            // if (entity == null)
            //     return null;
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T?> FindById(ID id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public virtual async Task<List<T>> FindAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> Update(T entity)
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}