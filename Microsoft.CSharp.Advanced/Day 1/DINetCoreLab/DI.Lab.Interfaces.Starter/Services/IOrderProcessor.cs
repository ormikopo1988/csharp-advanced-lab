using DI.Lab.Shared.Starter.Models;

namespace DI.Lab.Interfaces.Starter.Services
{
    public interface IOrderProcessor
    {
        void ProcessOrder(OrderInfo orderInfo);
    }
}
