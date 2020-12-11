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
    }
}
