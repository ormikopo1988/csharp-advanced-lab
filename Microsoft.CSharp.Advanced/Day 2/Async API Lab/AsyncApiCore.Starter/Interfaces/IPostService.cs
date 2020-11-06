using AsyncApiCore.Starter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncApiCore.Starter.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task<List<Post>> GetPostsForUserAsync(int userID);
    }
}