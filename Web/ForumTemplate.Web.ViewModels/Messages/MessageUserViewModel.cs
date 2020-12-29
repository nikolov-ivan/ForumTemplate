namespace ForumTemplate.Web.ViewModels.Messages
{
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class MessageUserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }
    }
}
