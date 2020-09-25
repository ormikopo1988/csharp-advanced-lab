using AsyncApiCore.Final.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncApiCore.Final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        
        public UsersController(ILogger<UsersController> logger, IUserService userService, IPostService postService)
        {
            _logger = logger;
            _userService = userService;
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userService.GetAllAsync(cancellationToken);

                return new OkObjectResult(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByID(int id, CancellationToken cancellationToken)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }

                var user = await _userService.GetByIdAsync(id, cancellationToken);

                if (user == null)
                {
                    return NotFound();
                }

                user.Posts = await _postService.GetPostsForUserAsync(user.ID, cancellationToken);

                return new OkObjectResult(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}