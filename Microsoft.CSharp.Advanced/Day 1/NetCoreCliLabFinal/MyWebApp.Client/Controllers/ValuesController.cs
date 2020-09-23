using System;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.DataStore;

namespace MyWebApp.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public int Get()
        {
            var rng = new Random();
            return new Thing().Get(rng.Next(20, 55), rng.Next(20, 55));
        }
    }
}