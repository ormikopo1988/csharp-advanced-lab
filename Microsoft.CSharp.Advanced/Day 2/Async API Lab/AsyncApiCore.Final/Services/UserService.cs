using AsyncApiCore.Final.Interfaces;
using AsyncApiCore.Final.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncApiCore.Final.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserService> _logger;

        public UserService(HttpClient httpClient, ILogger<UserService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var httpResponseMessage = await _httpClient.GetAsync(string.Empty, cancellationToken);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStr = await httpResponseMessage.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<User>>(contentStr);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("UserService GetAllAsync exception.", ex);
            }

            return null;
        }

        public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var httpResponseMessage = await _httpClient.GetAsync(id.ToString(), cancellationToken);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStr = await httpResponseMessage.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<User>(contentStr);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("UserService GetByIdAsync exception.", ex);
            }

            return null;
        }
    }
}