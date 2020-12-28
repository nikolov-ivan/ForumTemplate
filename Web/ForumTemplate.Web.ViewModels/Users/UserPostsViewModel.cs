namespace ForumTemplate.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using ForumTemplate.Web.ViewModels.Categories;

    public class UserPostsViewModel
    {
        public IEnumerable<PostInCategoryViewModel> Posts{ get; set; }
    }
}
