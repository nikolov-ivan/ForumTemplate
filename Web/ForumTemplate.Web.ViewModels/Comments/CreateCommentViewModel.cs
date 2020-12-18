namespace ForumTemplate.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class CreateCommentViewModel : IMapFrom<Comment>
    {
        public string UserUserName { get; set; }

        [Required]
        [Display(Name ="Content", Prompt ="Input youre comment here...")]
        public string Content { get; set; }
    }
}
