namespace ForumTemplate.Web.ViewModels.Categories
{
    using System.Net;
    using System.Text.RegularExpressions;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;
    using Ganss.XSS;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                var content = Regex.Replace(this.Content, @"<[^>]+>", string.Empty);
                return content.Length > 50 ? content.Substring(0, 50) + "..." : content;
            }
        }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.ShortContent);
    }
}
