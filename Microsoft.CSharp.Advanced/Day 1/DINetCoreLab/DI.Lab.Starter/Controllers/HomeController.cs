using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DI.Lab.Starter.Models;

namespace DI.Lab.Starter.Controllers
{
    public class HomeController : Controller
    {
        // Constructor injection code here

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            // Implement same logic as NetCore-DependencyInjection-Workshop repository => DependencyInjection solution => DI.Tutorial project => Stage 3 folder 

            if (ModelState.IsValid)
            {
                // Library method call code here
                // For Id property of OrderInfo object pass -> new Random().Next(1, int.MaxValue),
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
