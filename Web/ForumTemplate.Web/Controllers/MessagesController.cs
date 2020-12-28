namespace ForumTemplate.Web.Controllers
{
    using System.Threading.Tasks;
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Data;
    using ForumTemplate.Web.ViewModels.Messages;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class MessagesController : Controller
    {
        private readonly IMessagesService messagesService;
        private readonly UserManager<ApplicationUser> userManager;

        public MessagesController(
            IMessagesService messagesService,
            UserManager<ApplicationUser> userManager)
        {
            this.messagesService = messagesService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            //var userId = this.userManager.GetUserId(this.User);
            //var receivedMessages = await this.messagesService.GetAllReceivedAsync<MessageViewModel>(userId);
            //var sendMessages = await this.messagesService.GetAllSendAsync<MessageViewModel>(userId);
            //var model = new IndexViewModel
            //{
            //    SendMessages = sendMessages,
            //    ReceivedMessages = receivedMessages,
            //};
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
    }
}
