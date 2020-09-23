using System;

namespace VariantTypesGenerics.Final.Models
{
    public class Manager : Employee
    {
        public override void DoWork()
        {
            Console.WriteLine("Create a meeting");
        }
    }
}