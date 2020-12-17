namespace ForumTemplate.Services.Data
{
    using System.Threading.Tasks;

    using ForumTemplate.Data.Common.Repositories;
    using ForumTemplate.Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task CreateAsync(string content, int postId, string userId)
        {
            var comment = new Comment
            {
                Content = content,
                PostId = postId,
                UserId = userId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }
    }
}
