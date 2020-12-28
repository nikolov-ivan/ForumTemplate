namespace ForumTemplate.Web.ViewModels.Posts
{
    using System;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;
    using Ganss.XSS;

    public class CommentInPostViewModel : IMapFrom<Comment>
    {
        private readonly IHtmlSanitizer sanitizer;

        public CommentInPostViewModel()
        {
            this.sanitizer = new HtmlSanitizer();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string SanitizedContent => this.sanitizer.Sanitize(this.Content);
    }
}
