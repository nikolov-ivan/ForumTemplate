namespace ForumTemplate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ForumTemplate.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<string> { "News", "Music", "Programming", "Sale" };
            foreach (var category in categories)
            {
                await dbContext.AddAsync(new Category
                {
                    Name = category,
                    Description = $"All about {category}",
                    ImgUrl = category,
                });
            }
        }
    }
}
