using AsyncApiCore.Starter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncApiCore.Starter.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll(CancellationToken cancellationToken = default);
        Task<User> GetById(int id, CancellationToken cancellationToken = default);
    }
}