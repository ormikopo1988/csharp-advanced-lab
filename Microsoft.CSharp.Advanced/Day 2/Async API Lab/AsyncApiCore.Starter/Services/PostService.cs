using AsyncApiCore.Starter.Interfaces;
using AsyncApiCore.Starter.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace AsyncApiCore.Starter.Services
{
    public class PostService : IPostService
    {
        private readonly ILogger<PostService> _logger;

        public PostService(ILogger<PostService> logger)
        {
            _logger = logger;
        }

        public List<Post> GetAll()
        {
            try
            {
                // TODO - Change this code in order to use HttpClient instead of WebClient and call GetAsync instead of DownloadString on the client object instance.
                using (var client = new WebClient())
                {
                    var posts = client.DownloadString("https://jsonplaceholder.typicode.com/posts");

                    return JsonConvert.DeserializeObject<List<Post>>(posts);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public Post GetById(int id)
        {
            try
            {
                // TODO - Change this code in order to use HttpClient instead of WebClient and call GetAsync instead of DownloadString on the client object instance.
                using (var client = new WebClient())
                {
                    var post = client.DownloadString("https://jsonplaceholder.typicode.com/posts/" + id.ToString());

                    return JsonConvert.DeserializeObject<Post>(post);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public List<Post> GetPostsForUser(int userID)
        {
            try
            {
                // TODO - Change this code in order to use HttpClient instead of WebClient and call GetAsync instead of DownloadString on the client object instance.
                using (var client = new WebClient())
                {
                    var posts = client.DownloadString("https://jsonplaceholder.typicode.com/posts?userId=" + userID.ToString());

                    return JsonConvert.DeserializeObject<List<Post>>(posts);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }
    }
}