using AsyncApiCore.Starter.Interfaces;
using AsyncApiCore.Starter.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
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

        public async Task<List<Post>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                // TODO - Change this code in order to use HttpClient instead of WebClient and call GetAsync instead of DownloadString on the client object instance.
                using (var client = new HttpClient())
                {
                    var httpResponseMessage = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var posts = await httpResponseMessage.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Post>>(posts);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public async Task<Post> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                // TODO - Change this code in order to use HttpClient instead of WebClient and call GetAsync instead of DownloadString on the client object instance.
                using (var client = new HttpClient())
                {
                    var httpResponseMessage = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/" + id.ToString(), cancellationToken);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var post = await httpResponseMessage.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Post>(post);
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public async Task<List<Post>> GetPostsForUserAsync(int userID, CancellationToken cancellationToken = default)
        {
            try
            {
                // TODO - Change this code in order to use HttpClient instead of WebClient and call GetAsync instead of DownloadString on the client object instance.
                using (var client = new HttpClient())
                {
                    var httpResponseMessage = await client.GetAsync("https://jsonplaceholder.typicode.com/posts?userId=" + userID.ToString(), cancellationToken);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var posts = await httpResponseMessage.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<List<Post>>(posts);
                    }
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