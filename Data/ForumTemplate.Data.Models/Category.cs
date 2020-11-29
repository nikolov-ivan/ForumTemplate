namespace ForumTemplate.Data.Models
{
    using System.Collections.Generic;

    using ForumTemplate.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
