namespace ForumTemplate.Services.Data
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task CreateAsync(string content, int postId, string userId);

        Task<T> GetByIdAsync<T>(int id);
    }
}
