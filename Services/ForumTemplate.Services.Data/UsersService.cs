namespace ForumTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ForumTemplate.Data.Common.Repositories;
    using ForumTemplate.Data.Models;
    using ForumTemplate.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            return await this.usersRepository.All().To<T>().ToListAsync();
        }
    }
}
