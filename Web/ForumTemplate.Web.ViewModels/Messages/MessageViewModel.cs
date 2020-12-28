namespace ForumTemplate.Web.ViewModels.Messages
{
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class MessageViewModel : IMapFrom<Message>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int? ParentMessage { get; set; }

        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string SenderUserName { get; set; }
    }
}
