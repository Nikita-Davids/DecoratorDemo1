using System;
using System.Linq.Expressions;
namespace DecoratorAssignment
{
    public abstract class Vehicle
{
    public abstract string GetDescription();
    public abstract double GetCost();
  
}
abstract class VehicleDecorator : Vehicle //DecoratorBase
{
    Vehicle Vehicle = null;
    public VehicleDecorator(Vehicle vehicle)
    {
        this.Vehicle = vehicle;
    }
    public override string GetDescription()
    {
        return Vehicle.GetDescription();
    }
}

public class MotorBike : Vehicle
{
    public override string GetDescription()
    {
        return "MotorBike";
    }

    public override double GetCost()
    {
        return 0; 
    }
}
public class LightMotorVehicle : Vehicle
{
    public override string GetDescription()
    {
        return "Light Motor Vehicle";
    }

    public override double GetCost()
    {
        return 200;
    }
}

public class HeavyMotorVehicle : Vehicle
{
    public override string GetDescription()
    {
        return "Heavy Motor Vehicle";
    }

    public override double GetCost()
    {
        return 400;
    }
}
class SoundSystem : VehicleDecorator//ConcreteDecorator
{
    Vehicle vehicle;
    public SoundSystem(Vehicle vehicle) : base(vehicle)
    {
        this.vehicle = vehicle;
    }
    public override string GetDescription()
    {
        return vehicle.GetDescription() + ", Sound System";
    }
    public override double GetCost()
    {
        return vehicle.GetCost() + 1000;
    }
}
class Wifi : VehicleDecorator//ConcreteDecorator
{
    Vehicle vehicle;
    public Wifi(Vehicle vehicle) : base(vehicle)
    {
        this.vehicle = vehicle;
    }
    public override string GetDescription()
    {
        return vehicle.GetDescription() + ", Wi-fi";
    }
    public override double GetCost()
    {
        return vehicle.GetCost() + 750;
    }
}
class Camera : VehicleDecorator//ConcreteDecorator
{
    Vehicle vehicle;
    public Camera(Vehicle vehicle) : base(vehicle)
    {
        this.vehicle = vehicle;
    }
    public override string GetDescription()
    {
        return vehicle.GetDescription() + ", Camera";
    }
    public override double GetCost()
    {
        return vehicle.GetCost() + 400;
    }
}
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle beverage = new MotorBike();
            beverage = new SoundSystem(beverage);
            beverage = new Wifi(beverage);
            beverage = new Camera(beverage);
            Console.WriteLine(beverage.GetDescription() + " " + beverage.GetCost().ToString("C"));

            Vehicle beverage2 = new LightMotorVehicle();
            beverage2 = new Wifi(beverage2);
            beverage2 = new Camera(beverage2);
            Console.WriteLine(beverage2.GetDescription() + " " + beverage2.GetCost().ToString("C"));

            Vehicle beverage3 = new HeavyMotorVehicle();
            beverage3 = new Camera(beverage3);
            Console.WriteLine(beverage3.GetDescription() + " " + beverage3.GetCost().ToString("C"));

            Console.ReadLine();
        }
    }
}



