using Rigel.EFCore.Data;

namespace Rigel.EFCore.Repositories
{
    public class CategoryRepository : BaseRepository<Category, string>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext db) : base(db)
        {

        }
    }
}