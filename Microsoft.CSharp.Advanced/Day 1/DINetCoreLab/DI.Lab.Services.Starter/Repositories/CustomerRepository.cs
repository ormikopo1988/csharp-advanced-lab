using DI.Lab.Interfaces.Starter.Repositories;
using Microsoft.Extensions.Logging;

namespace DI.Lab.Services.Starter.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(ILogger<CustomerRepository> logger)
        {
            _logger = logger;
        }

        void ICustomerRepository.Save()
        {
            _logger.LogInformation("Customer purchase saved.");
        }
    }
}
