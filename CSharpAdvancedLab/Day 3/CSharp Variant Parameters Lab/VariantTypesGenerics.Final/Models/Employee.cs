using System;

namespace VariantTypesGenerics.Final.Models
{
    public class Employee : Person, IEntity
    {
        public int Id { get; set; }

        public bool IsValid()
        {
            return true;
        }

        public virtual void DoWork()
        {
            Console.WriteLine("Doing real work");
        }
    }
}