namespace ForumTemplate.Web.ViewModels.Messages
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class CreatePrivateMessageInputModel : IMapFrom<Message>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string ReceiverId { get; set; }

        public IEnumerable<MessageUserViewModel> Users { get; set; }
    }
}
