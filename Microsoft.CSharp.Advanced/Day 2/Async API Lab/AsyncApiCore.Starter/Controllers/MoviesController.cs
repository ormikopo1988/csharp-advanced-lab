using AsyncApiCore.Starter.Interfaces;
using AsyncApiCore.Starter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncApiCore.Starter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieRepository _movieRepository;

        public MoviesController(ILogger<MoviesController> logger, IMovieRepository movieRepository)
        {
            _logger = logger;
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var movies =await _movieRepository.GetAllAsync(cancellationToken);

                return new OkObjectResult(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }

                var movie = await _movieRepository.GetByIdAsync(id, cancellationToken);

                if (movie == null)
                {
                    return NotFound();
                }

                return new OkObjectResult(movie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var moviesInserted = await _movieRepository.SaveAsync(movie, cancellationToken);

                if (moviesInserted == 1)
                {
                    return NoContent();
                }
                else
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}