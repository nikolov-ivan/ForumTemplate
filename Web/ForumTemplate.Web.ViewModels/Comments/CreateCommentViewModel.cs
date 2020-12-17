namespace ForumTemplate.Web.ViewModels.Comments
{
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class CreateCommentViewModel : IMapFrom<Comment>
    {
        public string UserUserName { get; set; }

        public string Content { get; set; }
    }
}
