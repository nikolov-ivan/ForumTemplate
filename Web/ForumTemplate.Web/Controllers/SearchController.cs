namespace ForumTemplate.Web.Controllers
{
    using System.Threading.Tasks;

    using ForumTemplate.Services.Data;
    using ForumTemplate.Web.ViewModels.Posts;
    using ForumTemplate.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : Controller
    {
        private readonly IPostsService postsService;

        public SearchController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var posts = await this.postsService.GetAllAsync<PostViewModel>(searchString);

            var model = new SearchViewModel
            {
                SearchString = searchString,
                Posts = posts,
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {
            return this.RedirectToAction("Index", new { searchString });
        }
    }
}
