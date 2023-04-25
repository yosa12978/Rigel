using Rigel.EFCore.Data;

namespace Rigel.EFCore.Repositories
{
    public class PostRepository : BaseRepository<Post, string>, IPostRepository
    {
        public PostRepository(DatabaseContext db) : base(db)
        {

        }

        public async Task<List<Post>> FindCategoryPosts(string categoryId)
        {
            return await _db.posts
                            .Where(x => x.categoryId == categoryId)
                            .OrderByDescending(x => x.changeDate)
                            .ToListAsync();
        }
    }
}