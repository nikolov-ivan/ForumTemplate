namespace ForumTemplate.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using ForumTemplate.Web.ViewModels.Posts;

    public class UserCommentsViewModel
    {
        public List<PostViewModel> Posts { get; set; }
    }
}
