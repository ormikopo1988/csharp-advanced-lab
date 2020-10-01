using AsyncApiCore.Starter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncApiCore.Starter.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAll(CancellationToken cancellationToken = default);
        Task<Post> GetById(int id, CancellationToken cancellationToken = default);
        Task<List<Post>> GetPostsForUser(int userID, CancellationToken cancellationToken = default);
    }
}