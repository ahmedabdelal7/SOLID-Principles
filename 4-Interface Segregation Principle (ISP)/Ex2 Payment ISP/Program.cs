
public interface ICreditCardPayment
{
    void PayWithCreditCard();
}
public interface IPayPalPayment
{
    void PayWithPayPal();
}
public interface ICryptoPayment
{
    void PayWithCrypto();
}
public class CreditCardPayment : ICreditCardPayment
{
    public void PayWithCreditCard()
    {
        Console.WriteLine("Processing credit card payment...");
    }
}
public class PayPalPayment : IPayPalPayment
{  
    public void PayWithPayPal()
    {
        Console.WriteLine("Processing PayPal payment...");
    }
}
public class CryptoPayment : ICryptoPayment
{
    public void PayWithCrypto()
    {
        Console.WriteLine("Processing cryptocurrency payment...");
    }
}

public class AllPayments : ICreditCardPayment, IPayPalPayment, ICryptoPayment
{
    public void PayWithCreditCard()
    {
        Console.WriteLine("Processing credit card payment...");
    }
    public void PayWithPayPal()
    {
        Console.WriteLine("Processing PayPal payment...");
    }
    public void PayWithCrypto()
    {
        Console.WriteLine("Processing cryptocurrency payment...");
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        ICreditCardPayment creditCardPayment = new CreditCardPayment();
        creditCardPayment.PayWithCreditCard();

        IPayPalPayment payPalPayment = new PayPalPayment();
        payPalPayment.PayWithPayPal();

        ICryptoPayment cryptoPayment = new CryptoPayment();
        cryptoPayment.PayWithCrypto();

        AllPayments allPayments = new AllPayments();
        allPayments.PayWithCreditCard();
        allPayments.PayWithPayPal();
        allPayments.PayWithCrypto();
    }
}
