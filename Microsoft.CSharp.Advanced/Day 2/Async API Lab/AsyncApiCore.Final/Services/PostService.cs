using AsyncApiCore.Final.Interfaces;
using AsyncApiCore.Final.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncApiCore.Final.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PostService> _logger;

        public PostService(HttpClient httpClient, ILogger<PostService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            try
            {
                var httpResponseMessage = await _httpClient.GetAsync(string.Empty);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStr = await httpResponseMessage.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<Post>>(contentStr);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("PostService GetAllAsync exception.", ex);
            }

            return null;
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            try
            {
                var httpResponseMessage = await _httpClient.GetAsync(id.ToString());

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStr = await httpResponseMessage.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<Post>(contentStr);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("PostService GetByIdAsync exception.", ex);
            }

            return null;
        }

        public async Task<List<Post>> GetPostsForUserAsync(int userID)
        {
            try
            {
                var httpResponseMessage = await _httpClient.GetAsync("?userId=" + userID.ToString());

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStr = await httpResponseMessage.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<Post>>(contentStr);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("PostService GetPostsForUserAsync exception.", ex);
            }

            return null;
        }
    }
}