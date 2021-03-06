﻿namespace ForumTemplate.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using AutoMapper;
    using ForumTemplate.Common;
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;
    using Ganss.XSS;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        private readonly IHtmlSanitizer sanitizer;

        public PostViewModel()
        {
            this.sanitizer = new HtmlSanitizer();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => this.sanitizer.Sanitize(this.Content);

        public string ShortSanitizedContent => this.Content == null ? GlobalConstants.NoContentMessage : this.sanitizer.Sanitize(this.Content.Length >
            GlobalConstants.ShortSanitizedContentMaxLength ?
            this.Content.Substring(0, GlobalConstants.ShortSanitizedContentMaxLength) + "..." : this.Content);

        public string UserUsername { get; set; }

        public int CommentsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int View { get; set; }

        public int VotesCount { get; set; }

        public int PostDate => (DateTime.UtcNow.Date - this.CreatedOn.Date).Days;

        public IEnumerable<CommentInPostViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.VotesCount, options =>
                  {
                      options.MapFrom(p => p.Votes.Sum(v => (int)v.Type));
                  });
        }
    }
}
