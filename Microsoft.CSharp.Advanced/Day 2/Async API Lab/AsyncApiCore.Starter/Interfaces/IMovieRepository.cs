using AsyncApiCore.Starter.Models;
using System.Collections.Generic;

namespace AsyncApiCore.Starter.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        int Save(Movie movie);
    }
}