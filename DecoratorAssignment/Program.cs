using System;
using System.Linq.Expressions;
namespace DecoratorAssignment
{
    //    public abstract class Vehicle
    //{
    //    public abstract string GetDescription();
    //    public abstract double GetCost();

    //}
    //abstract class VehicleDecorator : Vehicle //DecoratorBase
    //{
    //    Vehicle Vehicle = null;
    //    public VehicleDecorator(Vehicle vehicle)
    //    {
    //        this.Vehicle = vehicle;
    //    }
    //    public override string GetDescription()
    //    {
    //        return Vehicle.GetDescription();
    //    }
    //}

    //public class MotorBike : Vehicle
    //{
    //    public override string GetDescription()
    //    {
    //        return "MotorBike";
    //    }

    //    public override double GetCost()
    //    {
    //        return 0; 
    //    }
    //}
    //public class LightMotorVehicle : Vehicle
    //{
    //    public override string GetDescription()
    //    {
    //        return "Light Motor Vehicle";
    //    }

    //    public override double GetCost()
    //    {
    //        return 200;
    //    }
    //}

    //public class HeavyMotorVehicle : Vehicle
    //{
    //    public override string GetDescription()
    //    {
    //        return "Heavy Motor Vehicle";
    //    }

    //    public override double GetCost()
    //    {
    //        return 400;
    //    }
    //}
    //class SoundSystem : VehicleDecorator//ConcreteDecorator
    //{
    //    Vehicle vehicle;
    //    public SoundSystem(Vehicle vehicle) : base(vehicle)
    //    {
    //        this.vehicle = vehicle;
    //    }
    //    public override string GetDescription()
    //    {
    //        return vehicle.GetDescription() + ", Sound System";
    //    }
    //    public override double GetCost()
    //    {
    //        return vehicle.GetCost() + 1000;
    //    }
    //}
    //class Wifi : VehicleDecorator//ConcreteDecorator
    //{
    //    Vehicle vehicle;
    //    public Wifi(Vehicle vehicle) : base(vehicle)
    //    {
    //        this.vehicle = vehicle;
    //    }
    //    public override string GetDescription()
    //    {
    //        return vehicle.GetDescription() + ", Wi-fi";
    //    }
    //    public override double GetCost()
    //    {
    //        return vehicle.GetCost() + 750;
    //    }
    //}
    //class Camera : VehicleDecorator//ConcreteDecorator
    //{
    //    Vehicle vehicle;
    //    public Camera(Vehicle vehicle) : base(vehicle)
    //    {
    //        this.vehicle = vehicle;
    //    }
    //    public override string GetDescription()
    //    {
    //        return vehicle.GetDescription() + ", Camera";
    //    }
    //    public override double GetCost()
    //    {
    //        return vehicle.GetCost() + 400;
    //    }
    //}
    //    class Program
    //    {
    //        static void Main(string[] args)
    //        {
    //            Vehicle beverage = new MotorBike();
    //            beverage = new SoundSystem(beverage);
    //            beverage = new Wifi(beverage);
    //            beverage = new Camera(beverage);
    //            Console.WriteLine(beverage.GetDescription() + " " + beverage.GetCost().ToString("C"));

    //            Vehicle beverage2 = new LightMotorVehicle();
    //            beverage2 = new Wifi(beverage2);
    //            beverage2 = new Camera(beverage2);
    //            Console.WriteLine(beverage2.GetDescription() + " " + beverage2.GetCost().ToString("C"));

    //            Vehicle beverage3 = new HeavyMotorVehicle();
    //            beverage3 = new Camera(beverage3);
    //            Console.WriteLine(beverage3.GetDescription() + " " + beverage3.GetCost().ToString("C"));

    //            Console.ReadLine();
    //        }
    //

    // The abstract base component class
    // The abstract base component class
    public abstract class Technician
    {
        public abstract string Description { get; }
        public abstract double Cost { get; }
    }

    // Concrete component for Motor Bike Technician
    public class MotorBikeTechnician : Technician
    {
        public override string Description => "Motor Bike Technician";
        public override double Cost => 0; // Base cost without any additions
    }

