namespace ForumTemplate.Web.ViewModels.Posts
{
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
