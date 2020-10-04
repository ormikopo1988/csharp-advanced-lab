using DI.Lab.Interfaces.Starter.Repositories;
using Microsoft.Extensions.Logging;

namespace DI.Lab.Services.Starter.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(ILogger<ProductRepository> logger)
        {
            _logger = logger;
        }
        public void Save()
        {
           _logger.LogInformation("Product inventory updated.");

        }
    }

}
