using DI.Lab.Interfaces.Starter;
using System;

namespace DI.Lab.Services.Starter
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository(ILogger logger)
        {
            _Logger = logger;
        }

        ILogger _Logger;

        void ICustomerRepository.Save()
        {
            _Logger.Log("This is CustomerRepository logger.");

            Console.WriteLine("Customer purchase saved.");
        }
    }
}
