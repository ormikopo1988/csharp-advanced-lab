using DI.Lab.Interfaces.Final.Services;
using DI.Lab.Shared.Final.Models;
using Microsoft.Extensions.Logging;

namespace DI.Lab.Services.Final.Services
{
    public class Notifier : INotifier
    {
        private readonly ILogger<Notifier> _logger;

        public Notifier(ILogger<Notifier> logger)
        {
            _logger = logger;
        }

        public void SendReceipt(OrderInfo orderInfo)
        {
            // send email to customer with receipt
            _logger.LogInformation(string.Format("Receipt sent to customer '{0}' via email.", orderInfo.CustomerName));
        }
    }
}