    // Concrete component for Light Motor Technician
    public class LightMotorTechnician : Technician
    {
        public override string Description => "Light Motor Technician";
        public override double Cost => 0; // Base cost without any additions
    }

    // Concrete component for Heavy Motor Technician
    public class HeavyMotorTechnician : Technician
    {
        public override string Description => "Heavy Motor Technician";
        public override double Cost => 0; // Base cost without any additions
    }
    // The abstract decorator base class inheriting from Technician
    public abstract class TechnicianDecorator : Technician
    {
        protected Technician _technician;

        public TechnicianDecorator(Technician technician)
        {
            _technician = technician;
        }

        public override string Description => _technician.Description;
        public override double Cost => _technician.Cost;
    }
    // Decorator for adding a Sound System
    public class SoundSystemDecorator : TechnicianDecorator
    {
        private double _soundSystemCost;

        public SoundSystemDecorator(Technician technician) : base(technician)
        {
            _soundSystemCost = GetSoundSystemCost();
        }

        public override string Description => _technician.Description + ", Sound System";

        public override double Cost => _technician.Cost + _soundSystemCost;

        private double GetSoundSystemCost()
        {
            if (_technician is MotorBikeTechnician) return 1000;
            if (_technician is LightMotorTechnician) return 1200;
            if (_technician is HeavyMotorTechnician) return 1400;
            return 0;
        }
    }

    // Decorator for adding Wi-Fi
    public class WifiDecorator : TechnicianDecorator
    {
        private double _wifiCost;

        public WifiDecorator(Technician technician) : base(technician)
        {
            _wifiCost = GetWifiCost();
        }

        public override string Description => _technician.Description + ", Wi-Fi";

        public override double Cost => _technician.Cost + _wifiCost;

        private double GetWifiCost()
        {
            if (_technician is MotorBikeTechnician) return 750;
            if (_technician is LightMotorTechnician) return 950;
            if (_technician is HeavyMotorTechnician) return 1000;
            return 0;
        }
    }

    // Decorator for adding a Camera
    public class CameraDecorator : TechnicianDecorator
    {
        private double _cameraCost;

        public CameraDecorator(Technician technician) : base(technician)
        {
            _cameraCost = GetCameraCost();
        }

        public override string Description => _technician.Description + ", Camera";

        public override double Cost => _technician.Cost + _cameraCost;

        private double GetCameraCost()
        {
            if (_technician is MotorBikeTechnician) return 200;
            if (_technician is LightMotorTechnician) return 400;
            if (_technician is HeavyMotorTechnician) return 600;
            return 0;
        }
    }
    public class Program
    {
        public static void Main()
        {
            Technician technician = new LightMotorTechnician();
            technician = new SoundSystemDecorator(technician);
            technician = new WifiDecorator(technician);
            technician = new CameraDecorator(technician);

            //double soundSystemCost = new SoundSystemDecorator(new LightMotorTechnician()).Cost;
            //double wifiCost = new WifiDecorator(new LightMotorTechnician()).Cost - new LightMotorTechnician().Cost;
            //double cameraCost = new CameraDecorator(new LightMotorTechnician()).Cost - new LightMotorTechnician().Cost;



            Technician technician2 = new HeavyMotorTechnician();
            technician2 = new SoundSystemDecorator(technician2);
            technician2 = new WifiDecorator(technician2);
            technician2 = new CameraDecorator(technician2);

            double soundSystemCost = new SoundSystemDecorator(new HeavyMotorTechnician()).Cost;
            double wifiCost = new WifiDecorator(new HeavyMotorTechnician()).Cost - new HeavyMotorTechnician().Cost;
            double cameraCost = new CameraDecorator(new HeavyMotorTechnician()).Cost - new HeavyMotorTechnician().Cost;

            Console.WriteLine("Description: " + technician.Description);
            Console.WriteLine("Sound System Cost: R" + soundSystemCost);
            Console.WriteLine("Wi-Fi Cost: R" + wifiCost);
            Console.WriteLine("Camera Cost: R" + cameraCost);
            Console.WriteLine("Total Cost: R" + (soundSystemCost+ wifiCost+ cameraCost)); //technician.Cost);
        }
    }


}



