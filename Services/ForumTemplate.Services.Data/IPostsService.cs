namespace ForumTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<int> CreateAsync(string name, string content, int categoryId, string userId);
    }
}
