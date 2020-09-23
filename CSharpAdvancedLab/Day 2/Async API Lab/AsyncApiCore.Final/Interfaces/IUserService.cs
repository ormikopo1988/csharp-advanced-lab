using AsyncApiCore.Final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncApiCore.Final.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
    }
}