namespace ForumTemplate.Web.ViewModels.Categories
{
    using System;

    using ForumTemplate.Common;
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;
    using Ganss.XSS;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        private readonly IHtmlSanitizer sanitizer;

        public PostInCategoryViewModel()
        {
            this.sanitizer = new HtmlSanitizer();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }

        public int View { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string ShortSanitizedContent => this.Content == null ? GlobalConstants.NoContentMessage : this.sanitizer.Sanitize(this.Content.Length >
            GlobalConstants.ShortSanitizedContentMaxLength ?
            this.Content.Substring(0, GlobalConstants.ShortSanitizedContentMaxLength) + "..." : this.Content);
    }
}
