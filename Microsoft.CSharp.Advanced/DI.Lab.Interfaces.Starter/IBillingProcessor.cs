using System;

namespace DI.Lab.Interfaces.Starter
{
    public interface IBillingProcessor
    {
        void ProcessPayment(string customer, string creditCard, double price);
    }
}
