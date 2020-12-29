namespace ForumTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumTemplate.Services.Data;
    using ForumTemplate.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private const int ItemsPerPage = 10;
        private readonly ICategoriesService categoriesService;
        private readonly IPostsService postsService;

        public CategoriesController(
            ICategoriesService categoriesService,
            IPostsService postsService)
        {
            this.categoriesService = categoriesService;
            this.postsService = postsService;
        }

        public async Task<IActionResult> ByName(string name, int page = 1)
        {
            var viewModel = await this.categoriesService.GetByName<CategoryViewModel>(name.Replace("-", " "));
            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.ForumPosts = await this.postsService.GetByCategoryId<PostInCategoryViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage);
            var count = this.postsService.GetCountByCategoryId(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);
            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }
    }
}
