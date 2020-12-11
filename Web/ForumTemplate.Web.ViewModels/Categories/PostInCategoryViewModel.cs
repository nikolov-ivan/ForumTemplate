namespace ForumTemplate.Web.ViewModels.Categories
{
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }

        public string Content { get; set; }
    }
}
