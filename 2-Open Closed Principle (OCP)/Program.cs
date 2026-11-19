
public class PaymentService
{
    private IPayment _Payment;
    public PaymentService(IPayment payment)
    {
        _Payment = payment;
    }
    public void Pay(decimal amount)
    {
        _Payment.ProcessPayment(amount);
    }
}

public interface IPayment
{
    public void ProcessPayment(decimal amount);
}

public class PayPalPaymentService : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount:0.00}");
    }
}
public class CreditCardPaymentService : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Credit Card payment of {amount:C}");
    }
}
public class BankTransferPaymentService : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Bank Transfer payment of {amount:C}");
    }
}
public class BitcoinPaymentService : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Bitcoin payment of {amount:0.00}");
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        

        PaymentService paymentService = new PaymentService(new PayPalPaymentService());
        paymentService.Pay(100m);

        paymentService = new PaymentService(new CreditCardPaymentService());
        paymentService.Pay(200m);

        paymentService = new PaymentService(new BankTransferPaymentService());
        paymentService.Pay(300m);

        paymentService = new PaymentService(new BitcoinPaymentService());
        paymentService.Pay(400m);
    }
}

