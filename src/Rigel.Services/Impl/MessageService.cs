using Rigel.Services.Interfaces;

namespace Rigel.Services.Impl 
{
    public class MessageService : IMessageService
    {
        public Task<Message?> CreateMessage(CreateMessageDto dto, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Message?> DeleteMessage(string messageId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Message> FindMessage(string messageId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> FindPostMessages(string postId)
        {
            throw new NotImplementedException();
        }

        public Task<Message?> ReplyMessage(CreateMessageDto dto, string parentId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Message?> UpdateMessage(UpdateMessageDto dto, string userId)
        {
            throw new NotImplementedException();
        }
    }
}