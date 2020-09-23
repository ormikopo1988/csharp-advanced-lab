using MyWebApp.DataStore;
using System;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The answer is {new Thing().Get(19, 23)}");
        }
    }
}