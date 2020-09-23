using AsyncApiCore.Final.Interfaces;
using AsyncApiCore.Final.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncApiCore.Final.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ILogger<MovieRepository> _logger;
        private readonly string _connectionString;

        public MovieRepository(ILogger<MovieRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetValue<string>("ConnectionStrings:Default");
        }

        private async Task<IDbConnection> GetConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            return connection;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                {
                    var movies = await connection.QueryAsync<Movie>("SELECT * FROM [dbo].[Movie] WITH (NOLOCK)");

                    return movies.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                throw;
            }
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                {
                    var movie = await connection.QueryFirstOrDefaultAsync<Movie>("SELECT * FROM [dbo].[Movie] WITH (NOLOCK) WHERE Id=@Id", new { Id = id });

                    if (movie == null)
                    {
                        return null;
                    }

                    return movie;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                throw;
            }
        }

        public async Task<int> SaveAsync(Movie movie)
        {
            try
            {
                string sql = "INSERT INTO [dbo].[Movie] (Name, Description, AppropriateAbove, ImdbRating) Values (@Name, @Description, @AppropriateAbove, @ImdbRating);";

                using (var connection = await GetConnectionAsync())
                {
                    var affectedRows = await connection.ExecuteAsync(sql, new { movie.Name, movie.Description, movie.AppropriateAbove, movie.ImdbRating });

                    return affectedRows;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                throw;
            }
        }
    }
}