using AsyncApiCore.Final.Interfaces;
using AsyncApiCore.Final.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncApiCore.Final.Services
{
    public class UserService : IUserService
    {
        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var users = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

                    return JsonConvert.DeserializeObject<List<User>>(users);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var user = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users/" + id.ToString());

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