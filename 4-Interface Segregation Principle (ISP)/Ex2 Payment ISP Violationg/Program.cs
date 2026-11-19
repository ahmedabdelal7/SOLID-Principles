
public interface IPayment
{
    void PayWithCreditCard();
    void PayWithPayPal();
    void PayWithCrypto();
}
public class CreditCardPayment : IPayment
{
    public void PayWithCreditCard()
    {
        Console.WriteLine("Processing credit card payment...");
    }
    public void PayWithPayPal()
    {
        throw new NotImplementedException();
    }
    public void PayWithCrypto()
    {
        throw new NotImplementedException();
    }
}
public class PayPalPayment : IPayment
{
    public void PayWithCreditCard()
    {
        throw new NotImplementedException();
    }
    public void PayWithPayPal()
    {
        Console.WriteLine("Processing PayPal payment...");
    }
    public void PayWithCrypto()
    {
        throw new NotImplementedException();
    }
}
public class CryptoPayment : IPayment
{
    public void PayWithCreditCard()
    {
        throw new NotImplementedException();
    }
    public void PayWithPayPal()
    {
        throw new NotImplementedException();
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
        IPayment creditCardPayment = new CreditCardPayment();
        creditCardPayment.PayWithCreditCard();
        //creditCardPayment.PayWithPayPal(); // This will throw NotImplementedException
        //creditCardPayment.PayWithCrypto(); // This will throw NotImplementedException

        IPayment payPalPayment = new PayPalPayment();
        payPalPayment.PayWithPayPal();
        //payPalPayment.PayWithCreditCard(); // This will throw NotImplementedException
        //payPalPayment.PayWithCrypto(); // This will throw NotImplementedException

        IPayment cryptoPayment = new CryptoPayment();
        cryptoPayment.PayWithCrypto();
        //cryptoPayment.PayWithCreditCard(); // This will throw NotImplementedException
        //cryptoPayment.PayWithPayPal(); // This will throw NotImplementedException

    }
}
