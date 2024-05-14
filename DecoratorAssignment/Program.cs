using System;

public abstract class Vehicle
{
    public abstract string GetDescription();
    public abstract double GetCost();
}

public class MotorBike : Vehicle
{
    public override string GetDescription()
    {
        return "MotorBike";
    }

    public override double GetCost()
    {
        return 0; // Base cost of the vehicle, assuming zero for simplicity
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
        return 0;
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
        return 0;
    }
}

public abstract class VehicleDecorator : Vehicle
{
    protected Vehicle _vehicle;

    public VehicleDecorator(Vehicle vehicle)
    {
        _vehicle = vehicle;
    }

    public override string GetDescription()
    {
        return _vehicle.GetDescription();
    }

    public override double GetCost()
    {
        return _vehicle.GetCost();
    }
}

public class SoundSystem : VehicleDecorator
{
    public SoundSystem(Vehicle vehicle) : base(vehicle) { }

    public override string GetDescription()
    {
        return _vehicle.GetDescription() + " + Sound System";
    }

    public override double GetCost()
    {
        return _vehicle.GetCost() + GetSoundSystemCost();
    }

    private double GetSoundSystemCost()
    {
        if (_vehicle is MotorBike) return 1000;
        if (_vehicle is LightMotorVehicle) return 1200;
        if (_vehicle is HeavyMotorVehicle) return 1400;
        return 0;
    }
}

public class WiFi : VehicleDecorator
{
    public WiFi(Vehicle vehicle) : base(vehicle) { }

    public override string GetDescription()
    {
        return _vehicle.GetDescription() + " + Wi-Fi";
    }

    public override double GetCost()
    {
        return _vehicle.GetCost() + GetWiFiCost();
    }

    private double GetWiFiCost()
    {
        if (_vehicle is MotorBike) return 750;
        if (_vehicle is LightMotorVehicle) return 950;
        if (_vehicle is HeavyMotorVehicle) return 1000;
        return 0;
    }
}

public class Camera : VehicleDecorator
{
    public Camera(Vehicle vehicle) : base(vehicle) { }

    public override string GetDescription()
    {
        return _vehicle.GetDescription() + " + Camera";
    }

    public override double GetCost()
    {
        return _vehicle.GetCost() + GetCameraCost();
    }

    private double GetCameraCost()
    {
        if (_vehicle is MotorBike) return 200;
        if (_vehicle is LightMotorVehicle) return 400;
        if (_vehicle is HeavyMotorVehicle) return 600;
        return 0;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Select a vehicle:");
        Console.WriteLine("1. MotorBike");
        Console.WriteLine("2. Light Motor Vehicle");
        Console.WriteLine("3. Heavy Motor Vehicle");

        int vehicleChoice = int.Parse(Console.ReadLine());

        Vehicle selectedVehicle = null;
        switch (vehicleChoice)
        {
            case 1:
                selectedVehicle = new MotorBike();
                break;
            case 2:
                selectedVehicle = new LightMotorVehicle();
                break;
            case 3:
                selectedVehicle = new HeavyMotorVehicle();
                break;
            default:
                Console.WriteLine("Invalid selection");
                return;
        }

        Console.WriteLine("Select options to add:");
        Console.WriteLine("1. Sound System");
        Console.WriteLine("2. Wi-Fi");
        Console.WriteLine("3. Camera");
        Console.WriteLine("4. All options");
        Console.WriteLine("5. No options");

        int optionChoice = int.Parse(Console.ReadLine());

        switch (optionChoice)
        {
            case 1:
                selectedVehicle = new SoundSystem(selectedVehicle);
                break;
            case 2:
                selectedVehicle = new WiFi(selectedVehicle);
                break;
            case 3:
                selectedVehicle = new Camera(selectedVehicle);
                break;
            case 4:
                selectedVehicle = new SoundSystem(new WiFi(new Camera(selectedVehicle)));
                break;
            case 5:
                break;
            default:
                Console.WriteLine("Invalid selection");
                return;
        }

        DisplayVehicleOptions(selectedVehicle);
    }

    public static void DisplayVehicleOptions(Vehicle vehicle)
    {
        Console.WriteLine($"Options for {vehicle.GetDescription()}:");
        Console.WriteLine($"Total cost: R{vehicle.GetCost()}");
    }
}



