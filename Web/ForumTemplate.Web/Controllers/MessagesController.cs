namespace ForumTemplate.Web.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Data;
    using ForumTemplate.Web.ViewModels.Messages;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class MessagesController : Controller
    {
        private readonly IMessagesService messagesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsersService usersService;

        public MessagesController(
            IMessagesService messagesService,
            UserManager<ApplicationUser> userManager,
            IUsersService usersService)
        {
            this.messagesService = messagesService;
            this.userManager = userManager;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Received()
        {
            var userId = this.userManager.GetUserId(this.User);
            var receivedMessages = await this.messagesService.GetAllReceivedAsync<MessageViewModel>(userId);
            var model = new IndexViewModel
            {
                ReceivedMessages = receivedMessages,
            };
            return this.View(model);
        }

        public async Task<IActionResult> Send()
        {
            var userId = this.userManager.GetUserId(this.User);
            var sendMessages = await this.messagesService.GetAllSendAsync<MessageViewModel>(userId);
            var model = new IndexViewModel
            {
                SendMessages = sendMessages,
            };
            return this.View(model);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new CreatePrivateMessageInputModel
            {
                Users = await this.usersService.GetAllAsync<MessageUserViewModel>(),
            };
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePrivateMessageInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.messagesService.CreateAsync(input.Content, input.ReceiverId, userId, input.Title);
            return this.RedirectToAction("Index");
        }
    }
}
