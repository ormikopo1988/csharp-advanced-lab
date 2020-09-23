using System;

namespace VariantTypesGenerics.Starter.Models
{
    public class Manager : Employee
    {
        public override void DoWork()
        {
            Console.WriteLine("Create a meeting");
        }
    }
}