namespace DI.Lab.Interfaces.Final.Services
{
    public interface IBillingProcessor
    {
        void ProcessPayment(string customer, string creditCard, double price);
    }
}
