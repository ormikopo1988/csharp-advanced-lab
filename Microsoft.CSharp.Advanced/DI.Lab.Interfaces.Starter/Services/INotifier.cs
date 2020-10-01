using DI.Lab.Shared.Final.Models;

namespace DI.Lab.Interfaces.Final.Services
{
    public interface INotifier
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
