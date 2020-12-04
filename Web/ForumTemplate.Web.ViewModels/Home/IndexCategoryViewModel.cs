namespace ForumTemplate.Web.ViewModels.Home
{
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }

        public string Url => $"/forum/{this.Name.Replace(' ', '-')}";
    }
}
