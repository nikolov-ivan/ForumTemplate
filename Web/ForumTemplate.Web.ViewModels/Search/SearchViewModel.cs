namespace ForumTemplate.Web.ViewModels.Search
{
    using System.Collections.Generic;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;
    using ForumTemplate.Web.ViewModels.Posts;

    public class SearchViewModel
    {
        public string SearchString { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
