namespace ForumTemplate.Data.Models
{
    using ForumTemplate.Data.Common.Models;

    public class Message : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public string ReceiverId { get; set; }

        public virtual ApplicationUser Receiver { get; set; }
    }
}
