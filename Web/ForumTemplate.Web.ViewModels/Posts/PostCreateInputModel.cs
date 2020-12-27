namespace ForumTemplate.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;

    public class PostCreateInputModel : IMapFrom<Post>
    {
        [Required]
        [Display(Name = "Post Title", Prompt = "Input your post title here...")]
        public string Name { get; set; }

        [Required]
        [MaxLength(30000)]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
