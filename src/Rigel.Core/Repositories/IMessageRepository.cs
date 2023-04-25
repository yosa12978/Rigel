using Rigel.Core.Models;

namespace Rigel.Core.Repositories
{
    public interface IMessageRepository : IBaseRepository<Message, string>
    {
        Task<List<Message>> FindPostMessages(string postId);
    }
}