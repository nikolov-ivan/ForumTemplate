﻿namespace ForumTemplate.Web.Controllers
{
    using System.Threading.Tasks;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Data;
    using ForumTemplate.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(
            IVotesService votesService,
            UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.votesService.VoteAsync(input.PostId, user.Id, input.IsUpVote);
            var votes = this.votesService.GetVotes(input.PostId);
            return new VoteResponseModel { VotesCount = votes };
        }
    }
}
