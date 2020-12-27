namespace ForumTemplate.Web.Controllers
{
    using System.Threading.Tasks;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Data;
    using ForumTemplate.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;

        public PostsController(
            UserManager<ApplicationUser> userManager,
            IPostsService postsService,
            ICategoriesService categoriesService)
        {
            this.userManager = userManager;
            this.postsService = postsService;
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> ById(int id)
        {
            var postModel = await this.postsService.GetByIdAsync<PostViewModel>(id);
            return this.View(postModel);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var categories = await this.categoriesService.GetAllAsync<CategoryDropDownViewModel>();
            var viewModel = new PostCreateInputModel
            {
                Categories = categories,
            };
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(PostCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var categories = await this.categoriesService.GetAllAsync<CategoryDropDownViewModel>();
                var model = new PostCreateInputModel
                {
                    Categories = categories,
                    Name = input.Name,
                    Content = input.Content,
                    CategoryId = input.CategoryId,
                };

                return this.View(model);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var postId = await this.postsService.CreateAsync(input.Name, input.Content, input.CategoryId, user.Id);

            return this.RedirectToAction(nameof(this.ById), new { id = postId });
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await this.categoriesService.GetAllAsync<CategoryDropDownViewModel>();
            var postModel = await this.postsService.GetByIdAsync<PostEditInputModel>(id);
            if (postModel == null)
            {
                return this.NotFound();
            }

            postModel.Categories = categories;
            var user = await this.userManager.GetUserAsync(this.User);
            if (postModel.UserId != user.Id)
            {
                return this.Unauthorized();
            }

            return this.View(postModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(PostEditInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var categories = await this.categoriesService.GetAllAsync<CategoryDropDownViewModel>();
                input.Categories = categories;
                return this.View(input);
            }

            await this.postsService.EditAsync(input.Name, input.Content, input.CategoryId, input.Id);
            return this.RedirectToAction(nameof(this.ById), new { input.Id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var post = await this.postsService.GetByIdAsync<PostViewModel>(id);
            if (user.UserName != post.UserUsername)
            {
                return this.Unauthorized();
            }

            await this.postsService.DeleteAsync(post.Id);
            return this.View();
        }
    }
}
