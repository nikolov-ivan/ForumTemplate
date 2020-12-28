namespace ForumTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMessagesService
    {
        Task<IEnumerable<T>> GetAllReceivedAsync<T>(string receiverId);

        Task<IEnumerable<T>> GetAllSendAsync<T>(string senderId);
    }
}
