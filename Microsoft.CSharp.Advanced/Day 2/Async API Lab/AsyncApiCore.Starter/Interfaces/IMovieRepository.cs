using AsyncApiCore.Starter.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncApiCore.Starter.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Movie> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> SaveAsync(Movie movie, CancellationToken cancellationToken = default);
    }
}