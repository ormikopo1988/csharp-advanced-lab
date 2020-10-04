using DI.Lab.Shared.Starter.Models;

namespace DI.Lab.Interfaces.Starter.Services
{
    public interface INotifier
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
