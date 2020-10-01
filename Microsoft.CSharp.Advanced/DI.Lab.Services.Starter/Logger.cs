using DI.Lab.Interfaces.Starter;
using System;

namespace DI.Lab.Services.Starter
{
    public class Logger : ILogger
    {
        void ILogger.Log(string message)
        {
            Console.WriteLine("Message logged: {0}", message);
        }
    }
}
