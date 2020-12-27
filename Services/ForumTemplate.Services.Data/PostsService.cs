namespace ForumTemplate.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ForumTemplate.Data.Common.Repositories;
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task<int> CreateAsync(string name, string content, int categoryId, string userId)
        {
            var post = new Post
            {
                Name = name,
                Content = content,
                CategoryId = categoryId,
                UserId = userId,
            };

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();
            return post.Id;
        }

        public async Task DeleteAsync(int postId)
        {
            var post = await this.postsRepository.All().Where(x => x.Id == postId).FirstOrDefaultAsync();
            post.IsDeleted = true;
            await this.postsRepository.SaveChangesAsync();
        }

        public async Task<int> EditAsync(string name, string content, int categoryId, int postId)
        {
            var post = await this.postsRepository.All().Where(x => x.Id == postId).FirstOrDefaultAsync();
            post.Name = name;
            post.Content = content;
            post.CategoryId = categoryId;
            await this.postsRepository.SaveChangesAsync();
            return postId;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var post = await this.postsRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefaultAsync();
            return post;
        }

        public async Task AddViewAsync(int id)
        {
            var post = await this.postsRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            post.View++;
            await this.postsRepository.SaveChangesAsync();
        }
    }
}
