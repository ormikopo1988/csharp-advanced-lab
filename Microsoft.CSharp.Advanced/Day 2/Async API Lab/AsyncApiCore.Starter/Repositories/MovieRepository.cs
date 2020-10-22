using AsyncApiCore.Starter.Interfaces;
using AsyncApiCore.Starter.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncApiCore.Starter.Repositories
{
    // For testing this when ready:
    // - Open SQL Server Object Explorer View in your VS2019 instance
    // - Add (localdb)\MSSQLLocalDB instance to the view
    // - Create a new database inside this local db instance called MockDb
    // - Right-click on MockDb and run the following query:
    //CREATE TABLE[dbo].[Movie]
    //(
    //    [Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,

    //    [Name] NCHAR(50) NOT NULL,

    //    [Description] NVARCHAR(MAX) NOT NULL,

    //    [AppropriateAbove] INT NOT NULL,
    //    [ImdbRating] FLOAT(53) NULL
    //);
    public class MovieRepository : IMovieRepository
    {
        private readonly ILogger<MovieRepository> _logger;
        private readonly string _connectionString;

        public MovieRepository(ILogger<MovieRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetValue<string>("ConnectionStrings:Default");
        }

        private async Task<IDbConnection> GetConnectionAsync(CancellationToken cancellationToken = default)
        {
            var connection = new SqlConnection(_connectionString);

            await connection.OpenAsync(cancellationToken);

            return connection;
        }

        public async Task<List<Movie>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                using (var connection = await GetConnectionAsync(cancellationToken))
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

        public async Task<Movie> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var connection = await GetConnectionAsync(cancellationToken))
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

        public async Task<int> SaveAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            try
            {
                string sql = "INSERT INTO [dbo].[Movie] (Name, Description, AppropriateAbove, ImdbRating) Values (@Name, @Description, @AppropriateAbove, @ImdbRating);";

                using (var connection =await GetConnectionAsync(cancellationToken))
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