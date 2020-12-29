namespace ForumTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();
    }
}
