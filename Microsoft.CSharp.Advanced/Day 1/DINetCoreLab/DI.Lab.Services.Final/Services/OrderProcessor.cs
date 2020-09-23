using DI.Lab.Interfaces.Final.Services;
using DI.Lab.Shared.Final.Models;
using Microsoft.Extensions.Logging;

namespace DI.Lab.Services.Final.Services
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly ILogger<OrderProcessor> _logger;
        private readonly IBillingProcessor _billingProcessor;
        private readonly ICustomerProcessor _customerProcessor;
        private readonly INotifier _notifier;

        public OrderProcessor(ILogger<OrderProcessor> logger, IBillingProcessor billingProcessor, ICustomerProcessor customerProcessor, INotifier notifier)
        {
            _logger = logger;
            _billingProcessor = billingProcessor;
            _customerProcessor = customerProcessor;
            _notifier = notifier;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _notifier.SendReceipt(orderInfo);

            _logger.LogInformation($"End of processsing order with Id: {orderInfo.Id}");
        }
    }
}
