using AsyncApiCore.Starter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncApiCore.Starter.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAll(CancellationToken cancellationToken = default);
        Task<Movie> GetById(int id, CancellationToken cancellationToken = default);
        Task<int> Save(Movie movie, CancellationToken cancellationToken = default);
    }
}