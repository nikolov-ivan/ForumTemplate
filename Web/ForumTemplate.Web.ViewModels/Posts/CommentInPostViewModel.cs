namespace ForumTemplate.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;

    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;
    using Ganss.XSS;

    public class CommentInPostViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public string UserUserName { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string SanitizedContent
        {
            get
            {
                var decodeContent = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return new HtmlSanitizer().Sanitize(decodeContent);
            }
        }
    }
}
