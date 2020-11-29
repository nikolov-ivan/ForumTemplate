namespace ForumTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ForumTemplate.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
