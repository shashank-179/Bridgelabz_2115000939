/*Vehicle Management System with Hybrid Inheritance
Description: Model a vehicle system where Vehicle is the superclass and ElectricVehicle and PetrolVehicle are subclasses. Additionally, create a Refuelable interface implemented by PetrolVehicle.
Tasks:
Define a superclass Vehicle with attributes like MaxSpeed and Model.
Create an interface Refuelable with a method Refuel().
Define subclasses ElectricVehicle and PetrolVehicle. PetrolVehicle should implement Refuelable, while ElectricVehicle include a Charge() method.
Goal: Use hybrid inheritance by having PetrolVehicle implement both Vehicle and Refuelable, demonstrating how Java interfaces allow adding multiple behaviors.
*/

using System;

// Superclass: Vehicle
class Vehicle
{
    public string Model;
    public int MaxSpeed;

    // Constructor to initialize Vehicle attributes
    public Vehicle(string Model, int MaxSpeed)
    {
        this.Model = Model;
        this.MaxSpeed = MaxSpeed;
    }

    // Method to display vehicle details
    public void DisplayDetails()
    {
        Console.WriteLine($"Model: {Model}\nMax Speed: {MaxSpeed} km/h");
    }
}

// Interface: Refuelable (Defines Refuel method)
interface Refuelable
{
    void Refuel();
}

// Subclass: ElectricVehicle (Inherits from Vehicle)
class ElectricVehicle : Vehicle
{
    int BatteryCapacity;

    // Constructor to initialize ElectricVehicle attributes
    public ElectricVehicle(string Model, int MaxSpeed, int BatteryCapacity)
        : base(Model, MaxSpeed) // Calls base class constructor
    {
        this.BatteryCapacity = BatteryCapacity;
    }

    // Method to charge the electric vehicle
    public void Charge()
    {
        Console.WriteLine("Charging the electric vehicle...");
    }

    // Method to display ElectricVehicle details
    public void DisplayVehicleType()
    {
        Console.WriteLine("Vehicle Type: Electric Vehicle");
        base.DisplayDetails();
        Console.WriteLine($"Battery Capacity: {BatteryCapacity} kWh");
    }
}

// Subclass: PetrolVehicle (Inherits from Vehicle & Implements Refuelable)
class PetrolVehicle : Vehicle, Refuelable
{
    int FuelCapacity;

    // Constructor to initialize PetrolVehicle attributes
    public PetrolVehicle(string Model, int MaxSpeed, int FuelCapacity)
        : base(Model, MaxSpeed) // Calls base class constructor
    {
        this.FuelCapacity = FuelCapacity;
    }

    // Implementing Refuel() method
    public void Refuel()
    {
        Console.WriteLine("Refueling the petrol vehicle...");
    }

    // Method to display PetrolVehicle details
    public void DisplayVehicleType()
    {
        Console.WriteLine("Vehicle Type: Petrol Vehicle");
        base.DisplayDetails();
        Console.WriteLine($"Fuel Capacity: {FuelCapacity} liters");
    }
}

// Main class
class Program
{
    public static void Main()
    {
        // Creating ElectricVehicle object
        ElectricVehicle ev = new ElectricVehicle("Tesla Model 3", 200, 75);

        // Creating PetrolVehicle object
        PetrolVehicle pv = new PetrolVehicle("Ford Mustang", 250, 50);

        // Displaying vehicle details
        ev.DisplayVehicleType();
        ev.Charge();
        Console.WriteLine();

        pv.DisplayVehicleType();
        pv.Refuel();
    }
}

