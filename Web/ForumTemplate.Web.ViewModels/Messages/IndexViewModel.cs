namespace ForumTemplate.Web.ViewModels.Messages
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<MessageViewModel> ReceivedMessages { get; set; }

        public IEnumerable<MessageViewModel> SendMessages { get; set; }
    }
}
