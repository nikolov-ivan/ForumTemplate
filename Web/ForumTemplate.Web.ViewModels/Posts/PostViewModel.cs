namespace ForumTemplate.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class PostViewModel : IMapFrom<Post>
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public string UserUsername { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int PostDate => (DateTime.UtcNow.Date - this.CreatedOn.Date).Days;

        public IEnumerable<CommentInPostViewModel> Comments { get; set; }
    }
}
