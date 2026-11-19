public class Bird
{
    public virtual void Eat()
    {
        Console.WriteLine("Bird is eating..");
    }
    public virtual void Fly()
    {
        Console.WriteLine("Bird is flying..");
    }
}

public class  Eagle : Bird
{
    public override void Eat()
    {
        Console.WriteLine("Eagle is eating..");
    }
    public override void Fly()
    {
        Console.WriteLine("Eagle is flying..");
    }
}

public class Ostrich : Bird
{
    public override void Eat()
    {
        Console.WriteLine("Ostrich is eating..");
    }
    public override void Fly()
    {
        throw new NotImplementedException("Ostriches cannot fly.");
    }
}


internal class Program
{
    static void Main(string[] args)
    {
        Bird eagle = new Eagle();
        eagle.Eat();
        eagle.Fly();

        Bird ostrich = new Ostrich();
        ostrich.Eat();
        try
        {
            ostrich.Fly();
        }
        catch (NotImplementedException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}