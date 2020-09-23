using AsyncApiCore.Starter.Interfaces;
using AsyncApiCore.Starter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace AsyncApiCore.Starter.Services
{
    public class PostService : IPostService
    {
        public List<Post> GetAll()
        {
            try
            {
                using (var client = new WebClient())
                {
                    var posts = client.DownloadString("https://jsonplaceholder.typicode.com/posts");

                    return JsonConvert.DeserializeObject<List<Post>>(posts);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Post GetById(int id)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var post = client.DownloadString("https://jsonplaceholder.typicode.com/posts/" + id.ToString());

                    return JsonConvert.DeserializeObject<Post>(post);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Post> GetPostsForUser(int userID)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var posts = client.DownloadString("https://jsonplaceholder.typicode.com/posts?userId=" + userID.ToString());

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