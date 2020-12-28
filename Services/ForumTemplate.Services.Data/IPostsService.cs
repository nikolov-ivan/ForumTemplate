namespace ForumTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<int> CreateAsync(string name, string content, int categoryId, string userId);

        Task<T> GetByIdAsync<T>(int id);

        Task<int> EditAsync(string name, string content, int categoryId, int postId);

        Task DeleteAsync(int postId);

        Task AddViewAsync(int postId);

        Task<IEnumerable<T>> GetAllAsync<T>(string searchString);

        Task<IEnumerable<T>> GetAllAsyncByUser<T>(string userId);

        Task<IEnumerable<T>> GetAllPostsAsync<T>();
    }
}
