namespace ForumTemplate.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class CommentInPostViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public string UserUserName { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
