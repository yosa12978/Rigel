namespace Rigel.Services.Interfaces
{
    public interface IMessageService
    {
        Task<List<MessageDto>> FindPostMessages(string postId);
        Task<MessageDto> FindMessage(string messageId);
        Task<MessageDto> CreateMessage(CreateMessageDto dto, string userId, string? parentId);
        Task<MessageDto> UpdateMessage(UpdateMessageDto dto, string messageId, string userId);
        Task<MessageDto> DeleteMessage(string messageId, string userId);
    }
}