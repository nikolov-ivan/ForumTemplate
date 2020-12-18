namespace ForumTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumTemplate.Data.Common.Repositories;
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Data;
    using ForumTemplate.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class Posts : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;

        public Posts(
            UserManager<ApplicationUser> userManager,
            IPostsService postsService,
            ICategoriesService categoriesService)
        {
            this.userManager = userManager;
            this.postsService = postsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult ById(int id)
        {
            var postModel = this.postsService.GetById<PostViewModel>(id);
            return this.View(postModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
            var viewModel = new PostCreateModel
            {
                Categories = categories,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
                var model = new PostCreateModel
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
    }
}
