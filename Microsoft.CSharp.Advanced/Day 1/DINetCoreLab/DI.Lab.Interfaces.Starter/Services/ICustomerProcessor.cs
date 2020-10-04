using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Lab.Interfaces.Starter.Services
{
    public interface ICustomerProcessor
    {
        void UpdateCustomerOrder(string customer, string product);
    }
}
