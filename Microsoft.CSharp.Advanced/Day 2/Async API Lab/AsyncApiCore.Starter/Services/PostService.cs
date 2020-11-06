using AsyncApiCore.Starter.Interfaces;
using AsyncApiCore.Starter.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncApiCore.Starter.Services
{
    public class PostService : IPostService
    {
        private readonly ILogger<PostService> _logger;

        public PostService(ILogger<PostService> logger)
        {
            _logger = logger;
        }

        public async Task<List<Post>> GetAll()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var posts = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
                    var postStr = await posts.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<Post>>(postStr);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public async Task<Post> GetById(int id)
        {
            try
            {
                // TODO - Change this code in order to use HttpClient instead of WebClient and call GetAsync instead of DownloadString on the client object instance.
                using (var client = new HttpClient())
                {
                    var post = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/" + id.ToString());
                    var str = await post.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<Post>(str);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public async Task<List<Post>> GetPostsForUser(int userID)
        {
            try
            {
                // TODO - Change this code in order to use HttpClient instead of WebClient and call GetAsync instead of DownloadString on the client object instance.
                using (var client = new HttpClient())
                {
                    var posts = await client.GetAsync("https://jsonplaceholder.typicode.com/posts?userId=" + userID.ToString());

                    var str = await posts.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<Post>>(str);
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