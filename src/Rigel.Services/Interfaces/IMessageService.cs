namespace Rigel.Services.Interfaces
{
    public interface IMessageService
    {
        Task<List<MessageDto>> FindPostMessages(string postId);
        Task<MessageDto> FindMessage(string messageId);
        Task<MessageDto> CreateMessage(CreateMessageDto dto, string userId);
        Task<MessageDto> UpdateMessage(UpdateMessageDto dto, string userId);
        Task<MessageDto> DeleteMessage(string messageId, string userId);
        Task<MessageDto> ReplyMessage(CreateMessageDto dto, string parentId, string userId);
    }
}