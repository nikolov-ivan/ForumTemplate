namespace ForumTemplate.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class PostEditInputModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Choose category for youre post:")]
        public int CategoryId { get; set; }

        public string UserId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
