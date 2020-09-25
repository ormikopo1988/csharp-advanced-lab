using AsyncApiCore.Starter.Interfaces;
using AsyncApiCore.Starter.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace AsyncApiCore.Starter.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public List<User> GetAll()
        {
            try
            {
                // TODO - Change this code in order to use HttpClient instead of WebClient and call GetAsync instead of DownloadString on the client object instance.
                using (var client = new WebClient())
                {
                    var users = client.DownloadString("https://jsonplaceholder.typicode.com/users");

                    return JsonConvert.DeserializeObject<List<User>>(users);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public User GetById(int id)
        {
            try
            {
                // TODO - Change this code in order to use HttpClient instead of WebClient and call GetAsync instead of DownloadString on the client object instance.
                using (var client = new WebClient())
                {
                    var user = client.DownloadString("https://jsonplaceholder.typicode.com/users/" + id.ToString());

                    return JsonConvert.DeserializeObject<User>(user);
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