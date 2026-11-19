using System.ComponentModel.Design;

public class PaymentService
{
    private IPaymentProcessor _PaymentProcessor;
    public PaymentService(IPaymentProcessor paymentProcessor)
    {
        _PaymentProcessor = paymentProcessor;
    }
    public void ProcessPayment(decimal amount)
    {
        _PaymentProcessor.Process(amount);
    }
}
public interface IPaymentProcessor
{
    public void Process(decimal amount);
}

public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount:C}");
    }
}
public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing Credit Card payment of {amount:C}");
    }
}
public class BankTransferPaymentProcessor : IPaymentProcessor
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing Bank Transfer payment of {amount:C}");
    }
}
public class BitcoinPaymentProcessor : IPaymentProcessor
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing Bitcoin payment of {amount:C}");
    }
}
public class VodafoneCashPaymentProcessor : IPaymentProcessor
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing Vodafone Cash payment of {amount:C}");
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        

        PaymentService paymentService = new PaymentService(new PayPalPaymentProcessor());
        paymentService.ProcessPayment(100m);

        paymentService = new PaymentService(new CreditCardPaymentProcessor());
        paymentService.ProcessPayment(200m);

        paymentService = new PaymentService(new BankTransferPaymentProcessor());
        paymentService.ProcessPayment(300m);

        paymentService = new PaymentService(new BitcoinPaymentProcessor());
        paymentService.ProcessPayment(400m);

        paymentService = new PaymentService(new VodafoneCashPaymentProcessor());
        paymentService.ProcessPayment(500m);
    }
}

