namespace ForumTemplate.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PostCreateInputModel
    {
        [Required]
        [Display(Name = "Title", Prompt = "Input youre post title here...")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Content", Prompt = "Add youre comment here...")]
        public string Content { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Choose category for youre post:")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
