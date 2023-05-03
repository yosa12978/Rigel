using Microsoft.Extensions.Logging;
using Rigel.Services.Interfaces;

namespace Rigel.Services.Impl 
{
    public class MessageService : IMessageService
    {
        private readonly IIdGenerator _idgen;
        private readonly IMessageRepository _messageRepository;
        private readonly ILogger<MessageService> _logger;
        public MessageService(IMessageRepository messageRepository, IIdGenerator idgen, ILogger<MessageService> logger)
        {
            _messageRepository = messageRepository;
            _idgen = idgen;
            _logger = logger;
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
            _logger.LogInformation($"creating message with id = {message.id}");
            return MessageDto.MapToDto(message);
        }

        public async Task<MessageDto> DeleteMessage(string messageId, string userId)
        {
            Message? message = await _messageRepository.FindById(messageId);
            if (message == null || message.authorId != userId)
                throw new NotFoundException("post not found");
            await _messageRepository.Delete(message);
            _logger.LogInformation($"deleting message with id = {message.id}");
            return MessageDto.MapToDto(message);
        }

        public async Task<MessageDto> FindMessage(string messageId)
        {
            Message? message = await _messageRepository.FindById(messageId);
            if (message == null)
                throw new NotFoundException("message not found");
            _logger.LogInformation($"returning message with id = {message.id}");
            return MessageDto.MapToDto(message);
        }

        public async Task<PaginatedList<MessageDto>> FindPostMessages(string postId, int page = 1)
        {
            List<Message> messages = await _messageRepository.FindPostMessages(postId);
            _logger.LogInformation($"returning messages with postId = {postId}");
            return await Task.Run(() => new PaginatedList<MessageDto>(messages.Select(x => MessageDto.MapToDto(x)), page));
        }
        
        public async Task<MessageDto> UpdateMessage(UpdateMessageDto dto, string messageId, string userId)
        {
            Message? message = await _messageRepository.FindById(messageId);
            if (message == null || message.authorId != userId)
                throw new NotFoundException("post not found");
            message.content = dto.content ?? message.content;
            message.edited = true;
            _logger.LogInformation($"updating message with id = {message.id}");
            return MessageDto.MapToDto(await _messageRepository.Update(message));
        }
    }
}