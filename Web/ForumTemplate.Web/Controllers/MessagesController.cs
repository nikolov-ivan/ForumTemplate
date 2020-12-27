namespace ForumTemplate.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class MessagesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return this.View();
        }
    }
}
