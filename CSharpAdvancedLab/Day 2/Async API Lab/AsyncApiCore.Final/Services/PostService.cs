using AsyncApiCore.Final.Interfaces;
using AsyncApiCore.Final.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncApiCore.Final.Services
{
    public class PostService : IPostService
    {
        public async Task<List<Post>> GetAllAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var posts = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

                    return JsonConvert.DeserializeObject<List<Post>>(posts);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var post = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/" + id.ToString());

                    return JsonConvert.DeserializeObject<Post>(post);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Post>> GetPostsForUserAsync(int userID)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var posts = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts?userId=" + userID.ToString());

                    return JsonConvert.DeserializeObject<List<Post>>(posts);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}