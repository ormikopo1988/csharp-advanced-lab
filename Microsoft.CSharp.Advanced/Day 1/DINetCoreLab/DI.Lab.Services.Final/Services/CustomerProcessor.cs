using DI.Lab.Interfaces.Final.Repositories;
using DI.Lab.Interfaces.Final.Services;
using Microsoft.Extensions.Logging;

namespace DI.Lab.Services.Final.Services
{
    public class CustomerProcessor : ICustomerProcessor
    {
        private readonly ILogger<CustomerProcessor> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public CustomerProcessor(ILogger<CustomerProcessor> logger, ICustomerRepository customerRepository, IProductRepository productRepository)
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
