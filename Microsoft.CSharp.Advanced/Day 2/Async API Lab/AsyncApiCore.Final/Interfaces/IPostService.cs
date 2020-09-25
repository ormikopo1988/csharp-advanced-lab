using AsyncApiCore.Final.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncApiCore.Final.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Post> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Post>> GetPostsForUserAsync(int userID, CancellationToken cancellationToken = default);
    }
}