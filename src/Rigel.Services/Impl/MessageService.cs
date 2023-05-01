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

        public async Task<MessageDto> CreateMessage(CreateMessageDto dto, string userId, string? parentId = null)
        {
            Message message = new Message
            {
                id = _idgen.NewId(),
                content = dto.content,
                postId = dto.postId,
                authorId = userId,
                parentId = parentId,
            };
            await _messageRepository.Create(message);
            return MessageDto.MapToDto(message);
        }

        public async Task<MessageDto> DeleteMessage(string messageId, string userId)
        {
            Message? message = await _messageRepository.FindById(messageId);
            if (message == null || message.authorId != userId)
                throw new NotFoundException("post not found");
            await _messageRepository.Delete(message);
            return MessageDto.MapToDto(message);
        }

        public async Task<MessageDto> FindMessage(string messageId)
        {
            Message? message = await _messageRepository.FindById(messageId);
            if (message == null)
                throw new NotFoundException("message not found");
            return MessageDto.MapToDto(message);
        }

        public async Task<List<MessageDto>> FindPostMessages(string postId)
        {
            List<Message> messages = await _messageRepository.FindPostMessages(postId);
            return await Task.Run(() => messages.Select(x => MessageDto.MapToDto(x)).ToList());
        }
        
        public async Task<MessageDto> UpdateMessage(UpdateMessageDto dto, string messageId, string userId)
        {
            Message? message = await _messageRepository.FindById(messageId);
            if (message == null || message.authorId != userId)
                throw new NotFoundException("post not found");
            message.content = dto.content ?? message.content;
            message.edited = true;
            return MessageDto.MapToDto(await _messageRepository.Update(message));
        }
    }
}