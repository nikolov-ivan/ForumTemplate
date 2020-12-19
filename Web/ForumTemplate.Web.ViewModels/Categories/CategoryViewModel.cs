namespace ForumTemplate.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }

        public IEnumerable<PostInCategoryViewModel> Posts { get; set; }
    }
}
