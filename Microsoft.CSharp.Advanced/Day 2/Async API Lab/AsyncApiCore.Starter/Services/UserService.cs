using AsyncApiCore.Starter.Interfaces;
using AsyncApiCore.Starter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace AsyncApiCore.Starter.Services
{
    public class UserService : IUserService
    {
        public List<User> GetAll()
        {
            try
            {
                using (var client = new WebClient())
                {
                    var users = client.DownloadString("https://jsonplaceholder.typicode.com/users");

                    return JsonConvert.DeserializeObject<List<User>>(users);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User GetById(int id)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var user = client.DownloadString("https://jsonplaceholder.typicode.com/users/" + id.ToString());

                    return JsonConvert.DeserializeObject<User>(user);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}