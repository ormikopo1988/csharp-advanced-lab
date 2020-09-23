using AsyncApiCore.Starter.Models;
using System.Collections.Generic;

namespace AsyncApiCore.Starter.Interfaces
{
    public interface IPostService
    {
        List<Post> GetAll();
        Post GetById(int id);
        List<Post> GetPostsForUser(int userID);
    }
}