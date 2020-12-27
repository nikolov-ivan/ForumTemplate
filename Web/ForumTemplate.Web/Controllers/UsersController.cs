namespace ForumTemplate.Web.Controllers
{
    using System.Threading.Tasks;

    using ForumTemplate.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> usermanager;

        public UsersController(UserManager<ApplicationUser> usermanager)
        {
            this.usermanager = usermanager;
        }

        public async Task<IActionResult> Profile()
        {
            return this.View();
        }
    }
}
