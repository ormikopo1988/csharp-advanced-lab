using AsyncApiCore.Starter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncApiCore.Starter.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<int> SaveAsync(Movie movie);
    }
}