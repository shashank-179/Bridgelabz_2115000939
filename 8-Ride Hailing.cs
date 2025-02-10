/*8. Ride-Hailing Application
Description: Develop a ride-hailing application.
Abstract Class:
Define an abstract class Vehicle with fields: vehicleId, driverName, and ratePerKm.
Add an abstract method CalculateFare(double distance).
Implement a concrete method GetVehicleDetails().
Subclasses:
Extend Vehicle into Car, Bike, and Auto.
Override CalculateFare() based on type-specific rates.
Interface:
Implement an interface IGPS.
Define methods GetCurrentLocation() and UpdateLocation().
Encapsulation:
Secure driver and vehicle details using private fields and properties.
Polymorphism:
Create a method that processes multiple vehicle types dynamically.
Calculate fares based on the Vehicle reference.
*/

using System;
using System.Collections.Generic;


// Abstract Class
public abstract class Vehicle
{
    public string VehicleId { get; set; }
    public string DriverName { get; set; }
    public double RatePerKm { get; set; }


    public abstract double CalculateFare(double distance);
}


// Subclasses
public class Car : Vehicle
{
    public override double CalculateFare(double distance)
    {
        return distance * RatePerKm;
    }
}


public class Bike : Vehicle
{
    public override double CalculateFare(double distance)
    {
        return distance * RatePerKm;
    }
}


// Interface
public interface IGPS
{
    string GetCurrentLocation();
    void UpdateLocation(string newLocation);
}


// Main Program
public class Program
{
    public static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car { VehicleId = "CAR123", DriverName = "Ramesh", RatePerKm = 5 },
            new Bike { VehicleId = "BIKE123", DriverName = "Suresh", RatePerKm = 3 }
        };


        foreach (var vehicle in vehicles)
        {
            double fare = vehicle.CalculateFare(10);  // Assume a 10 km ride
            Console.WriteLine("Vehicle: " + vehicle.DriverName + ", Fare: " + fare);
        }
    }
}


