using DI.Lab.Interfaces.Final.Repositories;
using Microsoft.Extensions.Logging;

namespace DI.Lab.Services.Final.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(ILogger<CustomerRepository> logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.LogInformation("Customer purchase saved.");
        }
    }
}
