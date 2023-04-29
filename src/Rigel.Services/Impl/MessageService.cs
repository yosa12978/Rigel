using Rigel.Services.Interfaces;

namespace Rigel.Services.Impl 
{
    public class MessageService : IMessageService
    {
        private readonly IIdGenerator _idgen;
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository, IIdGenerator idgen)
        {
            _messageRepository = messageRepository;
            _idgen = idgen;
        }

        public Task<MessageDto> CreateMessage(CreateMessageDto dto, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<MessageDto> DeleteMessage(string messageId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<MessageDto> FindMessage(string messageId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MessageDto>> FindPostMessages(string postId)
        {
            throw new NotImplementedException();
        }

        public Task<MessageDto> ReplyMessage(CreateMessageDto dto, string parentId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<MessageDto> UpdateMessage(UpdateMessageDto dto, string userId)
        {
            throw new NotImplementedException();
        }
    }
}