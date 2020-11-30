using ForumTemplate.Data.Models;
using ForumTemplate.Services.Mapping;

namespace ForumTemplate.Web.ViewModels.Home
{
    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}