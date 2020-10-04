using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Lab.Interfaces.Starter.Services
{
    public interface IBillingProcessor
    {
        void ProcessPayment(string customer, string creditCard, double price);
    }
}
