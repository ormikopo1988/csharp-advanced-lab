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
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                // TODO - Change this code in order to use HttpClient instead of WebClient and call GetAsync instead of DownloadString on the client object instance.
                using (var client = new HttpClient())
                {
                    var httpResponseMessage = await client.GetAsync("https://jsonplaceholder.typicode.com/users", cancellationToken);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var users = await httpResponseMessage.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<User>>(users);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                // TODO - Change this code in order to use HttpClient instead of WebClient and call GetAsync instead of DownloadString on the client object instance.
                using (var client = new HttpClient())
                {
                    var httpResponseMessage = await client.GetAsync("https://jsonplaceholder.typicode.com/users/" + id.ToString(), cancellationToken);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var user =await httpResponseMessage.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<User>(user);
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