namespace Ex2_Vehicle_LSP
{
    public class Vehicle
    {
        public virtual void StartEngine()
        {
            Console.WriteLine("Starting the engine...");
        }
        public virtual void Drive()
        {
            Console.WriteLine("Driving the vehicle...");
        }
    }

    public class Car : Vehicle
    {
        public override void StartEngine()
        {
            Console.WriteLine("Starting the car engine...");
        }
        public override void Drive()
        {
            Console.WriteLine("Driving the car...");
        }
    }

    public class Motorcycle : Vehicle
    {
        public override void StartEngine()
        {
            Console.WriteLine("Starting the motorcycle engine...");
        }
        public override void Drive()
        {
            Console.WriteLine("Driving the motorcycle...");
        }
    }
    public class Bicycle : Vehicle
    {
        public override void StartEngine()
        {
            throw new NotSupportedException("Bicycle does not support StartEngine method");
        }
        public override void Drive()
        {
            Console.WriteLine("Riding the bicycle...");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Vehicle car = new Car();
            car.StartEngine();
            car.Drive();

            Vehicle motorcycle = new Motorcycle();
            motorcycle.StartEngine();
            motorcycle.Drive();

            Vehicle bicycle = new Bicycle();
            bicycle.StartEngine(); // This will throw NotSupportedException
            bicycle.Drive();
        }
    }
}
