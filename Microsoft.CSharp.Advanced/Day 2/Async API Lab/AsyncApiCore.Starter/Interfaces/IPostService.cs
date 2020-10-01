using AsyncApiCore.Starter.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncApiCore.Starter.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Post> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Post>> GetPostsForUserAsync(int userID,CancellationToken cancellationToken = default);
    }
}