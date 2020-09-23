using DI.Lab.Shared.Final.Models;

namespace DI.Lab.Interfaces.Final.Services
{
    public interface IOrderProcessor
    {
        void ProcessOrder(OrderInfo orderInfo);
    }
}
