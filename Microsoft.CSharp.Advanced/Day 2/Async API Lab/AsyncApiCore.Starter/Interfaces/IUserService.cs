using AsyncApiCore.Starter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncApiCore.Starter.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
    }
}