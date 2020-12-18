namespace ForumTemplate.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class PostCreateModel : IMapFrom<Post>
    {
        [Required]
        [Display(Name = "Title", Prompt = "Input youre post title here...")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Content", Prompt = "Input youre content here...")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "CategoryId", Prompt = "Choose category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
