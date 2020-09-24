using Autofac;
using System;
using System.Linq;
using System.Reflection;

namespace DI.Tutorial
{
    class Program
    {
        public static IContainer Container;

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Process order");
                Console.WriteLine("0 - Exit");
                Console.WriteLine();
                Console.Write("Select: ");
            
                string choice = Console.ReadLine();
                
                if (choice == "0")
                {
                    exit = true;
                }
                else
                {
                    OrderInfo orderInfo = new OrderInfo()
                    {
                        CustomerName = "John Doe",
                        Email = "john125@gmail.com",
                        Product = "Laptop",
                        Price = 1200,
                        CreditCard = "1234567890"
                    };

                    Console.WriteLine();
                    Console.WriteLine("Order Processing:");
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":

                            ContainerBuilder builder = new ContainerBuilder();

                            builder.RegisterType<Commerce>();
                            builder.RegisterType<Notifier>().As<INotifier>();

                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Processor"))
                                .As(t => t.GetInterfaces().FirstOrDefault(
                                    i => i.Name == "I" + t.Name));

                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Repository"))
                                .As(t => t.GetInterfaces().FirstOrDefault(
                                    i => i.Name == "I" + t.Name));

                            builder.RegisterType<Logger>().As<ILogger>();

                            Container = builder.Build();

                            Commerce commerce3 = Container.Resolve<Commerce>();

                            commerce3.ProcessOrder(orderInfo);

                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press 'Enter' for menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}