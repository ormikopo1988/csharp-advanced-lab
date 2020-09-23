using AsyncApiCore.Final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncApiCore.Final.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task<List<Post>> GetPostsForUserAsync(int userID);
    }
}