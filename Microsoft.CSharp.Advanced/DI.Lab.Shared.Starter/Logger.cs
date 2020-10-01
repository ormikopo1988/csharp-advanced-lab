using System;

namespace DI.Tutorial
{
    public class Logger : ILogger
    {
        void ILogger.Log(string message)
        {
            Console.WriteLine("Message logged: {0}", message);
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }
}