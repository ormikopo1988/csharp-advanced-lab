using DI.Lab.Interfaces.Starter;
using System;

namespace DI.Lab.Services.Starter
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(ILogger logger)
        {
            _Logger = logger;
        }

        ILogger _Logger;

        void IProductRepository.Save()
        {
            Console.WriteLine("Product inventory updated.");

            _Logger.Log("HELLO ATHENS!");
        }
    }
}
