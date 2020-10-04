using DI.Lab.Interfaces.Starter.Services;
using DI.Lab.Shared.Starter.Models;
using Microsoft.Extensions.Logging;

namespace DI.Lab.Services.Starter.Services
{

    public class OrderProcessor: IOrderProcessor
    {

        private readonly ILogger<OrderProcessor> _logger;
        private readonly IBillingProcessor _billingProcessor;
        private readonly ICustomerProcessor _customerProcessor;
        private readonly INotifier _notifier;

        public OrderProcessor(IBillingProcessor billingProcessor, ICustomerProcessor customerProcessor, ILogger<OrderProcessor> logger, INotifier notifier)
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
            _logger.LogInformation($"Order with Id: { orderInfo.Id} Processed!");
        }
    }
}
