using DI.Lab.Interfaces.Final.Repositories;
using Microsoft.Extensions.Logging;

namespace DI.Lab.Services.Final.Repositories
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
