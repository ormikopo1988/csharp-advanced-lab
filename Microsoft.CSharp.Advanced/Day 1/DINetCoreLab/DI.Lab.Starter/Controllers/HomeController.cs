using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DI.Lab.Starter.Models;
using DI.Lab.Interfaces.Starter.Services;
using DI.Lab.Shared.Starter.Models;

namespace DI.Lab.Starter.Controllers
{
    public class HomeController : Controller
    {
        // Constructor injection code here

        private readonly IOrderProcessor _orderProcessor;

        public HomeController(IOrderProcessor orderProcessor)
        {
            _orderProcessor = orderProcessor;
        }
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

                _orderProcessor.ProcessOrder(new OrderInfo
                {
                    Id = new Random().Next(1, int.MaxValue),
                    CreditCard = order.CreditCard,
                    CustomerName = order.CustomerName,
                    Email = order.Email,
                    Price = order.Price,
                    Product = order.Product
                });
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
