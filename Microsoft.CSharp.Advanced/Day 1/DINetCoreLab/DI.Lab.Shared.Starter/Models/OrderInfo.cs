using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Lab.Shared.Starter.Models
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public string CreditCard { get; set; }
    }
}
