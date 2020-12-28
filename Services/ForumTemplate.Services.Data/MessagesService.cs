namespace ForumTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumTemplate.Data.Common.Repositories;
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class MessagesService : IMessagesService
    {
        private readonly IDeletableEntityRepository<Message> messagesRepository;

        public MessagesService(IDeletableEntityRepository<Message> messagesRepository)
        {
            this.messagesRepository = messagesRepository;
        }

        public async Task<IEnumerable<T>> GetAllReceivedAsync<T>(string receiverId)
        {
            return await this.messagesRepository.All().Where(x => x.ReceiverId == receiverId).To<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllSendAsync<T>(string senderId)
        {
            return await this.messagesRepository.All().Where(x => x.SenderId == senderId).To<T>().ToListAsync();
        }
    }
}
