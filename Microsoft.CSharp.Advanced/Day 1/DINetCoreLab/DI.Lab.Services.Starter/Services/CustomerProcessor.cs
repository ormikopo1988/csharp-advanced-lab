using DI.Lab.Interfaces.Starter.Repositories;
using DI.Lab.Interfaces.Starter.Services;
using Microsoft.Extensions.Logging;
using System;

namespace DI.Lab.Services.Starter.Services
{
    public class CustomerProcessor : ICustomerProcessor
    {
        private readonly ILogger<CustomerProcessor> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public CustomerProcessor(ICustomerRepository customerRepository, IProductRepository productRepository, ILogger<CustomerProcessor> logger)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }



        public void UpdateCustomerOrder(string customer, string product)
        {
            _customerRepository.Save();
            _productRepository.Save();

            _logger.LogInformation(string.Format("Customer record for '{0}' updated with purchase of product '{1}'.", customer, product));
        }
    }
}
