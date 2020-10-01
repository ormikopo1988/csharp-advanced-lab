﻿using AsyncApiCore.Starter.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AsyncApiCore.Starter.Controllers
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
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAll();

                return new OkObjectResult(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByID(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }

                var user = await _userService.GetById(id);

                if (user == null)
                {
                    return NotFound();
                }

                user.Posts = await _postService.GetPostsForUser(user.ID);

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