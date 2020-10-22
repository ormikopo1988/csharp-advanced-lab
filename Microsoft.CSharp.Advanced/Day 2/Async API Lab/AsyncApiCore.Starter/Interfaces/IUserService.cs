using AsyncApiCore.Starter.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncApiCore.Starter.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}