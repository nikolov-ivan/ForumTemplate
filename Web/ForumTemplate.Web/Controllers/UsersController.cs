namespace ForumTemplate.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Data;
    using ForumTemplate.Web.ViewModels.Categories;
    using ForumTemplate.Web.ViewModels.Posts;
    using ForumTemplate.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostsService postsService;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            IPostsService postsService)
        {
            this.userManager = userManager;
            this.postsService = postsService;
        }

        public async Task<IActionResult> Profile()
        {
            return this.View();
        }

        public async Task<IActionResult> Posts()
        {
            var userId = this.userManager.GetUserId(this.User);
            var posts = await this.postsService.GetAllAsyncByUser<PostInCategoryViewModel>(userId);
            var model = new UserPostsViewModel
            {
                Posts = posts,
            };
            return this.View(model);
        }

        public async Task<IActionResult> Comments()
        {
            var userId = this.userManager.GetUserId(this.User);
            var posts = await this.postsService.GetAllPostsAsync<PostViewModel>();
            var model = new UserCommentsViewModel { Posts = new List<PostViewModel>() };
            foreach (var post in posts)
            {
                if (post.Comments.Any(x => x.UserId == userId))
                {
                    model.Posts.Add(post);
                }
            }

            return this.View(model);
        }
    }
}
