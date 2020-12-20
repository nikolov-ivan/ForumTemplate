namespace ForumTemplate.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using ForumTemplate.Services.Data;
    using ForumTemplate.Web.ViewModels;
    using ForumTemplate.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();
            var categories = await this.categoriesService.GetAllAsync<IndexCategoryViewModel>();
            viewModel.Categories = categories;
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
