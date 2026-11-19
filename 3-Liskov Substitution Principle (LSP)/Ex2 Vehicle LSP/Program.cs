namespace Ex2_Vehicle_LSP
{
    public class Vehicle
    {
        public virtual void Drive()
        {
            Console.WriteLine("Driving the vehicle...");
        }
    }

    public class VehicleWithEngine : Vehicle
    {
        public virtual void StartEngine()
        {
            Console.WriteLine("Starting the engine...");
        }
    }

    public class Car : VehicleWithEngine
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

    public class Motorcycle : VehicleWithEngine
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
        public override void Drive()
        {
            Console.WriteLine("Riding the bicycle...");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            VehicleWithEngine car = new Car();
            car.StartEngine();
            car.Drive();

            VehicleWithEngine motorcycle = new Motorcycle();
            motorcycle.StartEngine();
            motorcycle.Drive();

            Vehicle bicycle = new Bicycle();
            bicycle.Drive();
        }
    }
}
