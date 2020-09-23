using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DI.Lab.Final.Models;
using DI.Lab.Interfaces.Final.Services;
using DI.Lab.Shared.Final.Models;

namespace DI.Lab.Final.Controllers
{
    public class HomeController : Controller
    {
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
            if (ModelState.IsValid)
            {
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
