using System;
using Microsoft.Extensions.Logging;
using DI.Lab.Interfaces.Starter.Services;
using DI.Lab.Shared.Starter.Models;

namespace DI.Lab.Services.Starter.Services
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
