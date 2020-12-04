namespace ForumTemplate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ForumTemplate.Data.Models;

    public class PostsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Posts.Any())
            {
                return;
            }

            var posts = new List<Post>();
            var userId = dbContext.Users.FirstOrDefault().Id;
            var post = new Post { Content = "This is the first post over here", CategoryId = 5, UserId = userId, Name = "FirstPostName" };
            posts.Add(post);

            foreach (var p in posts)
            {
                await dbContext.AddAsync(p);
            }
        }
    }
}
