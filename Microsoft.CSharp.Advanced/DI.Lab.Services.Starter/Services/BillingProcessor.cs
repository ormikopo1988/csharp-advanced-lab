using DI.Lab.Interfaces.Final.Services;
using Microsoft.Extensions.Logging;

namespace DI.Lab.Services.Final.Services
{
    public class BillingProcessor : IBillingProcessor
    {
        private readonly ILogger<BillingProcessor> _logger;

        public BillingProcessor(ILogger<BillingProcessor> logger)
        {
            _logger = logger;
        }

        public void ProcessPayment(string customer, string creditCard, double price)
        {
            // perform billing gateway processing
            _logger.LogInformation(string.Format("Payment processed for customer '{0}' on credit card '{1}' for {2:c}.", customer, creditCard, price));
        }
    }
}
