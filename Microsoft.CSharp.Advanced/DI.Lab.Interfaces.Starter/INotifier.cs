using DI.Lab.Shared.Starter;
using System;

namespace DI.Lab.Interfaces.Starter
{
    public interface INotifier
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
