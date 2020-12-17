namespace ForumTemplate.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text.RegularExpressions;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;
    using Ganss.XSS;

    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string SanitizedContent
        {
            get
            {
                var decodeContent = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return new HtmlSanitizer().Sanitize(decodeContent);
            }
        }

        public string UserUsername { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int PostDate => (DateTime.UtcNow.Date - this.CreatedOn.Date).Days;

        public IEnumerable<CommentInPostViewModel> Comments { get; set; }
    }
}
