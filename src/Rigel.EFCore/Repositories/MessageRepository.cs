using Rigel.EFCore.Data;

namespace Rigel.EFCore.Repositories
{
    public class MessageRepository : BaseRepository<Message, string>, IMessageRepository
    {
        public MessageRepository(DatabaseContext db) : base(db)
        {

        }
        public async Task<List<Message>> FindPostMessages(string postId) 
        {
            return await _db.messages
                            .Where(x => x.postId == postId)
                            .OrderBy(x => x.pubDate)
                            .ToListAsync();
        }
    }
}