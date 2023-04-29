namespace Rigel.Services.Interfaces
{
    public interface IMessageService
    {
        Task<List<Message>> FindPostMessages(string postId);
        Task<Message> FindMessage(string messageId);
        Task<Message> CreateMessage(CreateMessageDto dto, string userId);
        Task<Message> UpdateMessage(UpdateMessageDto dto, string userId);
        Task<Message> DeleteMessage(string messageId, string userId);
        Task<Message> ReplyMessage(CreateMessageDto dto, string parentId, string userId);
    }
}