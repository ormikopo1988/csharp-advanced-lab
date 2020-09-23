﻿using System.Collections.Generic;

namespace AsyncApiCore.Final.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        public List<Post> Posts { get; set; }

        public User()
        {
            Posts = new List<Post>();
        }
    }
}